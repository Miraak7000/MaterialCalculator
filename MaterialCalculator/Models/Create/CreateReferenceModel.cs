using System.Collections.Generic;
using System.Linq;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Models.Island;
using MaterialCalculator.Models.Work;

namespace MaterialCalculator.Models.Create {

  public class CreateReferenceModel : CreateModel {

    #region Properties
    public IEnumerable<IslandModel> Islands {
      get {
        var islandIDs = MainWindow.ApplicationModel.IslandItems.OfType<WorkModelProduction>().Where(w => w.IslandID != MainWindow.ApplicationModel.SelectedIsland.Value.ID && w.Building.Type == this.Building).Select(s => s.IslandID).Distinct();
        return MainWindow.ApplicationModel.Islands.Where(w => islandIDs.Contains(w.ID));
      }
    }
    public IslandModel SelectedIsland { get; set; }
    #endregion

    #region Constructor
    public CreateReferenceModel(Buildings building) : base(building) {
    }
    #endregion

  }

}