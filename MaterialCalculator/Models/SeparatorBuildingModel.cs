﻿using System;

namespace MaterialCalculator.Models {

  public class SeparatorBuildingModel : BuildingModel {

    #region Properties
    public override Double OutputTarget {
      get { return 0; }
    }
    public override Double OutputActual {
      get { return 0; }
    }
    #endregion

    #region Constructor
    public SeparatorBuildingModel() {
    }
    #endregion

    #region Public Methods
    public override void Init() {
    }
    #endregion

  }

}