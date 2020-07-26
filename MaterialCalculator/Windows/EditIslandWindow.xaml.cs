using System;
using System.Windows;

// ReSharper disable once MemberCanBePrivate.Global
namespace MaterialCalculator.Windows {

  public partial class EditIslandWindow {

    #region Properties
    public String IslandName { get; set; }
    #endregion

    #region Constructor
    public EditIslandWindow() {
      this.InitializeComponent();
      this.Owner = Application.Current.MainWindow;
      this.IslandName = String.Empty;
      this.DataContext = this;
      this.TextBoxName.Focus();
    }
    #endregion

    #region Events
    private void ButtonOK_OnClick(Object sender, RoutedEventArgs e) {
      if (this.IslandName == String.Empty) return;
      this.DialogResult = true;
      this.Close();
    }
    #endregion

  }

}