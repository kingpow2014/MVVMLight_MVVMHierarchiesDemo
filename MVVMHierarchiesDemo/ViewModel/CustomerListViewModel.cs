using MVVMHierarchiesDemo.Model;
using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MVVMHierarchiesDemo.ViewModel
{
    public class CustomerListViewModel : ViewModelBase
    {
        private Customer _selectedCustomer;
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand CreateCustomer { get; private set; }

        private int newID = 3;

        public CustomerListViewModel()
        {
            LoadCustomerList();
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            CreateCustomer = new RelayCommand(OnNewCustomer);
        }

        public ObservableCollection<Customer> CustomerList
        {
            get;
            set;
        }

        public void LoadCustomerList()
        {
            ObservableCollection<Customer> newList = new ObservableCollection<Customer>()
            {
                new Customer { Name = "Angel_C.O.", ID = 1, Country = "CANADA" },
                new Customer { Name = "GREENPRODUCTION", ID = 2, Country = "US" },
                new Customer { Name = "IQ FOOD", ID = 3, Country = "CANADA" }
            };

            CustomerList = newList;
        }

        

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set {
                Set(() => SelectedCustomer, ref _selectedCustomer, value);
                DeleteCommand.RaiseCanExecuteChanged();
            }
        } 

        private void OnDelete()
        {
            CustomerList.Remove(SelectedCustomer);
        }

        private bool CanDelete()
        {
            return SelectedCustomer != null;
        }

        public void OnNewCustomer()
        {   
            CustomerList.Add(new Customer { ID = (newID += 1), Name = "Enter Customer Name", Country = "Enter Country" });
        }

    }
}
