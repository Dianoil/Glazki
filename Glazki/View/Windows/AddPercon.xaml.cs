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

namespace Glazki.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPercon.xaml
    /// </summary>
    public partial class AddPercon : Window
    {
        public AddPercon()
        {
            InitializeComponent();
        }

        private void SaveInfo_Click(object sender, RoutedEventArgs e)
        {
            ListAgent listAgent = new ListAgent();
            this.Hide();
            listAgent.IsEnabled = false;
        }

        private void backForList_Click(object sender, RoutedEventArgs e)
        {
            ListAgent listAgent = new ListAgent();
            this.Hide();
            listAgent.IsEnabled = false;
        }
    }
}
