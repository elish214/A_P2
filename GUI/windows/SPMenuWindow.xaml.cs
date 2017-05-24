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
        /// <summary>
        /// private view model member.
        /// </summary>
        private SPMenuViewModel vm;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SPMenuWindow()
        {
            InitializeComponent();
            vm = new SPMenuViewModel(new SPMenuModel());
            DataContext = vm;

            mcm.VM = vm; 
        }

        /// <summary>
        /// click on OK button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            vm.Generate();
            Close();
        }

        /// <summary>
        /// click on cancel button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
