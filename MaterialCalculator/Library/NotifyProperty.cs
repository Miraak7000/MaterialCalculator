using System;
using System.ComponentModel;

// ReSharper disable MemberCanBePrivate.Global
namespace MaterialCalculator.Library {

  public class NotifyProperty<T> : INotifyPropertyChanged {

    #region EventHandler
    [field: NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion

    #region Properties
    public T Value {
      get { return this.PropertyValue; }
      set {
        this.PropertyValue = value;
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
      }
    }
    #endregion

    #region Fields
    private T PropertyValue;
    #endregion

    #region Constructor
    private NotifyProperty() {
    }
    public NotifyProperty(T value) {
      this.PropertyValue = value;
    }
    #endregion

    #region Public Methods
    public override String ToString() {
      return $"Value: {this.PropertyValue.ToString()}";
    }
    #endregion

  }

}