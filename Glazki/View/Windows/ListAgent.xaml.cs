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
using static Glazki.Class.AgentExtension;
namespace Glazki.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для ListAgent.xaml
    /// </summary>
    public partial class ListAgent : Window
    {
        private int ItemsPerPage = 10;
        private int CurrentPage = 0;
        public List<Model.Agent> FilteredAgentList;

        public ListAgent()
        {
            InitializeComponent();
            lvAgent.ItemsSource = GetAgents();

            var typeAgentList = Class.AgentExtension.GetAgentTypes();
            typeAgentList.Insert(0, new Model.AgentType { Title = "Все" });

            FiltCBox.ItemsSource = typeAgentList;
            FilteredAgentList = Class.AgentExtension.GetAgents();

            GeneragePageButtons();
            ChangePage();
        }
        public void UpdateListAgent()
        {
            if (SortCBox is null || FiltCBox is null || SearchTBox is null)
            {
                return;
            }
            FilteredAgentList = Class.AgentExtension.GetAgents();
            var MaterialCount = FilteredAgentList.Count();
            if (SearchTBox.Text.Length != 0)
            {
                FilteredAgentList = FilteredAgentList.Where(m => m.Title.Contains(SearchTBox.Text) || m.Phone.Contains(SearchTBox.Text) ||
                m.Email.Contains(SearchTBox.Text) == true).ToList();
            }
            switch (((ComboBoxItem)SortCBox.SelectedItem).Content.ToString())
            {
                case "По возрастанию Наименование":
                    FilteredAgentList = FilteredAgentList.OrderBy(m => m.Title).ToList();
                    break;
                case "По убыванию Наименование":
                    FilteredAgentList = FilteredAgentList.OrderByDescending(m => m.Title).ToList();
                    break;
                case "По возрастанию Размер скидки":
                    FilteredAgentList = FilteredAgentList.OrderBy(m => m.Percent).ToList();
                    break;
                case "По убыванию Размер скидки":
                    FilteredAgentList = FilteredAgentList.OrderBy(m => m.Percent).ToList();
                    break;
                case "По возрастанию Проиритет агента":
                    FilteredAgentList = FilteredAgentList.OrderBy(m => m.Priority).ToList();
                    break;
                case "По убыванию Проиритет агента":
                    FilteredAgentList = FilteredAgentList.OrderBy(m => m.Priority).ToList();
                    break;
            }
            if (((Model.AgentType)FiltCBox.SelectedItem).Title != "Все")
            {
                FilteredAgentList = FilteredAgentList.Where(m => m.AgentType == ((Model.AgentType)FiltCBox.SelectedItem)).ToList();
            }
            var filtetiedMaterialCoint = FilteredAgentList.Count;

            tbMaterialCount.Text = $"Выведено {filtetiedMaterialCoint} из {MaterialCount}";
            lvAgent.ItemsSource = FilteredAgentList.Skip(CurrentPage * ItemsPerPage).Take(ItemsPerPage);

        }

        private void FiltCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SortCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddAgent_Click(object sender, RoutedEventArgs e)
        {
            AddPercon addPercon = new AddPercon();
            this.IsEnabled = true;
            addPercon.ShowDialog();
        }

        private void RebootMinCoust_Click(object sender, RoutedEventArgs e)
        {
            UpdateCountAgent updateCountAgent = new UpdateCountAgent();
            this.IsEnabled = true;
            updateCountAgent.ShowDialog();
        }

        private void lvAgent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            UpdateCountAgent updateCountAgent = new UpdateCountAgent();
            this.IsEnabled = true;
            updateCountAgent.ShowDialog();
        }

        private void SearchTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateListAgent();
        }
    }
}
