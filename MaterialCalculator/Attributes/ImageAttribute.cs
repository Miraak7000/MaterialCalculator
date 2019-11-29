using System;
using System.ComponentModel;

namespace MaterialCalculator.Attributes {

  public class ImageAttribute : DescriptionAttribute {

    #region Properties
    public String ImageName { get; }
    #endregion

    #region Constructor
    public ImageAttribute(String imageName) {
      this.ImageName = imageName;
    }
    #endregion

  }

}