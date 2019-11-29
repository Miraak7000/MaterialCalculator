using System;
using System.Collections.Generic;
using System.Text;

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
    #endregion

  }

}