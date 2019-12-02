using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows.Media;
using MaterialCalculator.Attributes;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;
using MaterialCalculator.Models.Work;

// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CollectionNeverQueried.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
namespace MaterialCalculator.Models.Island {

  public class IslandModel {

    #region Properties
    public Guid ID { get; set; }
    public NotifyProperty<String> Name { get; set; }
    public ObservableCollection<BaseModel> Buildings { get; }
    #endregion

    #region Constructor
    public IslandModel() {
      this.ID = Guid.NewGuid();
      this.Name = new NotifyProperty<String>(String.Empty);
      this.Buildings = new ObservableCollection<BaseModel>();
    }
    #endregion

    #region Public Methods
    public void Init() {
      foreach (var building in this.Buildings) {
        building.Island = this;
      }
      foreach (var building in this.Buildings.OfType<WorkModel>()) {
        building.Init();
      }
    }
    public void Calculate() {
      foreach (var building in this.Buildings.OfType<WorkModel>()) {
        building.OutputTargetString.Value = Math.Abs(building.OutputTarget) < 0.1 ? String.Empty : building.OutputTarget.ToString("F3");
        building.OutputActualString.Value = building.OutputActual.ToString("F3");
        building.StatusBackground.Value = new SolidColorBrush(Colors.White);
        building.ConsumerError.Value = null;
        if (building is WorkProductionModel) {
          // check for inputs
          var errors = new List<String>();
          foreach (var input in building.Production.Inputs) {
            var suppliers = this.Buildings.OfType<WorkModel>().Where(w => w.Production != null && w.Production.Output == input).ToArray();
            if (suppliers.Sum(s => s.OutputActual) < building.OutputActual) {
              building.StatusBackground.Value = new SolidColorBrush(Colors.LightPink);
              if (suppliers.Length == 0) {
                foreach (var item in Enum.GetNames(typeof(Buildings))) {
                  if (typeof(Buildings).GetField(item).GetCustomAttribute<ProductionAttribute>(false).Output == input) {
                    errors.Add(typeof(Materials).GetField(input.ToString()).GetCustomAttribute<LocalizedDescriptionAttribute>(false).Value);
                  }
                }
              } else {
                errors.AddRange(suppliers.Select(s => s.MaterialDescription));
              }
            }
          }
          if (errors.Count > 0) {
            building.ConsumerError.Value = errors.Distinct().ConcatByElement(c => c, Environment.NewLine);
          }
        }
        // check for consumers
        var output = this.Buildings.OfType<WorkModel>().Where(w => w.Production != null && w.Production.Output == building.Production.Output).Sum(s => s.OutputActual);
        var consumers = this.Buildings.OfType<WorkProductionModel>().Where(w => w.Production.Inputs.Contains(building.Production.Output)).ToArray();
        if (consumers.Sum(s => s.OutputActual) > output) {
          building.StatusBackground.Value = new SolidColorBrush(Colors.LightPink);
          building.ConsumerError.Value = consumers.ConcatByElement(c => c.BuildingDescription, Environment.NewLine);
        }
      }
    }
    #endregion

  }

}