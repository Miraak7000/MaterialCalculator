using System.Collections.ObjectModel;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Models;

// ReSharper disable ClassNeverInstantiated.Global
namespace MaterialCalculator.DesignTime {

  public class IslandDesignTimeModel {

    #region Properties
    public ObservableCollection<ProductionBuildingModel> Buildings { get; set; }
    #endregion

    #region Constructor
    public IslandDesignTimeModel() {
      this.Buildings = new ObservableCollection<ProductionBuildingModel> {
        new ProductionBuildingModel(Enumerations.Buildings.Lumberjack),
        new ProductionBuildingModel(Enumerations.Buildings.Sawmill)
      };
    }
    #endregion

  }

}