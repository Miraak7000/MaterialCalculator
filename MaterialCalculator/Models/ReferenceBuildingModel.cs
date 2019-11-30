using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace MaterialCalculator.Models {

  public class ReferenceBuildingModel : BuildingModel {

    #region Properties
    public Guid ReferenceID { get; set; }
    public String ReferenceName {
      get {
        var applicationModel = ((MainWindow)Application.Current.MainWindow)?.Model.Value;
        var name = applicationModel?.Islands.Where(w => w.ID == this.ReferenceID).Select(s => s.Name.Value).SingleOrDefault();
        return name;
      }
    }
    public override Double OutputTarget {
      get {
        var consumers = this.Island.Buildings.OfType<ProductionBuildingModel>().Where(w => w.Production.Inputs.Contains(this.Production.Output)).ToArray();
        return consumers.Sum(s => s.OutputActual);
      }
    }
    public override Double OutputActual {
      get {
        var applicationModel = ((MainWindow)Application.Current.MainWindow)?.Model.Value;
        if (applicationModel == null) return 0;
        var buildings = applicationModel.Islands.Where(w => w.ID == this.ReferenceID).SelectMany(s => s.Buildings).OfType<ProductionBuildingModel>().Where(w => w.Production.Output == this.Production.Output).ToArray();
        var output = buildings.Sum(s => s.OutputActual);
        return output;
      }
    }
    #endregion

    #region Constructor
    // ReSharper disable once UnusedMember.Local
    // needs to stay for deserializing
    private ReferenceBuildingModel() {
    }
    public ReferenceBuildingModel(Buildings building) {
      this.Building = building;
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