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
            Password pass = new Password();
            
            string password = input_Password1.Password;
            if (pass.MinLength(password))
            {
                
            }
            pass.CheckSymbols(password);
            pass.CheckAlphabet(password);
        }
    }
}
