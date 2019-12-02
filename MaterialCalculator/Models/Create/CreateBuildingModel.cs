using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Models.Create {

  public abstract class CreateBuildingModel {

    #region Properties
    protected Buildings Building { get; }
    #endregion

    #region Constructor
    protected CreateBuildingModel(Buildings building) {
      this.Building = building;
    }
    #endregion

  }

}