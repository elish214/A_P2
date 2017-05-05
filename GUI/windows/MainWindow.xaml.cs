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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();

            //this.mainControl.Content = new controls.MazeBoard(new DFSMazeGenerator().Generate(8, 8));

        }

        private void btnSingle_Click(object sender, RoutedEventArgs e)
        {
            new SPMenuWindow().Show();
            Close();
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            new MPMenuWindow().Show();
            Close();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            new SettingsWindow().Show();
            Close();
        }
    }
}
