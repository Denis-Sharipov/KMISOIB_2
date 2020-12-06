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
using System.Windows.Shapes;

namespace KMiSOIB
{
    public partial class prog4Window : Window
    {
        public prog4Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            prog4 hashFunction = new prog4(MessageTB.Text, int.Parse(pTB.Text), int.Parse(qTB.Text), int.Parse(H0TB.Text));
            resTB.Text = hashFunction.Hash().ToString();
        }
    }
}
