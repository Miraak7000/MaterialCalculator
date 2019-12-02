using System;
using System.Windows;
using System.Windows.Controls;
using MaterialCalculator.Models.Create;

namespace MaterialCalculator.Library {

  public class CreateBuildingTemplateSelector : DataTemplateSelector {

    #region Public Methods
    public override DataTemplate SelectTemplate(Object item, DependencyObject container) {
      if (container is FrameworkElement element && item is CreateBuildingModel) {
        switch (item) {
          case CreateProductionBuildingModel _:
            return element.FindResource("ProductionTemplate") as DataTemplate;
          case CreateReferenceBuildingModel _:
            return element.FindResource("ReferenceTemplate") as DataTemplate;
        }
      }
      return null;
    }
    #endregion

  }

}