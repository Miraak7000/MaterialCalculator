using System;
using System.Windows;
using System.Windows.Controls;
using MaterialCalculator.Models.Work;

namespace MaterialCalculator.Library {

  public class BuildingTemplateSelector : DataTemplateSelector {

    #region Public Methods
    public override DataTemplate SelectTemplate(Object item, DependencyObject container) {
      if (container is FrameworkElement element && item is BaseModel) {
        switch (item) {
          case ProductionBuildingModel _:
            return element.FindResource("ProductionTemplate") as DataTemplate;
          case ReferenceBuildingModel _:
            return element.FindResource("ReferenceTemplate") as DataTemplate;
          case SeparatorBuildingModel _:
            return element.FindResource("SeparatorTemplate") as DataTemplate;
          case GroupBuildingModel _:
            return element.FindResource("GroupTemplate") as DataTemplate;
        }
      }
      return null;
    }
    #endregion

  }

}