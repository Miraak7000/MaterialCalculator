using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Media;
using System.Xml.Serialization;
using MaterialCalculator.Attributes;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;

// ReSharper disable MemberCanBePrivate.Global
namespace MaterialCalculator.Models {

  public class ReferenceBuildingModel : BuildingModel {

    #region Properties
    public IslandModel Reference { get; set; }
    public override Double OutputTarget {
      get {
        var consumers = this.Island.Buildings.OfType<ProductionBuildingModel>().Where(w => w.Production.Inputs.Contains(this.Production.Output)).ToArray();
        return consumers.Sum(s => s.OutputActual);
      }
    }
    public override Double OutputActual {
      get {
        var buildings = this.Reference.Buildings.OfType<ProductionBuildingModel>().Where(w => w.Production.Output == this.Production.Output).ToArray();
        var output = buildings.Sum(s => s.OutputActual);
        return output;
      }
    }
    [XmlIgnore]
    public NotifyProperty<String> OutputTargetString { get; private set; }
    [XmlIgnore]
    public NotifyProperty<String> OutputActualString { get; private set; }
    [XmlIgnore]
    public NotifyProperty<SolidColorBrush> StatusBackground { get; private set; }
    [XmlIgnore]
    public NotifyProperty<String> ConsumerError { get; private set; }
    #endregion

    #region Fields
    #endregion

    #region Constructor
    private ReferenceBuildingModel() {
    }
    public ReferenceBuildingModel(Buildings building) {
      this.Building = building;
      this.Init();
    }
    #endregion

    #region Public Methods
    public override void Init() {
      this.OutputTargetString = new NotifyProperty<String>(this.OutputActual.ToString("F3"));
      this.OutputActualString = new NotifyProperty<String>(this.OutputActual.ToString("F3"));
      this.StatusBackground = new NotifyProperty<SolidColorBrush>(new SolidColorBrush(Colors.White));
      this.ConsumerError = new NotifyProperty<String>(null);
    }
    #endregion

  }

}