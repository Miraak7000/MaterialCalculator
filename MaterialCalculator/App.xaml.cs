using System.Globalization;
using System.Windows;

namespace MaterialCalculator {

  public partial class App : Application {

    #region Constructor
    public App() {
      CultureInfo.CurrentUICulture = new CultureInfo("DE");
    }
    #endregion

  }

}