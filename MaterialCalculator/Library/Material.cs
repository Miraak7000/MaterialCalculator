using System;
using System.Linq;
using System.Reflection;
using MaterialCalculator.Attributes;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Resources;

namespace MaterialCalculator.Library {

  public class Material {

    #region Properties
    public Materials Type { get; }
    public String Description { get; }
    public Byte[] Image { get; }
    #endregion

    #region Constructor
    public Material(Materials type) {
      var definition = typeof(Materials).GetField($"{type}").GetCustomAttribute<MaterialAttribute>(false);
      this.Type = type;
      this.Description = typeof(Localization).GetProperties(BindingFlags.Public | BindingFlags.Static).SingleOrDefault(w => w.Name == $"{nameof(Materials)}_{type}")?.GetValue(null, null) as String;
      this.Image = Assembly.GetEntryAssembly().GetImage(definition.Image);
    }
    #endregion

  }

}