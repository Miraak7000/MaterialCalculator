using System;
using System.Linq;
using MaterialCalculator.Models.Island;

namespace MaterialCalculator.Models.Work {

  public abstract class BaseModel {

    #region Properties
    public Guid IslandID { get; }
    protected IslandModel Island {
      get { return MainWindow.ApplicationModel.Islands.SingleOrDefault(w => w.ID == this.IslandID); }
    }
    #endregion

    #region Constructor
    protected BaseModel(Guid islandID) {
      this.IslandID = islandID;
    }
    #endregion

  }

}