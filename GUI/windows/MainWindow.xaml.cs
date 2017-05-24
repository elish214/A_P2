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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                model.client.Client.Instance.EndPoint = new IPEndPoint(
                   IPAddress.Parse(Properties.Settings.Default.ServerIP),
                   Properties.Settings.Default.ServerPort);
            }
            catch (Exception e) { }

        }

        /// <summary>
        /// click on sigle player button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void btnSingle_Click(object sender, RoutedEventArgs e)
        {
            new SPMenuWindow().Show();
            Close();
        }

        /// <summary>
        /// click on multi player button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            new MPMenuWindow().Show();
            Close();
        }

        /// <summary>
        /// click on setting button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            new SettingsWindow().Show();
            Close();
        }
    }
}
