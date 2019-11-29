using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using MaterialCalculator.Library;

// ReSharper disable CollectionNeverQueried.Global
namespace MaterialCalculator.Models {

  public class IslandModel {

    #region Properties
    public NotifyProperty<String> Name { get; set; }
    public ObservableCollection<BuildingModel> Buildings { get; }
    #endregion

    #region Constructor
    public IslandModel() {
      this.Name = new NotifyProperty<String>(String.Empty);
      this.Buildings = new ObservableCollection<BuildingModel>();
    }
    #endregion

    #region Public Methods
    public void Init() {
      foreach (var building in this.Buildings) {
        building.Island = this;
        building.Init();
      }
    }
    public void Calculate() {
      foreach (var building in this.Buildings.OfType<ProductionBuildingModel>()) {
        building.OutputTargetString.Value = Math.Abs(building.OutputTarget) < 0.1 ? String.Empty : building.OutputTarget.ToString("F3");
        building.OutputActualString.Value = building.OutputActual.ToString("F3");
        building.StatusBackground.Value = new SolidColorBrush(Colors.White);
        building.ConsumerError.Value = null;
        foreach (var input in building.Production.Inputs) {
          var suppliers = this.Buildings.OfType<ProductionBuildingModel>().Where(w => w.Production.Output == input).ToArray();
          if (suppliers.Sum(s => s.OutputActual) < building.OutputActual) {
            building.StatusBackground.Value = new SolidColorBrush(Colors.LightPink);
            building.ConsumerError.Value = suppliers.ConcatByElement(c => c.BuildingDescription, Environment.NewLine);
          }
        }
        var consumers = this.Buildings.OfType<ProductionBuildingModel>().Where(w => w.Production.Inputs.Contains(building.Production.Output)).ToArray();
        if (consumers.Sum(s => s.OutputActual) > building.OutputActual) {
          building.StatusBackground.Value = new SolidColorBrush(Colors.LightPink);
          building.ConsumerError.Value = consumers.ConcatByElement(c => c.BuildingDescription, Environment.NewLine);
        }
      }
    }
    #endregion

  }

}