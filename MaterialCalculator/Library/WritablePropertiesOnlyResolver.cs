using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MaterialCalculator.Library {

  public class WritablePropertiesOnlyResolver : DefaultContractResolver {

    #region Protected Methods
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization) {
      var props = base.CreateProperties(type, memberSerialization);
      var result = props.Where(p => p.Writable || p.IsRequiredSpecified).ToList();
      return result;
    }
    #endregion

  }

}