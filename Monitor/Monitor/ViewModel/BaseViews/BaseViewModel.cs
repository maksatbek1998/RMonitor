﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Monitor.ViewModel.BaseViews
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T feild, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(feild, value)) return false;
            feild = value;
            OnPropertyChanged(PropertyName);

            return true;
        }
    }
}
