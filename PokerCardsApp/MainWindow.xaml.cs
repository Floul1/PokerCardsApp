using PokerCardsApp.Cards;
using System.Windows;
using PokerCardsApp.Poker;

namespace PokerCardsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new BlindCreator().Show();
        }
    }
}
