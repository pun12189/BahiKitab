using BahiKitab.Command;
using BahiKitab.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BahiKitab.ViewModel
{
    class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand RemoveCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ObservableCollection<HeaderItem> ProductHeaders { get; set; }

        public SettingsViewModel()
        {
            this.RemoveCommand = new DelegateCommand(RemoveCommandExecute);
            this.AddCommand = new DelegateCommand(AddCommandExecute);
            this.ProductHeaders = new ObservableCollection<HeaderItem>();
        }

        private void AddCommandExecute(object obj)
        {
        }

        private void RemoveCommandExecute(object obj)
        {
        }
    }
}
