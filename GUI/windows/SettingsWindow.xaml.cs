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
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private SettingsViewModel vm;
        public SettingsWindow()
        {
            InitializeComponent();
            vm = new SettingsViewModel(new SettingsModel());
            DataContext = vm;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            //MainWindow win = (MainWindow)Application.Current.MainWindow;
            new MainWindow().Show();
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow win = (MainWindow)Application.Current.MainWindow;
            new MainWindow().Show();
            Close();
        }
    }
}
