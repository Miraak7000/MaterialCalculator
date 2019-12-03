using System;
using System.Collections.ObjectModel;
using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Models.Work {

  public class WorkModelGroup : WorkModel {

    #region Properties
    public ObservableCollection<WorkModel> InputBuildings { get; set; }
    public override Double OutputTarget { get; }
    public override Double OutputActual { get; }
    #endregion

    #region Constructor
    public WorkModelGroup(Guid islandID, Buildings building) : base(islandID, building) {
      this.InputBuildings = new ObservableCollection<WorkModel>();
    }
    #endregion

    #region Public Methods
    public override void Init() {
      throw new NotImplementedException();
    }
    #endregion

  }

}