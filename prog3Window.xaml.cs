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
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class prog3Window : Window
    {
        public prog3Window()
        {
            InitializeComponent();
        }

        private void RraTB_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox(nTB, phiTB, eTB, PublicKeyTB, PrivateKeyTB, EncryptedTB, DecryptTB);

            prog3 rsa = new prog3(MessageTB.Text, int.Parse(pTB.Text), int.Parse(qTB.Text), int.Parse(dTB.Text));
            nTB.Text = rsa.n.ToString();
            phiTB.Text = rsa.f.ToString();
            eTB.Text = rsa.e.ToString();
            PublicKeyTB.Text = rsa.publicKey();
            PrivateKeyTB.Text = rsa.privateKey();
            EncryptedTB.Text = rsa.Encrypt();
            DecryptTB.Text = rsa.Decrypt();
        }

        private void ClearTextBox(params TextBox[] elements)
        {
            foreach (var e in elements) { e.Clear(); }
        }

        private void pTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MessageTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
