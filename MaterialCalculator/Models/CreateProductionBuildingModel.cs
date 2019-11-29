using System;
using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Models {

  public class CreateProductionBuildingModel : CreateBuildingModel {

    #region Properties
    public Int32 NumberOfBuildings { get; set; }
    public Int32 Productivity { get; set; }
    #endregion

    #region Constructor
    public CreateProductionBuildingModel(Buildings building) {
      this.NumberOfBuildings = 1;
      this.Productivity = 100;
    }
    #endregion

  }

}