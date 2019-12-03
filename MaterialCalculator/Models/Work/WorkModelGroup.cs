using System;
using System.Collections.ObjectModel;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;
using Newtonsoft.Json;

namespace MaterialCalculator.Models.Work {

  public class WorkModelGroup : WorkModel {

    #region Properties
    public ObservableCollection<WorkModel> InputBuildings { get; set; }
    [JsonConverter(typeof(NotifyPropertyConverter<Int32>))]
    public NotifyProperty<Int32> NumberOfBuildings { get; set; }
    [JsonConverter(typeof(NotifyPropertyConverter<Int32>))]
    public NotifyProperty<Int32> Productivity { get; set; }
    public override Double OutputTarget { get; }
    public override Double OutputActual { get; }
    #endregion

    #region Constructor
    public WorkModelGroup(Guid islandID, Buildings building) : base(islandID, building) {
      this.InputBuildings = new ObservableCollection<WorkModel>();
      this.NumberOfBuildings = new NotifyProperty<Int32>(1);
      this.Productivity = new NotifyProperty<Int32>(100);
    }
    #endregion

    #region Public Methods
    public override void Init() {
      throw new NotImplementedException();
    }
    #endregion

  }

}