﻿using System.ComponentModel;

namespace MexeMexe.Aprexentacao.Wpf.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected void NotifyPropertyChange(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}