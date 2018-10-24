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
using System.IO;
namespace WPFCONTROLS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            deliveryDate.SelectedDate = DateTime.Today;
            Title = "Survey";


        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append("Full Name: ");
            sb.Append(fullName.Text);
            sb.Append(" Sex? ");
            sb.Append( (bool) male.IsChecked ? "Male" : "Female");
            sb.Append(" Computer: ");
            sb.Append((bool)Desctop.IsChecked ? "Desctop" : "");
            sb.Append((bool)Laptop.IsChecked ? "Laptop" : "");
            sb.Append((bool)Table.IsChecked ? "Table" : "");
            sb.Append(" Job: ");
            sb.Append(job.SelectedItem.ToString());
            sb.Append(" Delivery date: ");
            sb.Append(deliveryDate.SelectedDate.ToString());
            MessageBox.Show(sb.ToString());
            WriteToFile(sb.ToString());


         }

        private void JobSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var newSelectedItem = e.AddedItems[0];
            MessageBox.Show(newSelectedItem.ToString());
            
        }
        static void WriteToFile(string str)
        {
            if (!File.Exists("1.txt"))
                { using (StreamWriter flName = File.CreateText("1.txt"))
                {
                    if (!String.IsNullOrEmpty(str))
                    {
                        flName.WriteLine(str);
                    }
                    else
                    {
                        MessageBox.Show("input parametr is empty");
                    }
                    flName.Close();
                }

            }
            else
            {
                using (StreamWriter flName = File.AppendText("1.txt"))
                {
                    if (!String.IsNullOrEmpty(str))
                    {
                        flName.WriteLine(str);
                    }
                    else
                    {
                        MessageBox.Show("input parametr is empty");
                    }
                    flName.Close();
                }
            }
        }
    }
}
