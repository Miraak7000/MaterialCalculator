﻿using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;
using MaterialCalculator.Models.Create;

namespace MaterialCalculator.Windows {

  public partial class AddBuildingWindow {

    #region Properties
    public NotifyProperty<CreateModel> Model { get; set; }
    #endregion

    #region Fields
    private readonly Buildings Building;
    private static readonly Regex IntegerInput = new Regex("[^0-9.-]+");
    #endregion

    #region Constructor
    public AddBuildingWindow(Buildings building) {
      this.InitializeComponent();
      this.Building = building;
      this.Owner = Application.Current.MainWindow;
      this.Model = new NotifyProperty<CreateModel>(null);
      this.DataContext = this;
    }
    #endregion

    #region Events
    private void ButtonOK_OnClick(Object sender, RoutedEventArgs e) {
      if (this.Model.Value == null) return;
      switch (this.Model.Value) {
        case CreateProductionModel model:
          if (model.NumberOfBuildings < 1) return;
          if (model.Productivity < 0) return;
          break;
        case CreateReferenceModel model:
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
          this.Model.Value = new CreateProductionModel(this.Building);
          break;
        case 1:
          this.Model.Value = new CreateReferenceModel(this.Building);
          break;
        default:
          throw new ArgumentOutOfRangeException($"this index is not supported: {index}");
      }
    }
    #endregion

  }

}