using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using MaterialCalculator.DesignTime;
using MaterialCalculator.Enumerations;
using MaterialCalculator.Library;
using MaterialCalculator.Models.Island;
using MaterialCalculator.Models.Main;
using MaterialCalculator.Models.Work;
using MaterialCalculator.Windows;
using Microsoft.Win32;
using Newtonsoft.Json;
using Localization = MaterialCalculator.Resources.Localization;

// ReSharper disable UnusedMember.Global
// ReSharper disable once MemberCanBePrivate.Global
namespace MaterialCalculator {

  public partial class MainWindow {

    #region Properties
    public static ApplicationModel ApplicationModel { get; set; }
    public ApplicationModel BindingModel {
      get { return MainWindow.ApplicationModel; }
    }
    public NotifyProperty<Settings> Settings { get; }
    #endregion

    #region Fields
    private readonly String ModelFile;
    private readonly String RoamingPath;
    private readonly String SettingsFile;
    #endregion

    #region Constructor
    public MainWindow() {
      this.InitializeComponent();
      this.RoamingPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MaterialCalculator");
      this.SettingsFile = Path.Combine(this.RoamingPath, "Settings.xml");
      this.ModelFile = Path.Combine(this.RoamingPath, "Model.json");
      this.Settings = new NotifyProperty<Settings>(null);
      this.InitLanguage();
      this.LoadSettings();
      this.LoadModel();
      this.DataContext = this;
    }
    #endregion

    #region Internal Methods
    internal void Finish() {
      this.Settings.Value.Language = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName.ToUpper();
      this.Settings.Value.WindowTop = this.Top;
      this.Settings.Value.WindowLeft = this.Left;
      this.Settings.Value.WindowHeight = this.Height;
      this.Settings.Value.WindowWidth = this.Width;
      this.SaveSettings();
      this.SaveModel();
    }
    #endregion

    #region Protected Methods
    //protected override void OnInitialized(EventArgs e) {
    //  base.OnInitialized(e);
    //  this.Model = new NotifyProperty<ApplicationModel>(new ApplicationModel());
    //  this.Model.Value.IslandItems = new ObservableCollection<BaseModel> {
    //    new WorkModelProduction(Guid.Empty, Enumerations.Buildings.Lumberjack),
    //    new WorkModelProduction(Guid.Empty, Enumerations.Buildings.Sawmill),
    //    new WorkModelGroup(Guid.Empty, Enumerations.Buildings.CabAssemblyLine) {
    //      InputBuildings = new ObservableCollection<WorkModel> {
    //        new WorkModelGroup(Guid.Empty, Enumerations.Buildings.Coachmakers) {
    //          InputBuildings = new ObservableCollection<WorkModel> {
    //            new WorkModelProduction(Guid.Empty, Buildings.Lumberjack),
    //            new WorkModelProduction(Guid.Empty, Buildings.CaoutchoucPlantation)
    //          }
    //        },
    //        new WorkModelGroup(Guid.Empty, Enumerations.Buildings.MotorAssemblyLine) {
    //          InputBuildings = new ObservableCollection<WorkModel> {
    //            new WorkModelProduction(Guid.Empty, Buildings.Furnace),
    //            new WorkModelProduction(Guid.Empty, Buildings.BrassSmeltery)
    //          }
    //        }
    //      }
    //    }
    //  };
    //  var depth = this.Model.Value.IslandItems.OfType<WorkModelGroup>().Single().InputBuildings.OfType<WorkModelGroup>().Skip(1).First().InputBuildings.OfType<WorkModelProduction>().Skip(1).First().Depth;
    //  //var depth = this.Model.Value.IslandItems.OfType<WorkModelProduction>().Skip(1).First().Depth;
    //}
    protected override void OnClosing(CancelEventArgs e) {
      base.OnClosing(e);
      if (Application.Current.MainWindow == this) {
        this.Finish();
      }
    }
    #endregion

    #region Private Methods
    private void InitLanguage() {
      var language = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
      switch (language.ToUpper()) {
        case "EN":
          this.ComboBoxLanguage.SelectedIndex = 0;
          break;
        case "DE":
          this.ComboBoxLanguage.SelectedIndex = 1;
          break;
        default:
          CultureInfo.CurrentUICulture = new CultureInfo("en");
          this.ComboBoxLanguage.SelectedIndex = 0;
          break;
      }
    }
    private void LoadSettings() {
      try {
        if (!Directory.Exists(this.RoamingPath)) {
          Directory.CreateDirectory(this.RoamingPath);
        }
        if (File.Exists(this.SettingsFile)) {
          var data = File.ReadAllBytes(this.SettingsFile);
          var xmlSerializer = new XmlSerializer(typeof(Settings));
          using var stream = new MemoryStream(data);
          var result = xmlSerializer.Deserialize(stream) as Settings;
          this.Settings.Value = result;
        }
        if (this.Settings.Value == null) {
          this.Settings.Value = new Settings();
        }
        if (this.Settings.Value.WindowTop != null) this.Top = this.Settings.Value.WindowTop.Value;
        if (this.Settings.Value.WindowLeft != null) this.Left = this.Settings.Value.WindowLeft.Value;
        if (this.Settings.Value.WindowHeight != null) this.Height = this.Settings.Value.WindowHeight.Value;
        if (this.Settings.Value.WindowWidth != null) this.Width = this.Settings.Value.WindowWidth.Value;
      } catch (Exception) {
        // ignored
      }
    }
    private void SaveSettings() {
      try {
        if (Directory.Exists(this.RoamingPath)) {
          var xmlSerializer = new XmlSerializer(typeof(Settings));
          using var stream = new StreamWriter(this.SettingsFile);
          xmlSerializer.Serialize(stream, this.Settings.Value);
        }
      } catch (Exception) {
        // ignored
      }
    }
    private void LoadModel() {
      try {
        var settings = new JsonSerializerSettings {
          TypeNameHandling = TypeNameHandling.Auto,
          Formatting = Formatting.Indented,
          Converters = {
            new BaseModelConverter(),
            new NotifyPropertyConverter<Int32>(),
            new NotifyPropertyConverter<String>()
          }
        };
        if (this.Settings?.Value?.FullFileName != null) {
          if (File.Exists(this.Settings.Value.FullFileName)) {
            var data = File.ReadAllText(this.Settings.Value.FullFileName);
            var result = JsonConvert.DeserializeObject<ApplicationModel>(data, settings);
            MainWindow.ApplicationModel = result;
            this.InitModel();
          }
        } else {
          if (File.Exists(this.ModelFile)) {
            var data = File.ReadAllText(this.ModelFile);
            var result = JsonConvert.DeserializeObject<ApplicationModel>(data, settings);
            MainWindow.ApplicationModel = result;
            this.InitModel();
          }
        }
      } catch (Exception) {
        MessageBox.Show(this, Localization.MessageBox_FileNotLoaded, Localization.MessageBox_Title, MessageBoxButton.OK, MessageBoxImage.Warning);
      } finally {
        if (MainWindow.ApplicationModel == null) {
          MainWindow.ApplicationModel = new ApplicationModel();
        }
      }
    }
    private void SaveModel() {
      try {
        var settings = new JsonSerializerSettings {
          TypeNameHandling = TypeNameHandling.Auto,
          Formatting = Formatting.Indented,
          ContractResolver = new WritablePropertiesOnlyResolver(),
          Converters = {
            new BaseModelConverter(),
            new NotifyPropertyConverter<Int32>(),
            new NotifyPropertyConverter<String>()
          }
        };
        var result = JsonConvert.SerializeObject(MainWindow.ApplicationModel, settings);
        if (this.Settings?.Value?.FullFileName != null) {
          File.WriteAllText(this.Settings.Value.FullFileName, result);
        }
        if (Directory.Exists(this.RoamingPath)) {
          File.WriteAllText(this.ModelFile, result);
        }
      } catch (Exception) {
        MessageBox.Show(this, Localization.MessageBox_FileNotSaved, Localization.MessageBox_Title, MessageBoxButton.OK, MessageBoxImage.Warning);
      }
    }
    private void InitModel() {
      if (MainWindow.ApplicationModel != null) {
        foreach (var island in MainWindow.ApplicationModel.Islands) {
          island.Init();
          island.Calculate();
        }
        MainWindow.ApplicationModel.SelectedIsland.Value = MainWindow.ApplicationModel.Islands.FirstOrDefault();
      }
    }
    #endregion

    #region Events
    private void ButtonAddIsland_OnClick(Object sender, RoutedEventArgs e) {
      var window = new AddIslandWindow();
      var result = window.ShowDialog();
      if (result.HasValue && result.Value) {
        var island = new IslandModel { Name = new NotifyProperty<String>(window.IslandName) };
        MainWindow.ApplicationModel.Islands.Add(island);
        MainWindow.ApplicationModel.SelectedIsland.Value = island;
      }
    }
    private void ButtonRemoveIsland_OnClick(Object sender, RoutedEventArgs e) {
      if (MainWindow.ApplicationModel.SelectedIsland != null) {
        var result = MessageBox.Show(this, Localization.MessageBox_RemoveIsland, Localization.MessageBox_Title, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        if (result == MessageBoxResult.Yes) {
          MainWindow.ApplicationModel.Islands.Remove(MainWindow.ApplicationModel.SelectedIsland.Value);
        }
      }
    }
    private void ButtonEditIsland_OnClick(Object sender, RoutedEventArgs e) {
      if (MainWindow.ApplicationModel.SelectedIsland != null) {
        var window = new EditIslandWindow { IslandName = MainWindow.ApplicationModel.SelectedIsland.Value.Name.Value };
        var result = window.ShowDialog();
        if (result.HasValue && result.Value) {
          MainWindow.ApplicationModel.SelectedIsland.Value.Name.Value = window.IslandName;
        }
      }
    }
    private void ButtonLoad_OnClick(Object sender, RoutedEventArgs e) {
      var ofd = new OpenFileDialog {
        DefaultExt = ".json",
        Filter = "JSON (*.json)|*.json"
      };
      var result = ofd.ShowDialog();
      if (result.HasValue && result.Value) {
        this.Settings.Value.FullFileName = ofd.FileName;
        this.LoadModel();
      }
    }
    private void ButtonSave_OnClick(Object sender, RoutedEventArgs e) {
      var sfd = new SaveFileDialog {
        DefaultExt = ".json",
        Filter = "JSON (*.json)|*.json"
      };
      var result = sfd.ShowDialog();
      if (result.HasValue && result.Value) {
        this.Settings.Value.FullFileName = sfd.FileName;
        this.SaveModel();
      }
    }
    private void Island_OnSelectionChanged(Object sender, SelectionChangedEventArgs e) {
      var island = e.AddedItems.OfType<IslandModel>().SingleOrDefault();
      island?.Calculate();
    }
    private void ComboBoxLanguage_OnSelectionChanged(Object sender, SelectionChangedEventArgs e) {
      if (!this.IsLoaded) return;
      var index = ((ComboBox)e.Source).SelectedIndex;
      switch (index) {
        case 0:
          CultureInfo.CurrentUICulture = new CultureInfo("en");
          break;
        case 1:
          CultureInfo.CurrentUICulture = new CultureInfo("de");
          break;
        default:
          throw new ArgumentOutOfRangeException($"language with index '{index}' is not supported yet");
      }
      App.ChangeLanguage();
    }
    #endregion

  }

}