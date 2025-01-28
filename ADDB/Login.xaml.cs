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

namespace ADDB
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTextBox.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (var db = new Entities())
            {
                var user = db.Users.AsNoTracking().FirstOrDefault(p => p.Login == LoginTextBox.Text && p.Password == PasswordBox.Password);

                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    NavigationService.Navigate(new User());
                }
            }
        }
    }
}
