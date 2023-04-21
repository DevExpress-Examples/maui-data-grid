using DataGridSearchBar.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static DataGridSearchBar.App;

namespace DataGridSearchBar.ViewModels {
    public class MainViewModel : BindableBase {
        public MainViewModel() {
            LoadData();
        }
        public async void LoadData() {
            Contacts = new ObservableCollection<Model.Contact>(await Task.Run(() => DBContactService.Instance.GetItems()));
        }
        ObservableCollection<Model.Contact> contacts;
        public ObservableCollection<Model.Contact> Contacts {
            get { return contacts; }
            set {
                contacts = value;
                RaisePropertyChanged();
            }
        }
    }
    public class BindableBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
