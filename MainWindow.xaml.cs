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

namespace calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            
            ACButton.Click += ACButton_Click;
            dotButton.Click += dotButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
                //nada
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
            resultLabel.Content = $"{resultLabel.Content}.";
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber = lastNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Substract(lastNumber, newNumber);
                        break;

    
                }
                resultLabel.Content = result.ToString();
            }

        }

      

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

       /* private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
           if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }*/

        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        //operation button handler method
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "";
            }

            if (sender == MultiplyButton)
                selectedOperator = SelectedOperator.Multiplication;

            if (sender == divideButton)
                selectedOperator = SelectedOperator.Division;

            if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;

            if (sender == minusButton)
                selectedOperator = SelectedOperator.Substraction;
        }

            private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton)
                selectedValue = 0;
            if (sender == oneButton)
                selectedValue = 1;
            if (sender == twoButton)
                selectedValue = 2;
            if (sender == threeButton)
                selectedValue = 3;
            if (sender == fourButton)
                selectedValue = 4;
            if (sender == fiveButton)
                selectedValue = 5;
            if (sender == sixButton)
                selectedValue = 6;
            if (sender == sevenButton)
                selectedValue = 7;
            if (sender == eightButton)
                selectedValue = 8;
            if (sender == nineButton)
                selectedValue = 9;


            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Substract(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Divide(double n1, double n2)
        {
            if(n2 == 0)
            {
                //displaiyng a error message box 
                MessageBox.Show("Divison by 0 is not supported", "Wrong operation",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        } 
        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }
    }
}
