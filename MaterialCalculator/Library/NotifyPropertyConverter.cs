using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MaterialCalculator.Library {

  public class NotifyPropertyConverter<T> : JsonConverter<NotifyProperty<T>> {

    #region Properties
    public override Boolean CanRead {
      get { return true; }
    }
    public override Boolean CanWrite {
      get { return true; }
    }
    #endregion

    #region Public Methods
    public override NotifyProperty<T> ReadJson(JsonReader reader, Type objectType, NotifyProperty<T> existingValue, Boolean hasExistingValue, JsonSerializer serializer) {
      var json = JToken.Load(reader);
      var result = (T)Convert.ChangeType(json, typeof(T));
      return new NotifyProperty<T>(result);
    }
    public override void WriteJson(JsonWriter writer, NotifyProperty<T> value, JsonSerializer serializer) {
      var json = new JValue(value.Value);
      json.WriteTo(writer);
    }
    #endregion

  }

}