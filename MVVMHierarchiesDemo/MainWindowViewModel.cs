using MVVMHierarchiesDemo.ViewModel;
using MVVMHierarchiesDemo.Views;
using MVVMHierarchiesDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Forms;

namespace MVVMHierarchiesDemo
{

    class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _CurrentViewModel;
        private CustomerListViewModel custListViewModel = new CustomerListViewModel();
        private OrderViewModel orderViewModelModel = new OrderViewModel();

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);
        }


        public ViewModelBase CurrentViewModel
        {
            get { return _CurrentViewModel; }
            set { Set(() => CurrentViewModel, ref _CurrentViewModel, value); }
        }

        public RelayCommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {

            switch (destination)
            {
                case "orders":
                    CurrentViewModel = orderViewModelModel;
                    break;
                case "customers":
                default:
                    CurrentViewModel = custListViewModel;
                    break;
            }
        }

    }
}