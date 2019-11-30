using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;
using MaterialCalculator.Models;

namespace MaterialCalculator.Windows {

  public partial class AddBuildingWindow : Window {

    #region Properties
    public NotifyProperty<CreateBuildingModel> Model { get; set; }
    #endregion

    #region Fields
    private static readonly Regex IntegerInput = new Regex("[^0-9.-]+");
    private readonly Buildings Building;
    #endregion

    #region Constructor
    public AddBuildingWindow(Buildings building) {
      this.InitializeComponent();
      this.Building = building;
      this.Owner = Application.Current.MainWindow;
      this.Model = new NotifyProperty<CreateBuildingModel>(null);
      this.DataContext = this;
    }
    #endregion

    #region Events
    private void ButtonOK_OnClick(Object sender, RoutedEventArgs e) {
      if (this.Model.Value == null) return;
      switch (this.Model.Value) {
        case CreateProductionBuildingModel model:
          if (model.NumberOfBuildings < 1) return;
          if (model.Productivity < 0) return;
          break;
        case CreateReferenceBuildingModel model:
          if (model.SelectedIsland == null) return;
          break;
        default:
          throw new ArgumentOutOfRangeException($"this model is not supported: {this.Model.Value.GetType()}");
      }
      this.DialogResult = true;
      this.Close();
    }
    private void TextBoxIntegerInput_OnPreviewTextInput(Object sender, TextCompositionEventArgs e) {
      e.Handled = AddBuildingWindow.IntegerInput.IsMatch(e.Text);
    }
    private void BuildingPlace_OnSelectionChanged(Object sender, SelectionChangedEventArgs e) {
      if (!this.IsInitialized) return;
      var index = ((ComboBox)e.Source).SelectedIndex;
      switch (index) {
        case 0:
          this.Model.Value = new CreateProductionBuildingModel(this.Building);
          break;
        case 1:
          this.Model.Value = new CreateReferenceBuildingModel(this.Building);
          break;
        default:
          throw new ArgumentOutOfRangeException($"this index is not supported: {index}");
      }
    }
    #endregion

  }

}