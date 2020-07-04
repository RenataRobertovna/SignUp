﻿using System;
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
using MySql.Data.MySqlClient;

namespace AccountWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_LogIn_Click(object sender, RoutedEventArgs e)
        {
            var login = input_Login.Text;
            var password = input_Password.Password;
            
            const string host = "mysql11.hostland.ru";
            const string database = "host1323541_suptest2";
            const string port = "3306";
            const string username = "host1323541_itstep";
            const string pass = "269f43dc";
            const string ConnString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + pass;
            
            var db = new MySqlConnection(ConnString);
            db.Open();

            var sql = $"SELECT login, pass FROM Account WHERE login = '{login}'";
            var command = new MySqlCommand {Connection = db, CommandText = sql};
            var result = command.ExecuteReader();

            if (!result.Read())
            {
                MessageBox.Show("Такого пользователя нет", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (result.GetString(0) == login && result.GetString(1) == password)
                {
                    MessageBox.Show("Вход разрешён", "УСПЕХ", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void button_Clear_Click(object sender, RoutedEventArgs e)
        {
            input_Login.Clear();
            input_Password.Clear();
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                Close();
            }
        }

        private void hyper_SignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            Close();
        }

        private void hyper_RestorePassword_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
