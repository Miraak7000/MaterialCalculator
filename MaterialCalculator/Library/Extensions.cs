using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace MaterialCalculator.Library {

  public static class Extensions {

    #region Public Methods
    public static String ConcatByElement<TSource>(this IEnumerable<TSource> source, Func<TSource, String> predicate, String delimiter) {
      var sb = new StringBuilder();
      foreach (var item in source) {
        if (sb.Length > 0) sb.Append(delimiter);
        sb.Append(predicate.Invoke(item));
      }
      return sb.ToString();
    }
    public static T FindAnchestor<T>(this DependencyObject current) where T : DependencyObject {
      do {
        if (current is T dependencyObject) return dependencyObject;
        current = VisualTreeHelper.GetParent(current);
      } while (current != null);
      return null;
    }
    #endregion

  }

}