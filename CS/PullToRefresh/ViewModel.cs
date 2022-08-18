using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using PullToRefresh;

namespace PullToRefresh {
    public class ViewModel : INotifyPropertyChanged {
        ProductData data;

        bool isRefreshing = false;
        public bool IsRefreshing {
            get { return isRefreshing; }
            set {
                if (isRefreshing != value) {
                    isRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }
        }

        ObservableCollection<Product> products;
        public ObservableCollection<Product> Products {
            get { return products; }
            set {
                if (products != value) {
                    products = value;
                    OnPropertyChanged("Products");
                }
            }
        }

        ICommand pullToRefreshCommand = null;
        public ICommand PullToRefreshCommand {
            get { return pullToRefreshCommand; }
            set {
                if (pullToRefreshCommand != value) {
                    pullToRefreshCommand = value;
                    OnPropertyChanged("PullToRefreshCommand");
                }
            }
        }

        public ViewModel() {
            this.data = new ProductData();
            Products = data.Products;
            PullToRefreshCommand = new Command(ExecutePullToRefreshCommand);
        }

        void ExecutePullToRefreshCommand() {
            Task.Factory.StartNew(() => {
                Thread.Sleep(3000);
                Device.BeginInvokeOnMainThread(() => {
                    data.RefreshProducts();
                    Products = data.Products;
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
}

