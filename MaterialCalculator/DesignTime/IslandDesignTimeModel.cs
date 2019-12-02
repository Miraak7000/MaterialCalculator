using System.Collections.ObjectModel;
using MaterialCalculator.Models.Work;

// ReSharper disable ClassNeverInstantiated.Global
namespace MaterialCalculator.DesignTime {

  public class IslandDesignTimeModel {

    #region Properties
    public ObservableCollection<BaseModel> Buildings { get; set; }
    #endregion

    #region Constructor
    public IslandDesignTimeModel() {
      this.Buildings = new ObservableCollection<BaseModel> {
        new WorkProductionModel(Enumerations.Buildings.Lumberjack),
        new WorkProductionModel(Enumerations.Buildings.Sawmill),
        new GroupModel {
          InputBuildings = new ObservableCollection<WorkModel> {
            new WorkProductionModel(Enumerations.Buildings.Coachmakers),
            new WorkProductionModel(Enumerations.Buildings.MotorAssemblyLine)
          },
          FinalBuilding = Enumerations.Buildings.CabAssemblyLine
        }
      };
    }
    #endregion

  }

}