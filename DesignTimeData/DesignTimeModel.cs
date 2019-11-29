using MaterialCalculator.Models;

// ReSharper disable ClassNeverInstantiated.Global
namespace MaterialCalculator.DesignTime {

  public class DesignTimeModel {

    #region Properties
    public ApplicationModel Data { get; set; }
    #endregion

    #region Constructor
    public DesignTimeModel() {
      this.Data = new ApplicationModel();
      this.Data.Islands.Add(new IslandModel() { Name = "Example Island 1" });
      this.Data.Islands.Add(new IslandModel() { Name = "Example Island 2" });
      this.Data.Islands.Add(new IslandModel() { Name = "Example Island 3" });
    }
    #endregion

  }

}