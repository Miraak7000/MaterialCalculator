﻿using System;
using System.Windows;
using System.Windows.Controls;
using MaterialCalculator.Models.Create;

namespace MaterialCalculator.Library {

  public class CreateTemplateSelector : DataTemplateSelector {

    #region Public Methods
    public override DataTemplate SelectTemplate(Object item, DependencyObject container) {
      if (container is FrameworkElement element && item is CreateModel) {
        switch (item) {
          case CreateProductionModel _:
            return element.FindResource("ProductionTemplate") as DataTemplate;
          case CreateReferenceModel _:
            return element.FindResource("ReferenceTemplate") as DataTemplate;
        }
      }
      return null;
    }
    #endregion

  }

}