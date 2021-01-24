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

namespace CalcWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double textBoxNum1 = 0;
        double textBoxNum2 = 0;
        string takedOp = string.Empty;
        int trueCalc = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_takedNum_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string numButton = button.Content.ToString();
            if (txtValue.Text == "0")
                txtValue.Text = numButton;
            else
            {
                if (trueCalc == 1 && !(txtValue.Text.Contains(',')))  //Если выражение ранее было посчитано, и мы не продолжили с запятой при новом вводе TextBox очистится
                {
                    trueCalc = 0;
                    txtValue.Text = "";
                    textBoxNum1 = 0;
                    textBoxNum2 = 0;
                    takedOp = string.Empty;
                }
                txtValue.Text += numButton;
            }

            if (takedOp == string.Empty)
                textBoxNum1 = Double.Parse(txtValue.Text);
            else
                textBoxNum2 = Double.Parse(txtValue.Text);
        }

        private void button_takedOp_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            takedOp = button.Content.ToString();

            if (txtValue.Text != "0")
            {
                textBoxNum1 = Double.Parse(txtValue.Text);
                txtValue.Text = "0";
            }
            else
                txtValue.Text = "0";


        }

        void button_eq_Click(object sender, RoutedEventArgs e)
        {
            double resultCalculate = textBoxNum1;
            switch (takedOp)
            {
                case "+":
                    resultCalculate = textBoxNum1 + textBoxNum2;
                    break;
                case "-":
                    resultCalculate = textBoxNum1 - textBoxNum2;
                    break;
                case "*":
                    resultCalculate = textBoxNum1 * textBoxNum2;
                    break;
                case "avg":
                    resultCalculate = (textBoxNum1 + textBoxNum2) / 2;
                    break;
                case "x^y":
                    resultCalculate = powResult(textBoxNum1, (int)textBoxNum2);
                    break;
                case "/":
                    if (textBoxNum2 == 0)
                    {
                        resultCalculate = 0;
                        break;
                    }
                    else
                        resultCalculate = textBoxNum1 / textBoxNum2;
                    break;
                case "max":
                    resultCalculate = Math.Max(textBoxNum1, textBoxNum2);
                    break;
                case "min":
                    resultCalculate = Math.Min(textBoxNum1, textBoxNum2);
                    break;
            }
            if ((takedOp == "/") && (textBoxNum2 == 0))
            {
                txtValue.Text = "Error";
                takedOp = string.Empty;
                textBoxNum1 = 0;
                textBoxNum2 = 0;
            }
            else
            {
                txtValue.Text = resultCalculate.ToString();
                textBoxNum1 = resultCalculate;
                trueCalc = 1;
            }
        }

        private double powResult(double num, int power) //рекурсия прекольная тема
        {
            if (power == 0)
                return 1;
            return powResult(num, power - 1) * num;
        }

        private void button_C_Click(object sender, RoutedEventArgs e)
        {
            textBoxNum1 = 0;
            textBoxNum2 = 0;
            takedOp = string.Empty;
            txtValue.Text = "0";
        }

        private void button_CE_Click(object sender, RoutedEventArgs e)
        {
            if (takedOp == string.Empty)
                textBoxNum1 = 0;
            else
                textBoxNum2 = 0;
            txtValue.Text = "0";
        }

        private void button_backspace_Click(object sender, RoutedEventArgs e)
        {
            txtValue.Text = DeleteLastChar(txtValue.Text);
            if (takedOp == string.Empty)
            {
                textBoxNum1 = Double.Parse(txtValue.Text);
            }
            else
            {
                textBoxNum2 = Double.Parse(txtValue.Text);
            }
        }

        private string DeleteLastChar(string text)
        {
            if (text.Length == 1)
                text = "0";

            else
            {
                text = text.Remove(text.Length - 1, 1);

                if (text[text.Length - 1] == ',')
                    text = text.Remove(text.Length - 1, 1);
            }
            return text;
        }

        private void button_plusMin_Click(object sender, RoutedEventArgs e)
        {
            if (takedOp == string.Empty)
            {
                textBoxNum1 *= -1;
                txtValue.Text = textBoxNum1.ToString();
            }
            else
            {
                textBoxNum2 *= -1;
                txtValue.Text = textBoxNum2.ToString();
            }
        }

        private void button_comma_Click(object sender, RoutedEventArgs e)
        {
            if (takedOp == string.Empty)
            {

                SetComma(textBoxNum1);
            }
            else
            {
                SetComma(textBoxNum2);

            }
        }

        private void SetComma(double textBoxNum)
        {
            if (txtValue.Text.Contains(','))
                return;

            txtValue.Text += ',';
        }

    }
}
