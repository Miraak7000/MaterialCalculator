using System.Collections.ObjectModel;
using MaterialCalculator.Models.Work;

// ReSharper disable ClassNeverInstantiated.Global
namespace MaterialCalculator.DesignTime {

  public class IslandDesignTimeModel {

    #region Properties
    public ObservableCollection<BuildingModel> Buildings { get; set; }
    #endregion

    #region Constructor
    public IslandDesignTimeModel() {
      this.Buildings = new ObservableCollection<BuildingModel> {
        new ProductionBuildingModel(Enumerations.Buildings.Lumberjack),
        new ProductionBuildingModel(Enumerations.Buildings.Sawmill),
        new GroupBuildingModel {
          InputBuildings = new ObservableCollection<BuildingModel> {
            new ProductionBuildingModel(Enumerations.Buildings.Coachmakers),
            new ProductionBuildingModel(Enumerations.Buildings.MotorAssemblyLine)
          },
          FinalBuilding = Enumerations.Buildings.CabAssemblyLine
        }
      };
    }
    #endregion

  }

}