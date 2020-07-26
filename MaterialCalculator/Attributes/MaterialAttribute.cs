using System;

namespace MaterialCalculator.Attributes {

  public class MaterialAttribute : Attribute {

    #region Properties
    public String Image { get; }
    #endregion

    #region Constructor
    public MaterialAttribute(String image) {
      this.Image = image;
    }
    #endregion

  }

}