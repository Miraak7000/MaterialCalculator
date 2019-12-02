using System;
using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Library {

  public class Building {

    #region Properties
    public Buildings Type { get; set; }
    public String Description { get; set; }
    public Int32 Duration { get; set; }
    public Material Output { get; set; }
    public Material[] Inputs { get; set; }
    #endregion

  }

}