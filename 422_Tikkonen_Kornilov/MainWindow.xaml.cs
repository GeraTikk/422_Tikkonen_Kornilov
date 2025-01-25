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

namespace _422_Tikkonen_Kornilov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(InputXTextBox.Text) || string.IsNullOrWhiteSpace(InputBTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите значения x и b.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(InputXTextBox.Text, out double x) || !double.TryParse(InputBTextBox.Text, out double b))
            {
                MessageBox.Show("Введите корректные числа для x и b.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double f_x = 0;
            if (RadioButtonSh.IsChecked == true)
            {
                f_x = Math.Sinh(x);
            }
            else if (RadioButtonX2.IsChecked == true)
            {
                f_x = x * x;
            }
            else if (RadioButtonEx.IsChecked == true)
            {
                f_x = Math.Exp(x); 
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите функцию.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double result;
            if (x*b > 0.5 && x*b < 10)
            {
                result = Math.Exp(f_x - Math.Abs(b));
            }
            else if (x*b > 0.1 && x*b < 0.5)
            {
                result = Math.Sqrt(Math.Abs(f_x + b));
            }
            else
            {
                result = 2 * (f_x * f_x);
            } 

            ResultTextBox.Text = result.ToString();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputXTextBox.Text = string.Empty;
            InputBTextBox.Text = string.Empty;
            ResultTextBox.Text = string.Empty;
            RadioButtonSh.IsChecked = false;
            RadioButtonX2.IsChecked = false;
            RadioButtonEx.IsChecked = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}