using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Calculator_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double FirstNumber;
        string Operation;
        double Result;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void btn_number(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn )
            {
                if (textbox.Text == "0" && textbox.Text != null)
                {
                    textbox.Text = btn.Content.ToString();
                }
                else
                {
                    textbox.Text = textbox.Text + btn.Content.ToString();
                }
            }
        }

        public void btn_operation(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn )
            {
                FirstNumber = Convert.ToDouble(textbox.Text);
                textbox.Text = "0";
                Operation = btn.Content.ToString();
            }
        }
       
        public void btn_equal1(object sender, EventArgs e)
        {
            double SecondNumber;
            //double Result;

            SecondNumber = Convert.ToDouble(textbox.Text);

            if (Operation == "+")
            {
                Result = (FirstNumber + SecondNumber);
                textbox.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "-")
            {
                Result = (FirstNumber - SecondNumber);
                textbox.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }
            if (Operation == "*")
            {
                Result = (FirstNumber * SecondNumber);
                textbox.Text = Convert.ToString(Result);
                FirstNumber = Result;
            }       



            if (Operation == "/")
            {
                if (SecondNumber == 0)
                {
                    textbox.Text = "Cannot divide by zero";
                }
                else
                {
                    Result = (FirstNumber / SecondNumber);
                    textbox.Text = Convert.ToString(Result);
                    FirstNumber = Result;
                }
            }
        }

        public void btn_c_click(object sender, EventArgs e)
        {
            textbox.Text = "0";
        }

        public void btn_dot_click(object sender, EventArgs e)
        {
            textbox.Text = textbox.Text + ".";
        }

        public void btn_root_click(object sender, EventArgs e)
        {
            if(sender is Button btn)
            {
                int temp= Convert.ToInt32(textbox.Text);
                textbox.Text = Math.Sqrt(temp).ToString();                
            }
        }
        public void btn_square_click(object sender, EventArgs e)
        {
            if(sender is Button btn)
            {
                double temp= Convert.ToDouble(textbox.Text);
                textbox.Text = (temp*temp).ToString();                
            }
        }

        public void btn_reverse_click(object sender, EventArgs e)
        {
            if(sender is Button btn)
            {
                double temp= Convert.ToDouble(textbox.Text);
                textbox.Text = (1/temp).ToString();                
            }
        }
        public void btn_backspace_click(object sender, EventArgs e)
        {
            int newlen = textbox.Text.Length - 1;
            string temp = textbox.Text.Remove(newlen);
            textbox.Text=temp;
        }



    }
}
