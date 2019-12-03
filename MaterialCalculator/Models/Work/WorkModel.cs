using System;
using System.Linq;
using System.Windows.Media;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;

namespace MaterialCalculator.Models.Work {

  public abstract class WorkModel : BaseModel {

    #region Properties
    public Building Building { get; }
    public Int32 Depth {
      get {
        var groups = MainWindow.ApplicationModel.IslandItems.Where(w => w.IslandID == this.IslandID).OfType<WorkModelGroup>();
        foreach (var group in groups) {
          var result = this.GetDepth(group, 1);
          if (result > 0) return result;
        }
        return 0;
      }
    }
    public abstract Double OutputTarget { get; }
    public abstract Double OutputActual { get; }
    public NotifyProperty<String> OutputTargetString { get; protected set; }
    public NotifyProperty<String> OutputActualString { get; protected set; }
    public NotifyProperty<SolidColorBrush> StatusBackground { get; protected set; }
    public NotifyProperty<String> ConsumerError { get; protected set; }
    #endregion

    #region Constructor
    protected WorkModel(Guid islandID, Buildings building) : base(islandID) {
      this.Building = new Building(building);
    }
    #endregion

    #region Public Methods
    public abstract void Init();
    #endregion

    #region Private Methods
    private Int32 GetDepth(WorkModelGroup item, Int32 depth) {
      foreach (var input in item.InputBuildings) {
        if (input == this) return depth;
      }
      foreach (var group in item.InputBuildings.OfType<WorkModelGroup>()) {
        var result = this.GetDepth(group, depth + 1);
        if (result > 0) return result;
      }
      return 0;
    }
    #endregion

  }

}