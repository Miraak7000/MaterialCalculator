using System;
using System.Reflection;
using System.Windows.Media;
using System.Xml.Serialization;
using MaterialCalculator.Attributes;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global
namespace MaterialCalculator.Models {

  [XmlInclude(typeof(ProductionBuildingModel)), XmlInclude(typeof(ReferenceBuildingModel))]
  public abstract class BuildingModel {

    #region Properties
    [XmlIgnore]
    public IslandModel Island { get; set; }
    public Buildings Building { get; set; }
    public abstract Double OutputTarget { get; }
    public abstract Double OutputActual { get; }
    [XmlIgnore]
    public NotifyProperty<String> OutputTargetString { get; protected set; }
    [XmlIgnore]
    public NotifyProperty<String> OutputActualString { get; protected set; }
    [XmlIgnore]
    public NotifyProperty<SolidColorBrush> StatusBackground { get; protected set; }
    [XmlIgnore]
    public NotifyProperty<String> ConsumerError { get; protected set; }
    public ProductionAttribute Production {
      get { return typeof(Buildings).GetField(Enum.GetName(typeof(Buildings), this.Building)).GetCustomAttribute<ProductionAttribute>(false); }
    }
    public String BuildingDescription {
      get { return typeof(Buildings).GetField(this.Building.ToString()).GetCustomAttribute<LocalizedDescriptionAttribute>(false).Value; }
    }
    public String MaterialDescription {
      get { return typeof(Materials).GetField(this.Production.Output.ToString()).GetCustomAttribute<LocalizedDescriptionAttribute>(false).Value; }
    }
    public Byte[] MaterialImage {
      get {
        var imageName = typeof(Materials).GetField(this.Production.Output.ToString()).GetCustomAttribute<ImageAttribute>(false).ImageName;
        var assembly = Assembly.GetEntryAssembly();
        if (assembly != null) {
          var stream = assembly.GetManifestResourceStream($"MaterialCalculator.Resources.Materials.{imageName}");
          if (stream != null) {
            var image = new Byte[stream.Length];
            stream.Read(image, 0, image.Length);
            return image;
          }
        }
        return null;
      }
    }
    #endregion

    #region Public Methods
    public abstract void Init();
    #endregion

  }

}