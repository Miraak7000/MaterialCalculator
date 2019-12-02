using System;
using System.Collections.ObjectModel;
using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Models.Work {

  public class GroupModel : BaseModel {

    #region Properties
    public ObservableCollection<WorkModel> InputBuildings { get; set; }
    public Buildings FinalBuilding { get; set; }
    #endregion

    #region Constructor
    public GroupModel() {
      this.InputBuildings = new ObservableCollection<WorkModel>();
    }
    #endregion

  }

}