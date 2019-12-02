using System;
using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Library {

  public class Material {

    #region Properties
    public Materials Type { get; set; }
    public String Description { get; set; }
    public Byte[] Image { get; set; }
    #endregion

  }

}