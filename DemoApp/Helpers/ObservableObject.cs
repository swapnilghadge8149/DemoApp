// -----------------------------------------------------------------------
//  <copyright file="ObservableObject.cs" company="YASH Technologies">
//      Copyright (c) YASH Technologies. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace DemoApp.Helpers
{
    internal class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Sets Property
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="backingStore">backingStore</param>
        /// <param name="value">value</param>
        /// <param name="propertyName">propertyName</param>
        /// <param name="onChanged">onChanged</param>
        /// <returns></returns>
        protected bool SetProperty<T>(
           ref T backingStore, T value,
           [CallerMemberName] string propertyName = "",
           Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Property Changed Event Handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// On Property Changed
        /// </summary>
        /// <param name="propertyName">propertyName</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
