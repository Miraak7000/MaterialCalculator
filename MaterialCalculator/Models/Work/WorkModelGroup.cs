using System;
using System.Collections.ObjectModel;
using System.Linq;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;
using Newtonsoft.Json;

namespace MaterialCalculator.Models.Work {

  public class WorkModelGroup : WorkModel {

    #region Properties
    public ObservableCollection<BaseModel> InputBuildings { get; set; }
    [JsonConverter(typeof(NotifyPropertyConverter<Int32>))]
    public NotifyProperty<Int32> NumberOfBuildings { get; set; }
    [JsonConverter(typeof(NotifyPropertyConverter<Int32>))]
    public NotifyProperty<Int32> Productivity { get; set; }
    public override Double OutputTarget { get; }
    public override Double OutputActual { get; }
    #endregion

    #region Constructor
    public WorkModelGroup(Guid islandID, Buildings building) : base(islandID, building) {
      this.InputBuildings = new ObservableCollection<BaseModel>();
      this.NumberOfBuildings = new NotifyProperty<Int32>(1);
      this.Productivity = new NotifyProperty<Int32>(100);
      foreach (var input in this.Building.Inputs) {
        this.InputBuildings.Add(new WorkModelProduction(islandID, BuildingCollection.Items.Where(w => w.Output.Type == input.Type).Select(s => s.Type).First()));
      }
    }
    #endregion

    #region Public Methods
    public override void Init() {
      //throw new NotImplementedException();
    }
    #endregion

  }

}