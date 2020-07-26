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
        var parent = this.Parent;
        var counter = 0;
        while (parent != null) {
          counter++;
          parent = parent.Parent;
        }
        return counter;
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

  }

}