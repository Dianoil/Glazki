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
using Glazki.Class;
using static Glazki.Class.AgentExtension;
using static Glazki.View.Windows.ListAgent;

namespace Glazki.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthUser.xaml
    /// </summary>
    public partial class AuthUser : Window
    {
        public AuthUser()
        {
            InitializeComponent();
            Load();
        }
        int capthaPerem = 0;
        private void Load()
        {
            Captha captha = new Captha();
            string per = captha.Capthat;
            CapthaNBlock.Text = per;
        }

        private void EntryButton_Click(object sender, RoutedEventArgs e)
        {
            ListAgent listAgent = new ListAgent();
            this.Hide();
            listAgent.ShowDialog();
        }

        private void EntryForAccButton_Click(object sender, RoutedEventArgs e)
        {
            Model.User user = glazkiEntities.User.ToList().Where(i => i.login == loginTBox.Text && i.password == passwordTBox.Text).FirstOrDefault();
            if (capthaPerem == 1)
            {
                try
                {
                    if (user != null)
                    {
                        if (user.idRole == 1)
                        {
                            MessageBox.Show("У вас роль администратора. Вход выполнен успешно", "Авторизация", MessageBoxButton.OK,
                                MessageBoxImage.Information);
                            ListAgent listAgent = new ListAgent();
                            listAgent.AddAgent.Visibility = Visibility.Visible;
                            this.Hide();
                            listAgent.ShowDialog();
                            
                        }
                        else if (user.idRole == 2)
                        {
                            MessageBox.Show("У вас роль пользователя. Вход выполнен успешно", "Авторизация", MessageBoxButton.OK,
    MessageBoxImage.Information);
                            ListAgent listAgent = new ListAgent();
                            this.Hide();
                            listAgent.ShowDialog();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Введены значения неверно или не введены вовсе", "Авторизация", MessageBoxButton.OK,
MessageBoxImage.Information);
                        CapthaNBlock.Text = "";
                        Load();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Введите сначало капчу", "Проверка капчи", MessageBoxButton.OK,
    MessageBoxImage.Information);
                CapthaNBlock.Text = "";
                Load();
            }
        }
        #region Focus
        private void loginTBox_GotFocus(object sender, RoutedEventArgs e)
        { 
            if (loginTBox.Text == "Логин")
            {
                loginTBox.Text = "";
            }
        }

        private void loginTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (loginTBox.Text == "")
            {
                loginTBox.Text = "Логин";
            }
        }

        private void passwordTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passwordTBox.Text == "Пароль")
            {
                passwordTBox.Text = "";
            }

        }

        private void passwordTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordTBox.Text == "")
            {
                passwordTBox.Text = "Пароль";
            }

        }

        private void OtvetTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (OtvetTBox.Text == "Тут ответ на капчу")
            {
                OtvetTBox.Text = "";
            }

        }

        private void OtvetTBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (OtvetTBox.Text == "")
            {
                OtvetTBox.Text = "Тут ответ на капчу";
            }

        }
        #endregion

        private void UpdateCapthaButton_Click(object sender, RoutedEventArgs e)
        {
            CapthaNBlock.Text = "";
            Load();
        }

        private void ProtectedCapthaButton_Click(object sender, RoutedEventArgs e)
        {
            if (CapthaNBlock.Text == OtvetTBox.Text)
            {
                MessageBox.Show("Капча введена верно, теперь можно авторизоваться", "Проверка капчи", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                capthaPerem = 1;
            }
            else if (OtvetTBox.Text == "")
            {
                MessageBox.Show("Введите капчу, значение не введено", "Проверка капчи", MessageBoxButton.OK,
    MessageBoxImage.Warning);
                CapthaNBlock.Text = "";
                Load();
            }
            else
            {
                MessageBox.Show("Введено неверно", "Проверка капчи", MessageBoxButton.OK,
MessageBoxImage.Warning);
                CapthaNBlock.Text = "";
                Load();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
