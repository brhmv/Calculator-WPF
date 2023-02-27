using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Models
{
    public class Car : INotifyPropertyChanged
    {
        private string vendor;
        private string model;
        private int year;

        public string Vendor { get => vendor; set { vendor = value; OnPropertyChanged(); } }
        public string Model { get => model; set { model = value; OnPropertyChanged(); } }
        public int Year { get => year; set { year = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
