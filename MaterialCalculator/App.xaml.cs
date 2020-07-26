namespace MaterialCalculator {

  public partial class App {

    #region Constructor
    public App() {
    }
    #endregion

    #region Public Methods
    public static void ChangeLanguage() {
      var oldWindow = App.Current.MainWindow as MainWindow;
      oldWindow?.Finish();
      // create a new window after languages was changed
      var newWindow = new MainWindow();
      App.Current.MainWindow = newWindow;
      newWindow.Show();
      // close the old one
      oldWindow?.Close();
    }
    #endregion

  }

}