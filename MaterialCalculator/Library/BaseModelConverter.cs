using System;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Models.Work;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MaterialCalculator.Library {

  public class BaseModelConverter : JsonConverter<BaseModel> {

    #region Properties
    public override Boolean CanRead {
      get { return true; }
    }
    public override Boolean CanWrite {
      get { return true; }
    }
    #endregion

    #region Public Methods
    public override BaseModel ReadJson(JsonReader reader, Type objectType, BaseModel existingValue, Boolean hasExistingValue, JsonSerializer serializer) {
      var json = JObject.Load(reader);
      var className = (String)json["$type"];
      var islandID = (Guid)json[nameof(BaseModel.IslandID)];
      Buildings building;
      switch (className) {
        case nameof(SeparatorModel):
          var separatorModel = new SeparatorModel(islandID);
          return separatorModel;
        case nameof(WorkModelGroup):
          building = Enum.Parse<Buildings>((String)json[nameof(WorkModel.Building)]);
          var workModelGroup = new WorkModelGroup(islandID, building);
          JsonConvert.PopulateObject($"{json}", workModelGroup);
          return workModelGroup;
        case nameof(WorkModelProduction):
          building = Enum.Parse<Buildings>((String)json[nameof(WorkModel.Building)]);
          var workModelProduction = new WorkModelProduction(islandID, building);
          JsonConvert.PopulateObject($"{json}", workModelProduction);
          return workModelProduction;
        case nameof(WorkModelReference):
          building = Enum.Parse<Buildings>((String)json[nameof(WorkModel.Building)]);
          var workModelReference = new WorkModelReference(islandID, building);
          JsonConvert.PopulateObject($"{json}", workModelReference);
          return workModelReference;
        default:
          throw new ArgumentOutOfRangeException(className);
      }
    }
    public override void WriteJson(JsonWriter writer, BaseModel value, JsonSerializer serializer) {
      var json = JObject.FromObject(value, new JsonSerializer { ContractResolver = new WritablePropertiesOnlyResolver() });
      switch (value) {
        case SeparatorModel model:
          json.AddFirst(new JProperty(nameof(BaseModel.IslandID), value.IslandID));
          json.AddFirst(new JProperty("$type", nameof(SeparatorModel)));
          break;
        case WorkModelGroup model:
          json.AddFirst(new JProperty(nameof(WorkModel.Building), $"{model.Building.Type}"));
          json.AddFirst(new JProperty(nameof(BaseModel.IslandID), value.IslandID));
          json.AddFirst(new JProperty("$type", nameof(WorkModelGroup)));
          break;
        case WorkModelProduction model:
          json.AddFirst(new JProperty(nameof(WorkModel.Building), $"{model.Building.Type}"));
          json.AddFirst(new JProperty(nameof(BaseModel.IslandID), value.IslandID));
          json.AddFirst(new JProperty("$type", nameof(WorkModelProduction)));
          break;
        case WorkModelReference model:
          json.AddFirst(new JProperty(nameof(WorkModel.Building), $"{model.Building.Type}"));
          json.AddFirst(new JProperty(nameof(BaseModel.IslandID), value.IslandID));
          json.AddFirst(new JProperty("$type", nameof(WorkModelReference)));
          break;
        default:
          throw new ArgumentOutOfRangeException(value.GetType().FullName);
      }
      json.WriteTo(writer);
    }
    #endregion

  }

}