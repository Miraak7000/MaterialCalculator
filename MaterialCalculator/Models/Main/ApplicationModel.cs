using System.Collections.ObjectModel;
using MaterialCalculator.Library;
using MaterialCalculator.Models.Island;
using MaterialCalculator.Models.Work;
using Newtonsoft.Json;

namespace MaterialCalculator.Models.Main {

  public class ApplicationModel {

    #region Properties
    [JsonRequired]
    public ObservableCollection<IslandModel> Islands { get; }
    [JsonRequired]
    public ObservableCollection<BaseModel> IslandItems { get; }
    public NotifyProperty<IslandModel> SelectedIsland { get; }
    #endregion

    #region Constructor
    public ApplicationModel() {
      this.Islands = new ObservableCollection<IslandModel>();
      this.IslandItems = new ObservableCollection<BaseModel>();
      this.SelectedIsland = new NotifyProperty<IslandModel>(null);
    }
    #endregion

  }

}