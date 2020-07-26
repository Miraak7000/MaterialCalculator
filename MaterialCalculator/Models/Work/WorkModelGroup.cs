using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
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
    public Visibility ContextMenuVisibility {
      get { return this.InputBuildings.OfType<WorkModelGroup>().Any() ? Visibility.Collapsed : Visibility.Visible; }
    }
    public IEnumerable<Building> PossibleProductionBuildings {
      get {
        var buildings = BuildingCollection.Items.Where(w => this.Building.Inputs.Contains(w.Output));
        return buildings;
      }
    }
    public override Double OutputTarget { get; }
    public override Double OutputActual { get; }
    #endregion

    #region Constructor
    public WorkModelGroup(Guid islandID, Buildings building) : base(islandID, building) {
      this.InputBuildings = new ObservableCollection<BaseModel>();
      this.NumberOfBuildings = new NotifyProperty<Int32>(1);
      this.Productivity = new NotifyProperty<Int32>(100);
      foreach (var input in this.Building.Inputs) {
        var buildings = BuildingCollection.Items.Where(w => w.Output.Type == input.Type);
        foreach (var item in buildings) {
          if (item.Inputs.Length == 0) {
            this.InputBuildings.Add(new WorkModelProduction(islandID, item.Type));
          } else {
            this.InputBuildings.Add(new WorkModelGroup(islandID, item.Type));
          }
        }
      }
    }
    #endregion

    #region Public Methods
    public override void Init(BaseModel parent) {
      base.Init(parent);
      foreach (var building in this.InputBuildings) {
        building.Init(this);
      }
    }
    #endregion

  }

}