using System;
using MaterialCalculator.Library;
using MaterialCalculator.Models.Island;
using MaterialCalculator.Models.Main;

// ReSharper disable MemberCanBeMadeStatic.Global
// ReSharper disable ClassNeverInstantiated.Global
namespace MaterialCalculator.DesignTime {

  public class ApplicationDesignTimeModel {

    #region Properties
    public ApplicationModel BindingModel {
      get { return MainWindow.ApplicationModel; }
    }
    #endregion

    #region Constructor
    public ApplicationDesignTimeModel() {
      MainWindow.ApplicationModel = new ApplicationModel();
      MainWindow.ApplicationModel.Islands.Add(new IslandModel { Name = new NotifyProperty<String>("Example Island 1") });
      MainWindow.ApplicationModel.Islands.Add(new IslandModel { Name = new NotifyProperty<String>("Example Island 2") });
      MainWindow.ApplicationModel.Islands.Add(new IslandModel { Name = new NotifyProperty<String>("Example Island 3") });
    }
    #endregion

  }

}