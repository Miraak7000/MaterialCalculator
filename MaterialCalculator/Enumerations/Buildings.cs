using MaterialCalculator.Attributes;

// ReSharper disable UnusedMember.Global
namespace MaterialCalculator.Enumerations {

  public enum Buildings {
    [Building(Materials.Wood, 15)]
    Lumberjack,
    [Building(Materials.Timber, 15, Materials.Wood)]
    Sawmill,
    [Building(Materials.Coal, 15)]
    CoalMine,
    [Building(Materials.Iron, 15)]
    IronMine,
    [Building(Materials.Steel, 30, Materials.Coal, Materials.Iron)]
    Furnace,
    [Building(Materials.SteelBeams, 45, Materials.Steel)]
    Steelworks,
    [Building(Materials.QuartzSand, 30)]
    SandMine,
    [Building(Materials.Glass, 30, Materials.QuartzSand)]
    Glassmakers,
    [Building(Materials.Windows, 60, Materials.Wood, Materials.Glass)]
    WindowMakers,
    [Building(Materials.Glasses, 90, Materials.Wood, Materials.Glass)]
    SpectacleFactory,
    [Building(Materials.Filaments, 60, Materials.Coal)]
    FilamentFactory,
    [Building(Materials.LightBulbs, 60, Materials.Glass, Materials.Filaments)]
    LightBulbFactory,
    [Building(Materials.Coal, 30)]
    CharcoalKiln,
    [Building(Materials.Caoutchouc, 60)]
    CaoutchoucPlantation,
    [Building(Materials.Chassis, 120, Materials.Wood, Materials.Caoutchouc)]
    Coachmakers,
    [Building(Materials.Zinc, 30)]
    ZincMine,
    [Building(Materials.Copper, 30)]
    CopperMine,
    [Building(Materials.Brass, 60, Materials.Zinc, Materials.Copper)]
    BrassSmeltery,
    [Building(Materials.SteamMotors, 45, Materials.Steel, Materials.Brass)]
    MotorAssemblyLine,
    [Building(Materials.SteamCarriages, 30, Materials.Chassis, Materials.SteamMotors)]
    CabAssemblyLine,
    [Building(Materials.WoodVeneers, 60, Materials.Wood)]
    MarquetryWorkshop,
    [Building(Materials.Gramophones, 60, Materials.WoodVeneers, Materials.Brass)]
    GramophoneFactory,
    [Building(Materials.Grapes, 120)]
    Vineyard,
    [Building(Materials.Champagne, 30, Materials.Grapes, Materials.Glass)]
    ChampagneCellar,
    [Building(Materials.CoffeeBeans, 60)]
    CoffeePlantation,
    [Building(Materials.Coffee, 30, Materials.CoffeeBeans)]
    CoffeeRoaster,
    [Building(Materials.GoldOre, 150)]
    GoldMine
  }

}