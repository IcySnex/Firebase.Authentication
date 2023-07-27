namespace Firebase.Authentication.Models;

/// <summary>
/// Provides data for the System.ComponentModel.INotifyPropertyChanged.PropertyChanged event
/// </summary>
/// <typeparam name="T">The data type of the changed property</typeparam>
public class PropertyChangedEventArgs<T> : System.ComponentModel.PropertyChangedEventArgs
{
    /// <summary>
    /// Creates new PropertyChangedEventArgs
    /// </summary>
    /// <param name="oldValue">The old value of the property</param>
    /// <param name="newValue">The new value of the property</param>
    /// <param name="propertyName">The name of the property that changed</param>
    public PropertyChangedEventArgs(
        string propertyName,
        T? oldValue,
        T? newValue) : base(propertyName)
    {
        OldValue = oldValue;
        NewValue = newValue;
    }

    /// <summary>
    /// The old value of the property
    /// </summary>
    public T? OldValue { get; }

    /// <summary>
    /// The new value of the property
    /// </summary>
    public T? NewValue { get; }
}


//  Use like this inside PropertyChanged event handler if old/new value is needed:
//
//  switch (e)
//  {
//      case PropertyChangedEventArgs<TokenInfo> ev:
//          break;
//      case PropertyChangedEventArgs<UserInfo> ev:
//          break;
//  }