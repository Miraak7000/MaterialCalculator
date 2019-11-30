using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Models {

  public class CreateReferenceBuildingModel : CreateBuildingModel {

    #region Properties
    public IEnumerable<IslandModel> Islands {
      get {
        var applicationModel = ((MainWindow)Application.Current.MainWindow)?.Model.Value;
        var islands = applicationModel?.Islands.Where(w => w != applicationModel.SelectedIsland.Value && w.Buildings.OfType<ProductionBuildingModel>().Any(a => a.Building == this.Building));
        return islands;
      }
    }
    public IslandModel SelectedIsland { get; set; }
    #endregion

    #region Constructor
    public CreateReferenceBuildingModel(Buildings building) : base(building) {
    }
    #endregion

  }

}