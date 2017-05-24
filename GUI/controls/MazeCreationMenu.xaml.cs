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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI.controls
{
    /// <summary>
    /// Interaction logic for MazeCreationMenu.xaml
    /// </summary>
    public partial class MazeCreationMenu : UserControl
    {
        /// <summary>
        /// private ViewModel member.
        /// </summary>
        private MCMenuViewModel vm;

        /// <summary>
        /// public ViewModel Property.
        /// </summary>
        public MCMenuViewModel VM
        {
            get
            {
                return vm;
            }

            set
            {
                vm = value;
                DataContext = vm;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public MazeCreationMenu()
        {
            InitializeComponent();

            VM = new MCMenuViewModel(new MCMenuModel());
            DataContext = VM;
        }
    }
}
