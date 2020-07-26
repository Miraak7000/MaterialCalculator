using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

// ReSharper disable MemberCanBePrivate.Global
namespace MaterialCalculator.Models.Work {

  public class WorkModelProduction : WorkModel {

    #region Properties
    [JsonConverter(typeof(NotifyPropertyConverter<Int32>))]
    public NotifyProperty<Int32> NumberOfBuildings { get; set; }
    [JsonConverter(typeof(NotifyPropertyConverter<Int32>))]
    public NotifyProperty<Int32> Productivity { get; set; }
    public override Double OutputTarget {
      get {
        var consumers = MainWindow.ApplicationModel.IslandItems.OfType<WorkModelProduction>().Where(w => w.Building.Inputs.Contains(this.Building.Output)).ToArray();
        return consumers?.Sum(s => s.OutputActual) ?? 0;
      }
    }
    public override Double OutputActual {
      get { return 1D / this.Building.Duration * (this.Productivity.Value / 100D) * this.NumberOfBuildings.Value * 60; }
    }
    #endregion

    #region Constructor
    public WorkModelProduction(Guid islandID, Buildings building) : base(islandID, building) {
      this.NumberOfBuildings = new NotifyProperty<Int32>(1);
      this.Productivity = new NotifyProperty<Int32>(100);
    }
    #endregion

    #region Public Methods
    public override void Init(BaseModel parent) {
      base.Init(parent);
      this.OutputTargetString = new NotifyProperty<String>(this.OutputActual.ToString("F3"));
      this.OutputActualString = new NotifyProperty<String>(this.OutputActual.ToString("F3"));
      this.StatusBackground = new NotifyProperty<SolidColorBrush>(new SolidColorBrush(Colors.White));
      this.ConsumerError = new NotifyProperty<String>(null);
      this.NumberOfBuildings.PropertyChanged += this.Calculation_PropertyChanged;
      this.Productivity.PropertyChanged += this.Calculation_PropertyChanged;
    }
    #endregion

    #region Events
    private void Calculation_PropertyChanged(Object sender, PropertyChangedEventArgs e) {
      this.Island?.Calculate();
    }
    #endregion

  }

}