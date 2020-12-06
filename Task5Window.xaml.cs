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
    /// Логика взаимодействия для DsWindow.xaml
    /// </summary>
    public partial class Task5Window : Window
    {
        public Task5Window()
        {
            InitializeComponent();
        }

        private void Proceed_Button_Click(object sender, RoutedEventArgs e)
        {
            prog5 ecp = new prog5(MessageTB.Text, int.Parse(PTB.Text), int.Parse(QTB.Text), int.Parse(DTB.Text), int.Parse(H0TB.Text));
            NTB.Text = ecp.n.ToString();
            PhiTB.Text = ecp.f.ToString();
            ETB.Text = ecp.e.ToString();
            HashTB.Text = ecp.Hash().ToString();
            PublicKeyTB.Text = ecp.publicKey();
            PrivateKeyTB.Text = ecp.privateKey();
            EncryptedTB.Text = ecp.Encrypt().ToString();
            DecryptedTB.Text = ecp.Decrypt().ToString();
        }

        private void H0TB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MessageTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
