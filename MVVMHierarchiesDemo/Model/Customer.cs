using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using GalaSoft.MvvmLight;

namespace MVVMHierarchiesDemo.Model
{
    public class Customer : ObservableObject
    {
        private string _Name;
        private int _ID;
        private string _Country;
        private string _Type;

        private bool _isDirty;

        public string Name
        {
            get { return _Name; }
            set
            {
                if(Set(()=>Name, ref _Name, value)) { IsDirty = true; }
            }
        }

        public int ID
        {
            get { return _ID; }
            set
            {
                if (Set(() => ID, ref _ID, value)) { IsDirty = true; }
            }
        }

        public string Country
        {
            get { return _Country; }
            set
            {
                if (Set(() => Country, ref _Country, value)) { IsDirty = true; }
            }
        }

        public string Type
        {
            get { return _Type; }
            set
            {
                if (Set(() => Type, ref _Type, value)) { IsDirty = true; }
            }
        }

        public bool IsDirty
        {
            get { return _isDirty; }
            set { Set(() => IsDirty, ref _isDirty, value); }
        }

    }
}
