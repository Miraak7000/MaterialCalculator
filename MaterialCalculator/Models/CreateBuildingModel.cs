using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Models {

  public abstract class CreateBuildingModel {

    #region Properties
    public Buildings Building { get; }
    #endregion

    #region Constructor
    protected CreateBuildingModel(Buildings building) {
      this.Building = building;
    }
    #endregion

  }

}