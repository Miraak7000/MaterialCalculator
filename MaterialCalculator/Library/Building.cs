﻿using System;
using System.Linq;
using System.Reflection;
using MaterialCalculator.Attributes;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Resources;

namespace MaterialCalculator.Library {

  public class Building {

    #region Properties
    public Buildings Type { get; }
    public String Description { get; }
    public Int32 Duration { get; }
    public Material Output { get; }
    public Material[] Inputs { get; }
    #endregion

    #region Constructor
    public Building(Buildings type) {
      var definition = typeof(Buildings).GetField($"{type}").GetCustomAttribute<BuildingAttribute>(false);
      this.Type = type;
      this.Description = typeof(Localization).GetProperties(BindingFlags.Public | BindingFlags.Static).SingleOrDefault(w => w.Name == $"{nameof(Buildings)}_{type}")?.GetValue(null, null) as String;
      this.Duration = definition.Duration;
      this.Output = new Material(definition.Output);
      this.Inputs = definition.Inputs.Select(material => new Material(material)).ToArray();
    }
    #endregion

  }

}