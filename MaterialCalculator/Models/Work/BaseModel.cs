using System.Xml.Serialization;
using MaterialCalculator.Models.Island;

namespace MaterialCalculator.Models.Work {

  [XmlInclude(typeof(BuildingModel)), XmlInclude(typeof(SeparatorBuildingModel))]
  public abstract class BaseModel {

    #region Properties
    [XmlIgnore]
    public IslandModel Island { get; set; }
    #endregion

  }

}