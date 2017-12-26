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
        public List<BlindLevel> CurrentBlindsDisplayed = new List<BlindLevel>();
        public BlindCreator()
        {
            InitializeComponent();
            BlindsListBox.ItemsSource = CurrentBlindsDisplayed;
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

        private void AddBlindButton_Click(object sender, RoutedEventArgs e)
        {
            
            var addLevel = new BlindLevel();
            if (int.TryParse(BigBlindBox.Text, out addLevel.BigBlind) && int.TryParse(SmallBlindBox.Text, out addLevel.SmallBlind))
            {
                int.TryParse(AnteBox.Text, out addLevel.Ante);
                CurrentBlindsDisplayed.Add(addLevel);               
            }
            
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (BlindsListBox.SelectedItems.Count == 0) return;
            foreach (BlindLevel item in BlindsListBox.SelectedItems)
            {
                CurrentBlindsDisplayed.Remove(item);
            }
            
        }

        private void LoadAndSaveBasic()
        {
            
        }
    }
}
