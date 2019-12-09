using System;
using System.Collections.ObjectModel;
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
          building = Enum.Parse<Buildings>((String)json[nameof(WorkModelGroup.Building)]);
          var workModelGroup = new WorkModelGroup(islandID, building);
          workModelGroup.NumberOfBuildings = json[nameof(WorkModelGroup.NumberOfBuildings)].ToObject<NotifyProperty<Int32>>(serializer);
          workModelGroup.Productivity = json[nameof(WorkModelGroup.Productivity)].ToObject<NotifyProperty<Int32>>(serializer);
          workModelGroup.InputBuildings = json[nameof(WorkModelGroup.InputBuildings)].ToObject<ObservableCollection<BaseModel>>(serializer);
          return workModelGroup;
        case nameof(WorkModelProduction):
          building = Enum.Parse<Buildings>((String)json[nameof(WorkModelProduction.Building)]);
          var workModelProduction = new WorkModelProduction(islandID, building);
          workModelProduction.NumberOfBuildings = json[nameof(WorkModelProduction.NumberOfBuildings)].ToObject<NotifyProperty<Int32>>(serializer);
          workModelProduction.Productivity = json[nameof(WorkModelProduction.Productivity)].ToObject<NotifyProperty<Int32>>(serializer);
          return workModelProduction;
        case nameof(WorkModelReference):
          building = Enum.Parse<Buildings>((String)json[nameof(WorkModel.Building)]);
          var workModelReference = new WorkModelReference(islandID, building);
          workModelReference.ReferenceID = json[nameof(WorkModelReference.ReferenceID)].ToObject<Guid>(serializer);
          return workModelReference;
        default:
          throw new ArgumentOutOfRangeException(className);
      }
    }
    public override void WriteJson(JsonWriter writer, BaseModel value, JsonSerializer serializer) {
      var json = new JObject();
      switch (value) {
        case SeparatorModel model:
          json.Add(new JProperty("$type", nameof(SeparatorModel)));
          json.Add(new JProperty(nameof(SeparatorModel.IslandID), model.IslandID));
          break;
        case WorkModelGroup model:
          json.Add(new JProperty("$type", nameof(WorkModelGroup)));
          json.Add(new JProperty(nameof(WorkModelGroup.IslandID), model.IslandID));
          json.Add(new JProperty(nameof(WorkModelGroup.Building), $"{model.Building.Type}"));
          json.Add(new JProperty(nameof(WorkModelGroup.NumberOfBuildings), JToken.FromObject(model.NumberOfBuildings, serializer)));
          json.Add(new JProperty(nameof(WorkModelGroup.Productivity), JToken.FromObject(model.Productivity, serializer)));
          json.Add(new JProperty(nameof(WorkModelGroup.InputBuildings), JArray.FromObject(model.InputBuildings, serializer)));
          break;
        case WorkModelProduction model:
          json.Add(new JProperty("$type", nameof(WorkModelProduction)));
          json.Add(new JProperty(nameof(WorkModelProduction.IslandID), model.IslandID));
          json.Add(new JProperty(nameof(WorkModelProduction.Building), $"{model.Building.Type}"));
          json.Add(new JProperty(nameof(WorkModelProduction.NumberOfBuildings), JToken.FromObject(model.NumberOfBuildings, serializer)));
          json.Add(new JProperty(nameof(WorkModelProduction.Productivity), JToken.FromObject(model.Productivity, serializer)));
          break;
        case WorkModelReference model:
          json.Add(new JProperty("$type", nameof(WorkModelReference)));
          json.Add(new JProperty(nameof(WorkModelReference.IslandID), model.IslandID));
          json.Add(new JProperty(nameof(WorkModelReference.Building), $"{model.Building.Type}"));
          json.Add(new JProperty(nameof(WorkModelReference.ReferenceID), model.ReferenceID));
          break;
        default:
          throw new ArgumentOutOfRangeException(value.GetType().FullName);
      }
      json.WriteTo(writer);
    }
    #endregion

  }

}