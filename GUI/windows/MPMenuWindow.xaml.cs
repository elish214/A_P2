using GUI.model;
using GUI.viewmodels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace GUI.windows
{
    /// <summary>
    /// Interaction logic for MPMenuWindow.xaml
    /// </summary>
    public partial class MPMenuWindow : Window
    {
        private MPMenuViewModel vm;

        public MPMenuWindow()
        {
            InitializeComponent();
            vm = new MPMenuViewModel(new MPMenuModel());
            DataContext = vm;

            mcm.VM = vm;
            vm.Load();
            //cboGameList.ItemsSource = vm.GamesList;
            vm.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    if (e.PropertyName == "Maze")
                    {
                        new MultiPlayerWindow(vm.Model.Maze).Show();
                        Close();
                    }
                };
        }

        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            vm.Join();
            //Close();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            // wait until get a maze
            waiting.Visibility = Visibility.Visible;
            vm.Start();
            //Close();

            cboGameList.IsEnabled = false;
            btnJoin.IsEnabled = false;
            mcm.IsEnabled = false;
            btnCancel.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            vm.Close();
            Close();
        }

        private void cboGameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // is needed?
        }

    }
}
