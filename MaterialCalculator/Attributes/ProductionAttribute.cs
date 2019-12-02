using System;
using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Attributes {

  public class ProductionAttribute : Attribute {

    #region Properties
    public Int32 Duration { get; }
    public Materials[] Inputs { get; }
    public Materials Output { get; }
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