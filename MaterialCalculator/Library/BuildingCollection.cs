using System;
using System.Linq;
using MaterialCalculator.Enumerations;

namespace MaterialCalculator.Library {

  public static class BuildingCollection {

    #region Properties
    public static Building[] Items { get; }
    #endregion

    #region Constructor
    static BuildingCollection() {
      if (BuildingCollection.Items == null) {
        BuildingCollection.Items = Enum.GetNames(typeof(Buildings)).Select(s => new Building(Enum.Parse<Buildings>(s))).OrderBy(o => o.Description).ToArray();
      }
    }
    #endregion

  }

}