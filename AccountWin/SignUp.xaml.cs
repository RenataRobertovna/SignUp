using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PasswordCheck;

namespace AccountWin
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button_Register_Click(object sender, RoutedEventArgs e)
        {
            string password = input_Password1.Password;

            Password pass = new Password();
            //pass.Error += ErrorMessage;
            //pass.Success += SuccessMessage;

            bool minLength = pass.MinLength(password);
            bool checkSymbols = pass.CheckSymbols(password);
            bool checkAlphabet = pass.CheckAlphabet(password);

            if (minLength && checkSymbols && checkAlphabet)
            {
                //SuccessMessage("Всё OK");
            }
            else
            {
                //ErrorMessage("Пароль не соответствует требованиям");
            }
        }

        private void button_Clear_Click(object sender, RoutedEventArgs e)
        {
            input_Login.Clear();
            input_Password1.Clear();
            input_Password2.Clear();
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                Close();
            }
        }
        
        private void input_Password1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ch_minlength.Visibility = Visibility.Visible;
            ch_symbols.Visibility = Visibility.Visible;
            ch_alfabet.Visibility = Visibility.Visible;
            ch_compare.Visibility = Visibility.Hidden;
            Password pass = new Password();
            
            string password = input_Password1.Password;
            if (pass.MinLength(password))
            {
                ch_minlength.IsChecked = true;
                ch_minlength.Content = "Число символов удовлетворяет";
                ch_minlength.Foreground = Brushes.Green;
            }
            else
            {
                ch_minlength.IsChecked = false;
                ch_minlength.Content = "Длина пароля меньше 8 символов";
                ch_minlength.Foreground = Brushes.Red;
            }
            if (pass.CheckSymbols(password))
            {
                ch_symbols.IsChecked = true;
                ch_symbols.Content = "Пароль удовлетворяет требованиям";
                ch_symbols.Foreground = Brushes.Green;
            }
            else
            {
                ch_symbols.IsChecked = false;
                ch_symbols.Content = "Пароль не удовлетворяет требованиям";
                ch_symbols.Foreground = Brushes.Red;
            }
            if (pass.CheckAlphabet(password))
            {
                ch_alfabet.IsChecked = true;
                ch_alfabet.Content = "Пароль не содержит недопустимых символов";
                ch_alfabet.Foreground = Brushes.Green;
            }
            else
            {
                ch_alfabet.IsChecked = false;
                ch_alfabet.Content = "Пароль содержит недопустимых символов";
                ch_alfabet.Foreground = Brushes.Red;
            }
        }

        private void input_Password2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ch_minlength.Visibility = Visibility.Hidden;
            ch_symbols.Visibility = Visibility.Hidden;
            ch_alfabet.Visibility = Visibility.Hidden;
            ch_compare.Visibility = Visibility.Visible;

            if (input_Password2.Password == input_Password1.Password)
            {
                ch_compare.IsChecked = true;
                ch_compare.Content = "Пароли совпадают";
                ch_compare.Foreground = Brushes.Green;
            }
            else
            {
                ch_compare.IsChecked = false;
                ch_compare.Content = "Пароли не совпадают";
                ch_compare.Foreground = Brushes.Red;
            }
        }
    }
}
