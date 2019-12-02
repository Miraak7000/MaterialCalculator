using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialCalculator.Attributes;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;
using MaterialCalculator.Models.Create;
using MaterialCalculator.Models.Island;
using MaterialCalculator.Models.Work;
using MaterialCalculator.Windows;
using Localization = MaterialCalculator.Resources.Localization;

// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable once MemberCanBeMadeStatic.Global
namespace MaterialCalculator.UserControls {

  public partial class IslandControl {

    #region Properties
    public IEnumerable<Tuple<Buildings, String>> Buildings {
      get { return Enum.GetNames(typeof(Buildings)).Select(s => new Tuple<Buildings, String>(Enum.Parse<Buildings>(s), typeof(Buildings).GetField(s).GetCustomAttribute<LocalizedDescriptionAttribute>(false).Value)).OrderBy(o => o.Item2); }
    }
    public Tuple<Buildings, String> SelectedBuilding { get; set; }
    #endregion

    #region Fields
    private Point StartPoint;
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
              case CreateProductionModel model:
                var modelProduction = new ProductionBuildingModel(this.SelectedBuilding.Item1) {
                  Island = island,
                  NumberOfBuildings = new NotifyProperty<Int32>(model.NumberOfBuildings),
                  Productivity = new NotifyProperty<Int32>(model.Productivity)
                };
                modelProduction.Init();
                island.Buildings.Add(modelProduction);
                island.Calculate();
                break;
              case CreateReferenceModel model:
                var modelReference = new ReferenceBuildingModel(this.SelectedBuilding.Item1) {
                  Island = island,
                  ReferenceID = model.SelectedIsland.ID
                };
                modelReference.Init();
                island.Buildings.Add(modelReference);
                island.Calculate();
                break;
              default:
                throw new ArgumentOutOfRangeException($"this model is not supported: {window.Model.Value.GetType()}");
            }
          }
        }
      }
    }
    private void ButtonAddSeparator_OnClick(Object sender, RoutedEventArgs e) {
      if (this.DataContext is IslandModel island) {
        var modelSeparator = new SeparatorBuildingModel {
          Island = island
        };
        island.Buildings.Add(modelSeparator);
      }
    }
    private void ButtonDelete_OnClick(Object sender, RoutedEventArgs e) {
      if (this.ListViewBuildings.SelectedItem == null) return;
      var result = MessageBox.Show(Application.Current.MainWindow, Localization.MessageBox_RemoveBuilding, Localization.MessageBox_Title, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
      if (result == MessageBoxResult.Yes) {
        var model = (BaseModel)this.ListViewBuildings.SelectedItem;
        model.Island.Buildings.Remove(model);
      }
    }
    private void Buildings_PreviewMouseLeftButtonDown(Object sender, MouseButtonEventArgs e) {
      this.StartPoint = e.GetPosition(null);
    }
    private void Buildings_MouseMove(Object sender, MouseEventArgs e) {
      if (sender is ListView listView) {
        var mousePosition = e.GetPosition(null);
        var diff = this.StartPoint - mousePosition;
        if (e.LeftButton == MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)) {
          var source = (DependencyObject)e.OriginalSource;
          var listViewItem = source.FindAnchestor<ListViewItem>();
          if (listViewItem != null) {
            var building = (BaseModel)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);
            var dragData = new DataObject("BuildingObject", building);
            DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
          }
        }
      }
    }
    private void Buildings_OnDrop(Object sender, DragEventArgs e) {
      if (sender is ListView listView && e.Data.GetDataPresent("BuildingObject")) {
        if (e.Data.GetData("BuildingObject") is BaseModel building) {
          var source = (DependencyObject)e.OriginalSource;
          var listViewItem = source.FindAnchestor<ListViewItem>();
          if (listViewItem != null) {
            var newIndex = listView.Items.IndexOf(listViewItem.Content);
            if (listView.ItemsSource is ObservableCollection<BaseModel> list) {
              list.RemoveAt(list.IndexOf(building));
              list.Insert(newIndex, building);
            }
          }
        }
      }
    }
    private void Buildings_OnDragEnter(Object sender, DragEventArgs e) {
      if (!e.Data.GetDataPresent("BuildingObject") || sender == e.Source) {
        e.Effects = DragDropEffects.None;
      }
    }
    #endregion

  }

}