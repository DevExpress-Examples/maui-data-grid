using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace LoadMore {
    public class ViewModel : INotifyPropertyChanged {
        OrderData data;

        public bool isRefreshing = false;
        public bool IsRefreshing {
            get { return isRefreshing; }
            set {
                if (isRefreshing != value) {
                    isRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }
        }

        ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders {
            get { return orders; }
            set {
                if (orders != value) {
                    orders = value;
                    OnPropertyChanged("Products");
                }
            }
        }

        LoadMoreDataCommand loadMoreCommand = null;
        public LoadMoreDataCommand LoadMoreCommand {
            get { return loadMoreCommand; }
            set {
                if (loadMoreCommand != value) {
                    loadMoreCommand = value;
                    OnPropertyChanged("LoadMoreCommand");
                }
            }
        }

        public ViewModel() {
            this.data = new OrderData();
            Orders = data.Orders;
            LoadMoreCommand = new LoadMoreDataCommand(ExecuteLoadMoreCommand);
        }

        void ExecuteLoadMoreCommand() {
            Task.Run(() => {
                Thread.Sleep(1000);
                Device.BeginInvokeOnMainThread(() => {
                    data.LoadMoreOrders();
                    Orders = data.Orders;
                    IsRefreshing = false;
                });
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public class LoadMoreDataCommand : ICommand {
        readonly Action execute;
        int numOfLoadMore = 0;

        public event EventHandler CanExecuteChanged;

        public LoadMoreDataCommand(Action execute) {
            this.execute = execute;
        }

        public bool CanExecute(object parameter) {
            return numOfLoadMore < 3;
        }

        public void Execute(object parameter) {
            numOfLoadMore++;
            ChangeCanExecute();
            this.execute();
        }
        void ChangeCanExecute() {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
