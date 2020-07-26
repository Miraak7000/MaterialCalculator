using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Models.Create {

  public abstract class CreateModel {

    #region Properties
    protected Buildings Building { get; }
    #endregion

    #region Constructor
    protected CreateModel(Buildings building) {
      this.Building = building;
    }
    #endregion

  }

}