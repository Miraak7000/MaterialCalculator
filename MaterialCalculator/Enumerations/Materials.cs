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
    Chassis,
    [LocalizedDescription(typeof(Materials), "Zinc"), Image("icon_tin_ore.png")]
    Zinc,
    [LocalizedDescription(typeof(Materials), "Copper"), Image("icon_copper.png")]
    Copper,
    [LocalizedDescription(typeof(Materials), "Brass"), Image("icon_brass.png")]
    Brass,
    [LocalizedDescription(typeof(Materials), "SteamMotors"), Image("icon_steam_machine.png")]
    SteamMotors,
    [LocalizedDescription(typeof(Materials), "SteamCarriages"), Image("icon_steam_carriage.png")]
    SteamCarriages,
    [LocalizedDescription(typeof(Materials), "WoodVeneers"), Image("icon_inlay.png")]
    WoodVeneers,
    [LocalizedDescription(typeof(Materials), "Gramophones"), Image("icon_phonographs - Copy.png")]
    Gramophones,
    [LocalizedDescription(typeof(Materials), "Grapes"), Image("icon_grapes.png")]
    Grapes,
    [LocalizedDescription(typeof(Materials), "Champagne"), Image("icon_champagne.png")]
    Champagne,
    [LocalizedDescription(typeof(Materials), "CoffeeBeans"), Image("icon_coffee_beans.png")]
    CoffeeBeans,
    [LocalizedDescription(typeof(Materials), "Coffee"), Image("icon_coffe_cup.png")]
    Coffee,
    [LocalizedDescription(typeof(Materials), "GoldOre"), Image("icon_gold_ore.png")]
    GoldOre
  }

}