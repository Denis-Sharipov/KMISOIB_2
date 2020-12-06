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

    public partial class prog1Window : Window
    {
        public prog1Window()
        {
            InitializeComponent();
        }

        private void Proceed_Button_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTB.Text;
            string key = KeyTB.Text;
            prog1 des = new prog1(message, key);

            MessageBinaryTB.Text = Utills.BinaryFormat(des.msg2, 8);
            SubstituteTB.Text = Utills.BinaryFormat(des.perMsg, 8);
            LBlockTB.Text = Utills.BinaryFormat(des.l, 4);
            RBlockTB.Text = Utills.BinaryFormat(des.r, 4);
            ExtenderRTB.Text = Utills.BinaryFormat(des.exr, 6);
            KeyBinaryTB.Text = Utills.BinaryFormat(des.k2, 6);
            SumTB.Text = Utills.BinaryFormat(des.summKAndR, 6);
            Substitute2TB.Text = Utills.BinaryFormat(des.s, 4);
            RBlock.Text = Utills.BinaryFormat(des.pAndL, 8);
            ConcatAndSumTB.Text = Utills.BinaryFormat(des.res, 8);
        }

        private void SumTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void KeyTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Substitute2TB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ConcatAndSumTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    }

