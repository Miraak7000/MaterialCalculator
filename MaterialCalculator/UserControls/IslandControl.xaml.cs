using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialCalculator.Library;
using MaterialCalculator.Models.Create;
using MaterialCalculator.Models.Island;
using MaterialCalculator.Models.Work;
using MaterialCalculator.Windows;
using Localization = MaterialCalculator.Resources.Localization;

// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable once MemberCanBeMadeStatic.Global
namespace MaterialCalculator.UserControls {

  public partial class IslandControl {

    #region Properties
    public IEnumerable<Building> Buildings {
      get { return BuildingCollection.Items; }
    }
    public Building SelectedBuilding { get; set; }
    #endregion

    #region Fields
    private Point StartPoint;
    #endregion

    #region Constructor
    public IslandControl() {
      this.InitializeComponent();
    }
    #endregion

    #region Events
    private void ButtonAddBuilding_OnClick(Object sender, RoutedEventArgs e) {
      if (this.SelectedBuilding != null) {
        var window = new AddBuildingWindow(this.SelectedBuilding.Type);
        var result = window.ShowDialog();
        if (result.HasValue && result.Value) {
          if (this.DataContext is IslandModel island) {
            switch (window.Model.Value) {
              case CreateProductionModel model:
                if (this.SelectedBuilding.Inputs.Length > 0) {
                  var modelGroup = new WorkModelGroup(island.ID, this.SelectedBuilding.Type) {
                    NumberOfBuildings = new NotifyProperty<Int32>(model.NumberOfBuildings),
                    Productivity = new NotifyProperty<Int32>(model.Productivity)
                  };
                  modelGroup.Init();
                  MainWindow.ApplicationModel.IslandItems.Add(modelGroup);
                } else {
                  var modelProduction = new WorkModelProduction(island.ID, this.SelectedBuilding.Type) {
                    NumberOfBuildings = new NotifyProperty<Int32>(model.NumberOfBuildings),
                    Productivity = new NotifyProperty<Int32>(model.Productivity)
                  };
                  modelProduction.Init();
                  MainWindow.ApplicationModel.IslandItems.Add(modelProduction);
                }
                island.Calculate();
                break;
              case CreateReferenceModel model:
                var modelReference = new WorkModelReference(island.ID, this.SelectedBuilding.Type) {
                  ReferenceID = model.SelectedIsland.ID
                };
                modelReference.Init();
                MainWindow.ApplicationModel.IslandItems.Add(modelReference);
                island.Calculate();
                break;
              default:
                throw new ArgumentOutOfRangeException($"this model is not supported: {window.Model.Value.GetType()}");
            }
          }
        }
      }
    }
    private void ButtonAddSeparator_OnClick(Object sender, RoutedEventArgs e) {
      if (this.DataContext is IslandModel island) {
        var modelSeparator = new SeparatorModel(island.ID);
        MainWindow.ApplicationModel.IslandItems.Add(modelSeparator);
      }
    }
    private void ButtonDelete_OnClick(Object sender, RoutedEventArgs e) {
      if (this.ListViewBuildings.SelectedItem == null) return;
      if (this.DataContext is IslandModel island) {
        var result = MessageBox.Show(Application.Current.MainWindow, Localization.MessageBox_RemoveBuilding, Localization.MessageBox_Title, MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        if (result == MessageBoxResult.Yes) {
          var model = (BaseModel)this.ListViewBuildings.SelectedItem;
          MainWindow.ApplicationModel.IslandItems.Remove(model);
          island.IslandItems.Refresh();
        }
      }
    }
    private void Buildings_PreviewMouseLeftButtonDown(Object sender, MouseButtonEventArgs e) {
      this.StartPoint = e.GetPosition(null);
    }
    private void Buildings_MouseMove(Object sender, MouseEventArgs e) {
      if (sender is ListView listView) {
        var mousePosition = e.GetPosition(null);
        var diff = this.StartPoint - mousePosition;
        if (e.LeftButton == MouseButtonState.Pressed && (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)) {
          var source = (DependencyObject)e.OriginalSource;
          var listViewItem = source.FindAnchestor<ListViewItem>();
          if (listViewItem != null) {
            var building = (BaseModel)listView.ItemContainerGenerator.ItemFromContainer(listViewItem);
            var dragData = new DataObject("BuildingObject", building);
            DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
          }
        }
      }
    }
    private void Buildings_OnDrop(Object sender, DragEventArgs e) {
      if (sender is ListView listView && e.Data.GetDataPresent("BuildingObject")) {
        if (e.Data.GetData("BuildingObject") is BaseModel building) {
          var source = (DependencyObject)e.OriginalSource;
          var listViewItem = source.FindAnchestor<ListViewItem>();
          if (listViewItem != null) {
            var newIndex = listView.Items.IndexOf(listViewItem.Content);
            if (listView.ItemsSource is ICollectionView list) {
              var sourceCollection = (ObservableCollection<BaseModel>)list.SourceCollection;
              sourceCollection.RemoveAt(sourceCollection.IndexOf(building));
              sourceCollection.Insert(newIndex, building);
              list.Refresh();
            }
          }
        }
      }
    }
    private void Buildings_OnDragEnter(Object sender, DragEventArgs e) {
      if (!e.Data.GetDataPresent("BuildingObject") || sender == e.Source) {
        e.Effects = DragDropEffects.None;
      }
    }
    private void ContextMenuAdd_OnClick(Object sender, RoutedEventArgs e) {
      if (((MenuItem)e.OriginalSource).DataContext is Building building && ((MenuItem)sender).DataContext is WorkModelGroup workModel) {
        var window = new AddBuildingWindow(building.Type);
        var result = window.ShowDialog();
        if (result.HasValue && result.Value) {
          if (this.DataContext is IslandModel island) {
            switch (window.Model.Value) {
              case CreateProductionModel model:
                var modelProduction = new WorkModelProduction(island.ID, building.Type) {
                  NumberOfBuildings = new NotifyProperty<Int32>(model.NumberOfBuildings),
                  Productivity = new NotifyProperty<Int32>(model.Productivity)
                };
                modelProduction.Init();
                workModel.InputBuildings.Add(modelProduction);
                island.Calculate();
                break;
              case CreateReferenceModel model:
                var modelReference = new WorkModelReference(island.ID, building.Type) {
                  ReferenceID = model.SelectedIsland.ID
                };
                modelReference.Init();
                workModel.InputBuildings.Add(modelReference);
                island.Calculate();
                break;
              default:
                throw new ArgumentOutOfRangeException($"this model is not supported: {window.Model.Value.GetType()}");
            }
          }
        }
      }
    }
    private void ContextMenuRemove_OnClick(Object sender, RoutedEventArgs e) {

    }
    #endregion

  }

}