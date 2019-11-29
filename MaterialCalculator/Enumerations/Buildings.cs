using MaterialCalculator.Attributes;

namespace MaterialCalculator.Enumerations {

  public enum Buildings {
    [Production(Materials.Wood, 15), LocalizedDescription(typeof(Buildings), "Lumberjack")]
    Lumberjack,
    [Production(Materials.Timber, 15, Materials.Wood), LocalizedDescription(typeof(Buildings), "Sawmill")]
    Sawmill,
    [Production(Materials.Coal, 15), LocalizedDescription(typeof(Buildings), "CoalMine")]
    CoalMine,
    [Production(Materials.Iron, 15), LocalizedDescription(typeof(Buildings), "IronMine")]
    IronMine,
    [Production(Materials.Steel, 30, Materials.Coal, Materials.Iron), LocalizedDescription(typeof(Buildings), "Furnace")]
    Furnace,
    [Production(Materials.SteelBeams, 45, Materials.Steel), LocalizedDescription(typeof(Buildings), "Steelworks")]
    Steelworks,
    [Production(Materials.QuartzSand, 30), LocalizedDescription(typeof(Buildings), "SandMine")]
    SandMine,
    [Production(Materials.Glass, 30, Materials.QuartzSand), LocalizedDescription(typeof(Buildings), "Glassmakers")]
    Glassmakers,
    [Production(Materials.Windows, 60, Materials.Wood, Materials.Glass), LocalizedDescription(typeof(Buildings), "WindowMakers")]
    WindowMakers,
    [Production(Materials.Glasses, 90, Materials.Wood, Materials.Glass), LocalizedDescription(typeof(Buildings), "SpectacleFactory")]
    SpectacleFactory,
    [Production(Materials.Filaments, 60, Materials.Coal), LocalizedDescription(typeof(Buildings), "FilamentFactory")]
    FilamentFactory,
    [Production(Materials.LightBulbs, 60, Materials.Glass, Materials.Filaments), LocalizedDescription(typeof(Buildings), "LightBulbFactory")]
    LightBulbFactory,
    [Production(Materials.Coal, 30), LocalizedDescription(typeof(Buildings), "CharcoalKiln")]
    CharcoalKiln,
    [Production(Materials.Caoutchouc, 60), LocalizedDescription(typeof(Buildings), "CaoutchoucPlantation")]
    CaoutchoucPlantation,
    [Production(Materials.Chassis, 120, Materials.Wood, Materials.Caoutchouc), LocalizedDescription(typeof(Buildings), "Coachmakers")]
    Coachmakers
  }

}