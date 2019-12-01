using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace MaterialCalculator.Models {

  public class SeparatorBuildingModel : BuildingModel {

    #region Properties
    public override Double OutputTarget {
      get { return 0; }
    }
    public override Double OutputActual {
      get { return 0; }
    }
    #endregion

    #region Constructor
    public SeparatorBuildingModel() {
    }
    #endregion

    #region Public Methods
    public override void Init() {
      //this.OutputTargetString = new NotifyProperty<String>(this.OutputActual.ToString("F3"));
      //this.OutputActualString = new NotifyProperty<String>(this.OutputActual.ToString("F3"));
      //this.StatusBackground = new NotifyProperty<SolidColorBrush>(new SolidColorBrush(Colors.White));
      //this.ConsumerError = new NotifyProperty<String>(null);
    }
    #endregion

  }

}