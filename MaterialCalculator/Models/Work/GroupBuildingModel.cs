using System;
using System.Collections.ObjectModel;
using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Models.Work {

  public class GroupBuildingModel : BuildingModel {

    #region Properties
    public ObservableCollection<BuildingModel> InputBuildings { get; set; }
    public Buildings FinalBuilding { get; set; }
    public override Double OutputTarget {
      get { return 0; }
    }
    public override Double OutputActual {
      get { return 0; }
    }
    #endregion

    #region Constructor
    public GroupBuildingModel() {
      this.InputBuildings = new ObservableCollection<BuildingModel>();
    }
    #endregion

    #region Public Methods
    public override void Init() {
    }
    #endregion

  }

}