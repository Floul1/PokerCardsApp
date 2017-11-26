using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using NewCardsFramework.Poker;
using ProtoBuf;

namespace PokerCardsApp.Poker
{
    /// <summary>
    /// Interaction logic for BlindCreator.xaml
    /// </summary>
    public partial class BlindCreator : Window
    {
        public BlindCreator()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var tourney = new PokerTournamentStructure
            {
                BlindTimes = new TimeSpan(0, 20, 0),
                RebuyAllowed = false,
                StructureName = "Test Structure"
            };
            var levels = new List<BlindLevel>
            {
                new BlindLevel(50,100,0),
                new BlindLevel(75,150,0),
                new BlindLevel(100,200,0),
                new BlindLevel(100,200,25),
                new BlindLevel(150,300,25),
                new BlindLevel(200,400,50),
                new BlindLevel(250,500,50),
                new BlindLevel(300,600,75),
                new BlindLevel(400,800,100),
                new BlindLevel(500,1000,100)
            };
            tourney.BlindLevels = levels;
            var file = File.Open(@"C:\memes\test.tournament", FileMode.OpenOrCreate);
            Serializer.Serialize(file, tourney);
            file.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            using (var file = File.Open(@"C:\memes\test.tournament", FileMode.Open))
            {
                var results = Serializer.Deserialize<PokerTournamentStructure>(file);
            }
        }
    }
}
