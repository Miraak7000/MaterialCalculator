using System;
using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Models.Create {

  public class CreateProductionModel : CreateModel {

    #region Properties
    public Int32 NumberOfBuildings { get; set; }
    public Int32 Productivity { get; set; }
    #endregion

    #region Constructor
    public CreateProductionModel(Buildings building) : base(building) {
      this.NumberOfBuildings = 1;
      this.Productivity = 100;
    }
    #endregion

  }

}