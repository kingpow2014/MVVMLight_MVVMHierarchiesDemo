using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using GalaSoft.MvvmLight;

namespace MVVMHierarchiesDemo.Model
{
    public class Order : ObservableObject
    {
        private int _ID;
        private string _Time;

        public int ID
        {
            get { return _ID; }
            set
            {
                Set(() => ID, ref _ID, value);
            }
        }

        public string Time
        {
            get { return _Time; }
            set
            {
                Set(() => Time, ref _Time, value);
            }
        }

    }
}
