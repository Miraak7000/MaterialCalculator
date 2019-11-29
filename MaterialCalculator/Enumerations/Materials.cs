using MaterialCalculator.Attributes;

namespace MaterialCalculator.Enumerations {

  public enum Materials {
    [LocalizedDescription(typeof(Materials), "Wood"), Image("icon_wood_log.png")]
    Wood,
    [LocalizedDescription(typeof(Materials), "Timber"), Image("icon_wooden_planks.png")]
    Timber,
    [LocalizedDescription(typeof(Materials), "Coal"), Image("icon_coal.png")]
    Coal,
    [LocalizedDescription(typeof(Materials), "Iron"), Image("icon_iron.png")]
    Iron,
    [LocalizedDescription(typeof(Materials), "Steel"), Image("icon_steel.png")]
    Steel,
    [LocalizedDescription(typeof(Materials), "SteelBeams"), Image("icon_beams.png")]
    SteelBeams,
    [LocalizedDescription(typeof(Materials), "QuartzSand"), Image("icon_quartz_sand.png")]
    QuartzSand,
    [LocalizedDescription(typeof(Materials), "Glass"), Image("icon_glass.png")]
    Glass,
    [LocalizedDescription(typeof(Materials), "Windows"), Image("icon_glass_window_3.png")]
    Windows,
    [LocalizedDescription(typeof(Materials), "Glasses"), Image("icon_glasses.png")]
    Glasses,
    [LocalizedDescription(typeof(Materials), "Filaments"), Image("icon_carbon_filament.png")]
    Filaments,
    [LocalizedDescription(typeof(Materials), "LightBulbs"), Image("icon_light_bulb - Copy.png")]
    LightBulbs,
    [LocalizedDescription(typeof(Materials), "Caoutchouc"), Image("icon_caoutchouc.png")]
    Caoutchouc,
    [LocalizedDescription(typeof(Materials), "Chassis"), Image("icon_chassis.png")]
    Chassis
  }

}