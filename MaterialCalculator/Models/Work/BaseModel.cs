using System;
using System.Linq;
using MaterialCalculator.Models.Island;

namespace MaterialCalculator.Models.Work {

  public abstract class BaseModel {

    #region Properties
    public Guid IslandID { get; }
    public BaseModel Parent { get; private set; }
    protected IslandModel Island {
      get { return MainWindow.ApplicationModel.Islands.SingleOrDefault(w => w.ID == this.IslandID); }
    }
    #endregion

    #region Constructor
    protected BaseModel(Guid islandID) {
      this.IslandID = islandID;
    }
    #endregion

    #region Public Methods
    public virtual void Init(BaseModel parent) {
      this.Parent = parent;
    }
    #endregion

  }

}