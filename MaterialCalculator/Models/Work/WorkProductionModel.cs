using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;

// ReSharper disable MemberCanBePrivate.Global
namespace MaterialCalculator.Models.Work {

  public class WorkProductionModel : WorkModel {

    #region Properties
    public NotifyProperty<Int32> NumberOfBuildings { get; set; }
    public NotifyProperty<Int32> Productivity { get; set; }
    public override Double OutputTarget {
      get {
        var consumers = this.Island.Buildings.OfType<WorkProductionModel>().Where(w => w.Production.Inputs.Contains(this.Production.Output)).ToArray();
        return consumers.Sum(s => s.OutputActual);
      }
    }
    public override Double OutputActual {
      get { return 1D / this.Production.Duration * (this.Productivity.Value / 100D) * this.NumberOfBuildings.Value * 60; }
    }
    #endregion

    #region Constructor
    // ReSharper disable once UnusedMember.Local
    // needs to stay for deserializing
    private WorkProductionModel() {
    }
    public WorkProductionModel(Buildings building) : base(building) {
      this.NumberOfBuildings = new NotifyProperty<Int32>(1);
      this.Productivity = new NotifyProperty<Int32>(100);
    }
    #endregion

    #region Public Methods
    public override void Init() {
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