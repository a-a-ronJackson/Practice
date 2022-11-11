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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        GameLogic gameLogic = new GameLogic();

        private void PlayerClicksSpace (object sender, RoutedEventArgs e)
        {
            var space = (Button)sender;
            if (!String.IsNullOrWhiteSpace(space.Content?.ToString())) return;
            space.Content = gameLogic.CurrentPlayer;

            var coordinates = space.Tag.ToString().Split(',');
            var xValue = int.Parse(coordinates[0]);
            var yValue = int.Parse(coordinates[1]);

            var buttonPosition = new Position() { x = xValue, y = yValue };
            gameLogic.UpdateBoard(buttonPosition, gameLogic.CurrentPlayer);

            if(gameLogic.PlayerWin())
            {
                WinScreen.Text = $"{gameLogic.CurrentPlayer} WINS!!!";
                WinScreen.Visibility = Visibility.Visible;
            }

            gameLogic.SetNextPlayer();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach( var control in gridBoard.Children)
            {
                if(control is Button)
                {
                    ((Button)control).Content = String.Empty;
                }
            }
            gameLogic = new GameLogic();
            WinScreen.Visibility = Visibility.Collapsed;
        }
    }
}
