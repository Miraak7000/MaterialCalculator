using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;
using MaterialCalculator.Models.Island;
using MaterialCalculator.Models.Main;
using MaterialCalculator.Models.Work;

// ReSharper disable ClassNeverInstantiated.Global
namespace MaterialCalculator.DesignTime {

  public class IslandDesignTimeModel {

    #region Properties
    public IEnumerable<BaseModel> IslandItems {
      get { return MainWindow.ApplicationModel.IslandItems; }
    }
    #endregion

    #region Constructor
    public IslandDesignTimeModel() {
      var island = new IslandModel { Name = new NotifyProperty<String>("Example Island 1") };
      MainWindow.ApplicationModel = new ApplicationModel();
      MainWindow.ApplicationModel.Islands.Add(island);
      MainWindow.ApplicationModel.IslandItems.Add(new WorkModelProduction(island.ID, Enumerations.Buildings.Lumberjack));
      MainWindow.ApplicationModel.IslandItems.Add(new WorkModelProduction(island.ID, Enumerations.Buildings.Sawmill));
      MainWindow.ApplicationModel.IslandItems.Add(
        new WorkModelGroup(island.ID, Enumerations.Buildings.CabAssemblyLine) {
          InputBuildings = new ObservableCollection<BaseModel> {
            new WorkModelGroup(island.ID, Enumerations.Buildings.Coachmakers) {
              InputBuildings = new ObservableCollection<BaseModel> {
                new WorkModelProduction(island.ID, Buildings.Lumberjack),
                new WorkModelProduction(island.ID, Buildings.CaoutchoucPlantation)
              }
            },
            new WorkModelGroup(island.ID, Enumerations.Buildings.MotorAssemblyLine) {
              InputBuildings = new ObservableCollection<BaseModel> {
                new WorkModelProduction(island.ID, Buildings.Furnace),
                new WorkModelProduction(island.ID, Buildings.BrassSmeltery)
              }
            }
          }
        }
      );
    }
    #endregion

  }

}