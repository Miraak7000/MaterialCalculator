using System.Xml.Serialization;
using MaterialCalculator.Models.Island;

namespace MaterialCalculator.Models.Work {

  [XmlInclude(typeof(WorkModel)), XmlInclude(typeof(GroupModel)), XmlInclude(typeof(SeparatorModel))]
  public abstract class BaseModel {

    #region Properties
    [XmlIgnore]
    public IslandModel Island { get; set; }
    #endregion

  }

}