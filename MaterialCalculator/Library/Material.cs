using System;
using System.Linq;
using System.Reflection;
using MaterialCalculator.Attributes;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Resources;

namespace MaterialCalculator.Library {

  public class Material : IComparable<Material>, IEquatable<Material> {

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

    #region Public Methods
    public Int32 CompareTo(Material other) {
      if (ReferenceEquals(this, other)) return 0;
      return ReferenceEquals(null, other) ? 1 : this.Type.CompareTo(other.Type);
    }
    public Boolean Equals(Material other) {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return this.Type == other.Type;
    }
    public override Boolean Equals(Object obj) {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      return obj.GetType() == this.GetType() && this.Equals((Material)obj);
    }
    public override Int32 GetHashCode() {
      return (Int32)this.Type;
    }
    #endregion

  }

}