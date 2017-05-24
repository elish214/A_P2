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
        /// <summary>
        /// private view model member.
        /// </summary>
        private MPMenuViewModel vm;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MPMenuWindow()
        {
            InitializeComponent();
            vm = new MPMenuViewModel(new MPMenuModel());
            DataContext = vm;

            mcm.VM = vm;
            vm.Load();
           
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

        /// <summary>
        /// click on join button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            vm.Join();
            //Close();
        }

        /// <summary>
        /// click on start button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
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

        /// <summary>
        /// click on cancel button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            vm.Close();
            Close();
        }

        private void cboGameList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
