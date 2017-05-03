using GUI.controls;
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
    /// Interaction logic for SinglePlayerWindow.xaml
    /// </summary>
    public partial class SinglePlayerWindow : Window
    {
        private SinglePlayerViewModel vm;

        public SinglePlayerWindow()
        {
            InitializeComponent();
            vm = new SinglePlayerViewModel(new SinglePlayerModel());
            DataContext = vm;
        }

        private void mainMenu_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void solve_Click(object sender, RoutedEventArgs e)
        {

        }

        private void restartGame_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
