using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Library {

  public static class BuildingCollection {

    #region Properties
    public static IEnumerable<Building> Items {
      get {
        if (BuildingCollection.Culture != CultureInfo.CurrentUICulture.TwoLetterISOLanguageName) {
          BuildingCollection.Culture = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
          BuildingCollection.BuildingItems = Enum.GetNames(typeof(Buildings)).Select(s => new Building(Enum.Parse<Buildings>(s))).OrderBy(o => o.Description).ToArray();
        }
        return BuildingCollection.BuildingItems;
      }
    }
    #endregion

    private static String Culture;
    private static Building[] BuildingItems;

    #region Constructor
    static BuildingCollection() {
      if (BuildingCollection.Culture == null) {
        BuildingCollection.Culture = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
      }
      if (BuildingCollection.BuildingItems == null || BuildingCollection.Culture != CultureInfo.CurrentUICulture.TwoLetterISOLanguageName) {
        BuildingCollection.BuildingItems = Enum.GetNames(typeof(Buildings)).Select(s => new Building(Enum.Parse<Buildings>(s))).OrderBy(o => o.Description).ToArray();
      }
    }
    #endregion

  }

}