using MVVMHierarchiesDemo.Model;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MVVMHierarchiesDemo.ViewModel
{
    public class OrderViewModel : ViewModelBase
    {
        public RelayCommand DeleteOrder { get; private set; }
        public RelayCommand CreateOrder { get; private set; }
        public Order _selectedOrder;

        private int newID = 6;

        public OrderViewModel()
        {
            LoadOrderList();
            DeleteOrder = new RelayCommand(OnDelete, CanDelete);
            CreateOrder = new RelayCommand(OnCreateOrder);
        }

        public ObservableCollection<Order> OrderList
        {
            get;
            set;
        }

        public Order SelectedOrder
        {
            get { return _selectedOrder; }
            set {
                _selectedOrder = value;
                DeleteOrder.RaiseCanExecuteChanged();
            }
        }

        public void LoadOrderList()
        {
            ObservableCollection<Order> newList = new ObservableCollection<Order>()
            {
                new Order { ID = 1, Time = "171021" },
                new Order { ID = 2, Time = "171024" },
                new Order { ID = 3, Time = "171101" },
                new Order { ID = 4, Time = "180106" },
                new Order { ID = 5, Time = "180112" },
                new Order { ID = 6, Time = "180121" }
            };

            OrderList = newList;
        }

        private void OnDelete()
        {
            OrderList.Remove(SelectedOrder);
        }

        private bool CanDelete()
        {
            return SelectedOrder != null;
        }

        private void OnCreateOrder()
        {
            
            OrderList.Add(new Order { ID = (newID += 1), Time = System.DateTime.Now.ToString()});
        }
    }
}
