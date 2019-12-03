using System;
using System.Windows.Media;
using System.Xml.Serialization;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;
using Newtonsoft.Json;

namespace MaterialCalculator.Models.Work {

  public abstract class WorkModel : BaseModel {

    #region Properties
    [JsonIgnore]
    public Building Building { get; }
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

  }

}