using System;
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
        new WorkModelProduction(Guid.Empty, Enumerations.Buildings.Lumberjack),
        new WorkModelProduction(Guid.Empty, Enumerations.Buildings.Sawmill),
        new WorkModelGroup(Guid.Empty, Enumerations.Buildings.CabAssemblyLine) {
          InputBuildings = new ObservableCollection<WorkModel> {
            new WorkModelProduction(Guid.Empty, Enumerations.Buildings.Coachmakers),
            new WorkModelProduction(Guid.Empty, Enumerations.Buildings.MotorAssemblyLine)
          }
        }
      };
    }
    #endregion

  }

}