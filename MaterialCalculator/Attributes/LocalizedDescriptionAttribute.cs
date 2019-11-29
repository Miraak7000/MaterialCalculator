using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using MaterialCalculator.Resources;

namespace MaterialCalculator.Attributes {

  public class LocalizedDescriptionAttribute : DescriptionAttribute {

    #region Properties
    public String Value {
      get {
        var property = typeof(Localization).GetProperties(BindingFlags.Public | BindingFlags.Static).SingleOrDefault(w => w.Name == this.ResourceName);
        if (property != null) {
          return property.GetValue(null, null) as String;
        }
        return String.Empty;
      }
    }
    #endregion

    #region Fields
    private readonly String ResourceName;
    #endregion

    #region Constructor
    public LocalizedDescriptionAttribute(Type resourceType, String resourceKey) {
      this.ResourceName = $"{resourceType.Name}_{resourceKey}";
    }
    #endregion

  }

}