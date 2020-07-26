using System;
using System.Linq;
using System.Windows.Media;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;
using MaterialCalculator.Models.Island;

namespace MaterialCalculator.Models.Work {

  public class WorkModelReference : WorkModel {

    #region Properties
    public Guid ReferenceID { get; set; }
    public IslandModel IslandReference {
      get {
        var island = MainWindow.ApplicationModel.Islands.SingleOrDefault(w => w.ID == this.ReferenceID);
        return island;
      }
    }
    public override Double OutputTarget {
      get {
        var consumers = MainWindow.ApplicationModel.IslandItems.OfType<WorkModelProduction>().Where(w => w.Building.Inputs.Contains(this.Building.Output)).ToArray();
        return consumers?.Sum(s => s.OutputActual) ?? 0;
      }
    }
    public override Double OutputActual {
      get {
        var buildings = MainWindow.ApplicationModel.IslandItems.OfType<WorkModelProduction>().Where(w => w.IslandID == this.ReferenceID && w.Building.Output == this.Building.Output).ToArray();
        var output = buildings.Sum(s => s.OutputActual);
        return output;
      }
    }
    #endregion

    #region Constructor
    public WorkModelReference(Guid islandID, Buildings building) : base(islandID, building) {
    }
    #endregion

    #region Public Methods
    public override void Init(BaseModel parent) {
      base.Init(parent);
      this.OutputTargetString = new NotifyProperty<String>(this.OutputActual.ToString("F3"));
      this.OutputActualString = new NotifyProperty<String>(this.OutputActual.ToString("F3"));
      this.StatusBackground = new NotifyProperty<SolidColorBrush>(new SolidColorBrush(Colors.White));
      this.ConsumerError = new NotifyProperty<String>(null);
    }
    #endregion

  }

}