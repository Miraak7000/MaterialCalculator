using System.Collections.ObjectModel;
using System.Xml.Serialization;
using MaterialCalculator.Library;

namespace MaterialCalculator.Models {

  public class ApplicationModel {

    #region Properties
    public ObservableCollection<IslandModel> Islands { get; }
    [XmlIgnore]
    public NotifyProperty<IslandModel> SelectedIsland { get; set; }
    #endregion

    #region Constructor
    public ApplicationModel() {
      this.Islands = new ObservableCollection<IslandModel>();
      this.SelectedIsland = new NotifyProperty<IslandModel>(null);
    }
    #endregion

  }

}