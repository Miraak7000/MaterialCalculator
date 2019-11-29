using System;
using System.Collections.ObjectModel;

namespace MaterialCalculator.Models {

  public class ApplicationModel {

    #region Properties
    public String WindowTitle { get; }
    public ObservableCollection<IslandModel> Islands { get; }
    #endregion

    #region Constructor
    public ApplicationModel() {
      this.WindowTitle = "Anno 1800 - Material Calculator";
      this.Islands = new ObservableCollection<IslandModel>();
    }
    #endregion

  }

}