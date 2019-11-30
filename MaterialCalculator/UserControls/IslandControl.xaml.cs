using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using MaterialCalculator.Attributes;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;
using MaterialCalculator.Models;
using MaterialCalculator.Windows;
using Localization = MaterialCalculator.Resources.Localization;

// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable once MemberCanBeMadeStatic.Global
namespace MaterialCalculator.UserControls {

  public partial class IslandControl : UserControl {

    #region Properties
    public IEnumerable<Tuple<Buildings, String>> Buildings {
      get { return Enum.GetNames(typeof(Buildings)).Select(s => new Tuple<Buildings, String>(Enum.Parse<Buildings>(s), typeof(Buildings).GetField(s).GetCustomAttribute<LocalizedDescriptionAttribute>(false).Value)).OrderBy(o => o.Item2); }
    }
    public Tuple<Buildings, String> SelectedBuilding { get; set; }
    #endregion

    #region Constructor
    public IslandControl() {
      this.InitializeComponent();
    }
    #endregion

    #region Events
    private void ButtonAddBuilding_OnClick(Object sender, RoutedEventArgs e) {
      if (this.SelectedBuilding != null) {
        var window = new AddBuildingWindow(this.SelectedBuilding.Item1);
        var result = window.ShowDialog();
        if (result.HasValue && result.Value) {
          if (this.DataContext is IslandModel island) {
            switch (window.Model.Value) {
              case CreateProductionBuildingModel model:
                var modelProduction = new ProductionBuildingModel(this.SelectedBuilding.Item1) {
                  Island = island,
                  NumberOfBuildings = new NotifyProperty<Int32>(model.NumberOfBuildings),
                  Productivity = new NotifyProperty<Int32>(model.Productivity)
                };
                modelProduction.Init();
                island.Buildings.Add(modelProduction);
                break;
              case CreateReferenceBuildingModel model:
                var modelReference = new ReferenceBuildingModel(this.SelectedBuilding.Item1) {
                  Island = island,
                  Reference = model.SelectedIsland
                };
                modelReference.Init();
                island.Buildings.Add(modelReference);
                break;
              default:
                throw new ArgumentOutOfRangeException($"this model is not supported: {window.Model.Value.GetType()}");
            }
          }
        }
      }
    }
    private void ButtonDelete_OnClick(Object sender, RoutedEventArgs e) {
      var result = MessageBox.Show(Application.Current.MainWindow, Localization.MessageBox_RemoveBuilding, Localization.MessageBox_Title, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
      if (result == MessageBoxResult.Yes) {
        var model = (BuildingModel)((Button)e.Source).DataContext;
        model.Island.Buildings.Remove(model);
      }
    }
    private void ButtonUp_OnClick(Object sender, RoutedEventArgs e) {
      var model = (BuildingModel)((Button)e.Source).DataContext;
      var sorting = model.Island.Buildings.ToArray();
      var index = Array.IndexOf(sorting, model);
      if (index > 0) {
        model.Island.Buildings.Remove(model);
        model.Island.Buildings.Insert(index - 1, model);
      }
    }
    private void ButtonDown_OnClick(Object sender, RoutedEventArgs e) {
      var model = (BuildingModel)((Button)e.Source).DataContext;
      var sorting = model.Island.Buildings.ToArray();
      var index = Array.IndexOf(sorting, model);
      if (index < model.Island.Buildings.Count - 1) {
        model.Island.Buildings.Remove(model);
        model.Island.Buildings.Insert(index + 1, model);
      }
    }
    #endregion

  }

}