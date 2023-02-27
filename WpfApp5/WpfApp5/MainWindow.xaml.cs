using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp5.Models;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //public string SomeText { get; set; } = "Binding";

        private string? someText;

        public string? SomeText
        {
            get { return someText; }
            set
            {
                someText = value;
                OnPropertyChanged();
            }
        }

        private Car? myCar;

        public Car? MyCar
        {
            get { return myCar; }
            set { myCar = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Car> Cars { get; set; } 


        public int Fontsize { get; set; } = 16;
        public MainWindow()
        {
            InitializeComponent();
            SomeText = "Hakuna";
            MyCar = new();
            //MyCar = new Car() { Vendor = "Nissan", Model = "Skyline Gtr R-34", Year = 1999 };
            Cars = new() {
                new Car() { Vendor = "Nissan", Model = "Skyline Gtr R-34", Year = 1999 },
                new Car() { Vendor = "Toyota", Model = "Supra", Year = 1999 }
            };
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SomeText = "kamil";
            MessageBox.Show(SomeText);
        }


        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //MyCar = new Car() { Vendor = "Toyota", Model = "Supra", Year = 1999 };
            MyCar.Vendor = "Toyota";
            MessageBox.Show($"{MyCar.Vendor} {MyCar.Model} {MyCar.Year}");
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var infoCar = new InfoCar();
            infoCar.MyCar = (sender as ListView)?.SelectedItem as Car;
            infoCar.ShowDialog();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Cars.Add(MyCar);
            MyCar = new();
        }
    }
}
