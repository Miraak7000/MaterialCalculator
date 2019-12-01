namespace MaterialCalculator {

  public partial class App {

    #region Constructor
    public App() {
    }
    #endregion

    #region Public Methods
    public void ChangeLanguage() {
      var oldWindow = App.Current.MainWindow;
      var newWindow = new MainWindow();
      App.Current.MainWindow = newWindow;
      oldWindow?.Close();
      newWindow.Show();
    }
    #endregion

  }

}