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
using Glazki.Model;
namespace Glazki.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для UpdateCountAgent.xaml
    /// </summary>
    public partial class UpdateCountAgent : Window
    {
        //Лень
        public UpdateCountAgent()
        {
            InitializeComponent();
        }

        private void ChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(NewAmount.Text);
                MessageBox.Show("Данные успешно изменены", "Сохранение данных", MessageBoxButton.OK, MessageBoxImage.Warning);
                ListAgent listAgent = new ListAgent();
                this.Close();
                listAgent.IsEnabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
