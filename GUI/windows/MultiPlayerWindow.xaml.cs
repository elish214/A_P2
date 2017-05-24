using GUI.model;
using GUI.utils;
using GUI.viewmodels;
using MazeLib;
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
    /// Interaction logic for MultiPlayerWindow.xaml
    /// </summary>
    public partial class MultiPlayerWindow : Window
    {
        /// <summary>
        /// private view model member.
        /// </summary>
        private MultiPlayerViewModel vm;

        /// <summary>
        /// default Constructor.
        /// </summary>
        public MultiPlayerWindow()
        {
            InitializeComponent();
            vm = new MultiPlayerViewModel(new MultiPlayerModel());
            DataContext = vm;

            vm.PropertyChanged += Changed;

            KeyDown += new KeyEventHandler(new MultiPlayerMBKeyHandler(myBoard, vm).KeyDown);

            myBoard.Win += delegate ()
            {
                vm.CloseGame();
                MessageBox.Show("You Win!");
                new MainWindow().Show();
                Close();
            };

            otherBoard.Win += delegate ()
            {
                vm.CloseGame();
                MessageBox.Show("You Lose!");
                new MainWindow().Show();
                Close();
            };
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="maze"> a maze. </param>
        public MultiPlayerWindow(Maze maze) : this()
        {
            myBoard.Maze = maze;
            otherBoard.Maze = maze;
            vm.Model.Maze = maze;
            Title = maze.Name;
        }

        /// <summary>
        /// changing event.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        public void Changed(Object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Move")
            {
                otherBoard.Move(vm.Model.Move.Direction);
            }
            else if (e.PropertyName == "Close")
            {
                vm.PropertyChanged -= Changed;
                vm.CloseGame();
                MessageBox.Show("Other Player Closed Game!");
                new MainWindow().Show();
                Close();
            }
        }

        /// <summary>
        /// click on restart button.
        /// </summary>
        /// <param name="sender"> a sender. </param>
        /// <param name="e"> an event. </param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.PropertyChanged -= Changed;
            vm.CloseGame();
            new MainWindow().Show();
            Close();
        }
    }
}
