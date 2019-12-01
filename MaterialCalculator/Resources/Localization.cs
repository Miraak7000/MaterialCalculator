﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;
using System.IO;

namespace MaterialCalculator.Resources {

  public static class Localization {

    #region Properties
    public static String MessageBox_Title {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("MessageBox")?.Element("Title")?.Value; }
    }
    public static String MessageBox_RemoveIsland {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("MessageBox")?.Element("RemoveIsland")?.Value; }
    }
    public static String MessageBox_RemoveBuilding {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("MessageBox")?.Element("RemoveBuilding")?.Value; }
    }
    public static String MessageBox_FileNotLoaded {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("MessageBox")?.Element("FileNotLoaded")?.Value; }
    }
    public static String MessageBox_FileNotSaved {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("MessageBox")?.Element("FileNotSaved")?.Value; }
    }
    //
    public static String Button_OK {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Button")?.Element("OK")?.Value; }
    }
    public static String Button_Cancel {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Button")?.Element("Cancel")?.Value; }
    }
    //
    public static String ApplicationWindow_Title {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("ApplicationWindow")?.Element("Title")?.Value; }
    }
    public static String ApplicationWindow_Load {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("ApplicationWindow")?.Element("Load")?.Value; }
    }
    public static String ApplicationWindow_Save {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("ApplicationWindow")?.Element("Save")?.Value; }
    }
    public static String ApplicationWindow_AddIsland {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("ApplicationWindow")?.Element("AddIsland")?.Value; }
    }
    public static String ApplicationWindow_RemoveIsland {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("ApplicationWindow")?.Element("RemoveIsland")?.Value; }
    }
    public static String ApplicationWindow_EditIsland {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("ApplicationWindow")?.Element("EditIsland")?.Value; }
    }
    //
    public static String AddIslandWindow_Title {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("AddIslandWindow")?.Element("Title")?.Value; }
    }
    public static String AddIslandWindow_Label {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("AddIslandWindow")?.Element("Label")?.Value; }
    }
    //
    public static String EditIslandWindow_Title {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("EditIslandWindow")?.Element("Title")?.Value; }
    }
    public static String EditIslandWindow_Label {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("EditIslandWindow")?.Element("Label")?.Value; }
    }
    //
    public static String AddBuildingWindow_Title {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("AddBuildingWindow")?.Element("Title")?.Value; }
    }
    public static String AddBuildingWindow_LabelWherePlaced {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("AddBuildingWindow")?.Element("LabelWherePlaced")?.Value; }
    }
    public static String AddBuildingWindow_ItemThisIsland {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("AddBuildingWindow")?.Element("ItemThisIsland")?.Value; }
    }
    public static String AddBuildingWindow_ItemAnotherIsland {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("AddBuildingWindow")?.Element("ItemAnotherIsland")?.Value; }
    }
    public static String AddBuildingWindow_NumberOfBuildings {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("AddBuildingWindow")?.Element("NumberOfBuildings")?.Value; }
    }
    public static String AddBuildingWindow_Productivity {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("AddBuildingWindow")?.Element("Productivity")?.Value; }
    }
    public static String AddBuildingWindow_SelectIsland {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("AddBuildingWindow")?.Element("SelectIsland")?.Value; }
    }
    //
    public static String IslandControl_LabelBuilding {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("IslandControl")?.Element("LabelBuilding")?.Value; }
    }
    public static String IslandControl_LabelProduct {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("IslandControl")?.Element("LabelProduct")?.Value; }
    }
    public static String IslandControl_LabelCount {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("IslandControl")?.Element("LabelCount")?.Value; }
    }
    public static String IslandControl_LabelProductivity {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("IslandControl")?.Element("LabelProductivity")?.Value; }
    }
    public static String IslandControl_LabelTarget {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("IslandControl")?.Element("LabelTarget")?.Value; }
    }
    public static String IslandControl_LabelActual {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("IslandControl")?.Element("LabelActual")?.Value; }
    }
    //
    public static String Buildings_Lumberjack {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("Lumberjack")?.Value; }
    }
    public static String Buildings_Sawmill {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("Sawmill")?.Value; }
    }
    public static String Buildings_CoalMine {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("CoalMine")?.Value; }
    }
    public static String Buildings_IronMine {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("IronMine")?.Value; }
    }
    public static String Buildings_Furnace {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("Furnace")?.Value; }
    }
    public static String Buildings_Steelworks {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("Steelworks")?.Value; }
    }
    public static String Buildings_SandMine {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("SandMine")?.Value; }
    }
    public static String Buildings_Glassmakers {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("Glassmakers")?.Value; }
    }
    public static String Buildings_WindowMakers {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("WindowMakers")?.Value; }
    }
    public static String Buildings_SpectacleFactory {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("SpectacleFactory")?.Value; }
    }
    public static String Buildings_FilamentFactory {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("FilamentFactory")?.Value; }
    }
    public static String Buildings_LightBulbFactory {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("LightBulbFactory")?.Value; }
    }
    public static String Buildings_CharcoalKiln {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("CharcoalKiln")?.Value; }
    }
    public static String Buildings_CaoutchoucPlantation {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("CaoutchoucPlantation")?.Value; }
    }
    public static String Buildings_Coachmakers {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("Coachmakers")?.Value; }
    }
    public static String Buildings_ZincMine {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("ZincMine")?.Value; }
    }
    public static String Buildings_CopperMine {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("CopperMine")?.Value; }
    }
    public static String Buildings_BrassSmeltery {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("BrassSmeltery")?.Value; }
    }
    public static String Buildings_MotorAssemblyLine {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("MotorAssemblyLine")?.Value; }
    }
    public static String Buildings_CabAssemblyLine {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("CabAssemblyLine")?.Value; }
    }
    public static String Buildings_MarquetryWorkshop {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("MarquetryWorkshop")?.Value; }
    }
    public static String Buildings_GramophoneFactory {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Buildings")?.Element("GramophoneFactory")?.Value; }
    }
    //
    public static String Materials_Wood {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Wood")?.Value; }
    }
    public static String Materials_Timber {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Timber")?.Value; }
    }
    public static String Materials_Coal {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Coal")?.Value; }
    }
    public static String Materials_Iron {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Iron")?.Value; }
    }
    public static String Materials_Steel {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Steel")?.Value; }
    }
    public static String Materials_SteelBeams {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("SteelBeams")?.Value; }
    }
    public static String Materials_QuartzSand {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("QuartzSand")?.Value; }
    }
    public static String Materials_Glass {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Glass")?.Value; }
    }
    public static String Materials_Windows {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Windows")?.Value; }
    }
    public static String Materials_Glasses {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Glasses")?.Value; }
    }
    public static String Materials_Filaments {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Filaments")?.Value; }
    }
    public static String Materials_LightBulbs {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("LightBulbs")?.Value; }
    }
    public static String Materials_Caoutchouc {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Caoutchouc")?.Value; }
    }
    public static String Materials_Chassis {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Chassis")?.Value; }
    }
    public static String Materials_Zinc {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Zinc")?.Value; }
    }
    public static String Materials_Copper {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Copper")?.Value; }
    }
    public static String Materials_Brass {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Brass")?.Value; }
    }
    public static String Materials_SteamMotors {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("SteamMotors")?.Value; }
    }
    public static String Materials_SteamCarriages {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("SteamCarriages")?.Value; }
    }
    public static String Materials_WoodVeneers {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("WoodVeneers")?.Value; }
    }
    public static String Materials_Gramophones {
      get { return Localization.Documents[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper()].Element("Materials")?.Element("Gramophones")?.Value; }
    }
    //
    #endregion

    #region Fields
    private static readonly Dictionary<String, XElement> Documents = new Dictionary<String, XElement>();
    #endregion

    #region Constructor
    static Localization() {
      using (var stream = typeof(Localization).Assembly.GetManifestResourceStream("MaterialCalculator.Resources.Globalization.EN.xml")) {
        if (stream == null) return;
        using (var reader = new StreamReader(stream)) {
          var result = reader.ReadToEnd();
          Localization.Documents.Add("EN", XDocument.Parse(result).Root);
        }
      }
      using (var stream = typeof(Localization).Assembly.GetManifestResourceStream("MaterialCalculator.Resources.Globalization.DE.xml")) {
        if (stream == null) return;
        using (var reader = new StreamReader(stream)) {
          var result = reader.ReadToEnd();
          Localization.Documents.Add("DE", XDocument.Parse(result).Root);
        }
      }
    }
    #endregion

  }

}