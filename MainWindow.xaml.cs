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
using System.Windows.Media.Imaging;

namespace KMiSOIB
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RsaWindow_Button_Click(object sender, RoutedEventArgs e)
        {
            new prog3Window().Show();
        }

        private void HashFunctionWindow_Button_Click(object sender, RoutedEventArgs e)
        {
            new prog4Window().Show();
        }

        private void DsWindow_Button_Click(object sender, RoutedEventArgs e)
        {
            new Task5Window().Show();
        }

        private void DesWindow_Button_Click(object sender, RoutedEventArgs e)
        {
            new prog1Window().Show();
        }

        private void GostWindow_Button_Click(object sender, RoutedEventArgs e)
        {
            new Task2Window().Show();
        }
    }
}