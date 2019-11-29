using System;
using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Attributes {

  public class ProductionAttribute : Attribute {

    #region Properties
    public Int32 Duration { get; set; }
    public Materials[] Inputs { get; set; }
    public Materials Output { get; set; }
    #endregion

    #region Constructor
    public ProductionAttribute(Materials output, Int32 duration, params Materials[] inputs) {
      this.Output = output;
      this.Duration = duration;
      this.Inputs = inputs;
    }
    #endregion

  }

}