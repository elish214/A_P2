using GUI.model;
using GUI.viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        /// <summary>
        /// private view model member.
        /// </summary>
        private SettingsViewModel vm;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SettingsWindow()
        {
            InitializeComponent();
            vm = new SettingsViewModel(new SettingsModel());
            DataContext = vm;
        }

        /// <summary>
        /// click on OK button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveSettings();
            //MainWindow win = (MainWindow)Application.Current.MainWindow;

            try
            {
                model.client.Client.Instance.EndPoint = new IPEndPoint(
                                IPAddress.Parse(Properties.Settings.Default.ServerIP),
                                Properties.Settings.Default.ServerPort);
            }
            catch (Exception e1)
            {
                e1.GetHashCode();
            }

            new MainWindow().Show();
            Close();
        }

        /// <summary>
        /// click on cancel button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow win = (MainWindow)Application.Current.MainWindow;
            new MainWindow().Show();
            Close();
        }
    }
}
