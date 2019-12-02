using System;
using MaterialCalculator.Library;
using MaterialCalculator.Models.Island;
using MaterialCalculator.Models.Main;

// ReSharper disable ClassNeverInstantiated.Global
namespace MaterialCalculator.DesignTime {

  public class ApplicationDesignTimeModel {

    #region Properties
    public NotifyProperty<ApplicationModel> Model { get; set; }
    #endregion

    #region Constructor
    public ApplicationDesignTimeModel() {
      this.Model = new NotifyProperty<ApplicationModel>(new ApplicationModel());
      this.Model.Value.Islands.Add(new IslandModel { Name = new NotifyProperty<String>("Example Island 1") });
      this.Model.Value.Islands.Add(new IslandModel { Name = new NotifyProperty<String>("Example Island 2") });
      this.Model.Value.Islands.Add(new IslandModel { Name = new NotifyProperty<String>("Example Island 3") });
    }
    #endregion

  }

}