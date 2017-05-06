using GUI.model;
using GUI.viewmodels;
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

namespace GUI.windows
{
    /// <summary>
    /// Interaction logic for SPMenuWindow.xaml
    /// </summary>
    public partial class SPMenuWindow : Window
    {
        private SPMenuViewModel vm;

        public SPMenuWindow()
        {
            InitializeComponent();
            vm = new SPMenuViewModel(new SPMenuModel());
            DataContext = vm;

            mcm.VM = vm; 
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            vm.Generate();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
