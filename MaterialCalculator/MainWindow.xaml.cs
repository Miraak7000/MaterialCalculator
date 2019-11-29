using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Xml.Serialization;
using MaterialCalculator.Library;
using MaterialCalculator.Models;
using MaterialCalculator.Windows;
using Localization = MaterialCalculator.Resources.Localization;

// ReSharper disable once MemberCanBePrivate.Global
namespace MaterialCalculator {

  public partial class MainWindow : Window {

    #region Properties
    public NotifyProperty<ApplicationModel> Model { get; private set; }
    #endregion

    #region Constructor
    public MainWindow() {
      this.InitializeComponent();
    }
    #endregion

    #region Protected Methods
    protected override void OnInitialized(EventArgs e) {
      base.OnInitialized(e);
      this.Model = new NotifyProperty<ApplicationModel>(null);
      this.ButtonLoad_OnClick(null, null);
      if (this.Model.Value == null) this.Model.Value = new ApplicationModel();
      this.DataContext = this;
    }
    protected override void OnClosing(CancelEventArgs e) {
      this.ButtonSave_OnClick(null, null);
      base.OnClosing(e);
    }
    #endregion

    #region Events
    private void ButtonAddIsland_OnClick(Object sender, RoutedEventArgs e) {
      var window = new AddIslandWindow();
      var result = window.ShowDialog();
      if (result.HasValue && result.Value) {
        var island = new IslandModel { Name = new NotifyProperty<String>(window.IslandName) };
        this.Model.Value.Islands.Add(island);
        this.Model.Value.SelectedIsland.Value = island;
      }
    }
    private void ButtonRemoveIsland_OnClick(Object sender, RoutedEventArgs e) {
      if (this.Model.Value.SelectedIsland != null) {
        var result = MessageBox.Show(this, Localization.MessageBox_RemoveIsland, Localization.MessageBox_Title, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        if (result == MessageBoxResult.Yes) {
          this.Model.Value.Islands.Remove(this.Model.Value.SelectedIsland.Value);
        }
      }
    }
    private void ButtonEditIsland_OnClick(Object sender, RoutedEventArgs e) {
      if (this.Model.Value.SelectedIsland != null) {
        var window = new EditIslandWindow { IslandName = this.Model.Value.SelectedIsland.Value.Name.Value };
        var result = window.ShowDialog();
        if (result.HasValue && result.Value) {
          this.Model.Value.SelectedIsland.Value.Name.Value = window.IslandName;
        }
      }
    }
    private void ButtonLoad_OnClick(Object sender, RoutedEventArgs e) {
      try {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MaterialCalculator");
        var file = Path.Combine(path, "Model.xml");
        if (!Directory.Exists(path)) return;
        if (!File.Exists(file)) return;
        var data = File.ReadAllBytes(file);
        var xmlSerializer = new XmlSerializer(typeof(ApplicationModel));
        using var stream = new MemoryStream(data);
        var result = xmlSerializer.Deserialize(stream) as ApplicationModel;
        this.Model.Value = result;
        if (this.Model.Value == null) return;
        foreach (var island in this.Model.Value.Islands) {
          island.Init();
          island.Calculate();
        }
        this.Model.Value.SelectedIsland.Value = this.Model.Value.Islands.FirstOrDefault();
      } catch {
        // ignored
      }
    }
    private void ButtonSave_OnClick(Object sender, RoutedEventArgs e) {
      var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MaterialCalculator");
      var file = Path.Combine(path, "Model.xml");
      if (!Directory.Exists(path)) Directory.CreateDirectory(path);
      var xmlSerializer = new XmlSerializer(typeof(ApplicationModel));
      using var stream = new StreamWriter(file);
      xmlSerializer.Serialize(stream, this.Model.Value);
    }
    #endregion

  }

}