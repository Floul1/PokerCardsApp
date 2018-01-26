using System;
using System.Windows;
using System.Windows.Threading;
using NewCardsFramework.Poker;

namespace PokerCardsApp.Poker
{
    /// <summary>
    /// Interaction logic for BlindTimerWindow.xaml
    /// </summary>
    public partial class BlindTimerWindow : Window
    {
        private PokerTournament _currentTournament;
        internal static TimeSpan BlindTime;
        private BlindLevel _currentLevel;
        private BlindLevel _nextLevel;
        private DispatcherTimer _uiUpdater;
        private DispatcherTimer _blindTimer;
        private static int _secondsPassed = 0;
        
        private static TimeSpan _timeRemaining = BlindTime.Subtract(TimeSpan.FromSeconds(_secondsPassed));
        /// <summary>
        /// Constructor for Simple Data
        /// </summary>
        public BlindTimerWindow(TimeSpan blindTime,BlindLevel currentLevel)
        {
            
            InitializeComponent();
            BlindTime = blindTime;
            _currentLevel = currentLevel;
            _uiUpdater = new DispatcherTimer {Interval = new TimeSpan(0, 0, 1)}; //Create the UiUpdater
            _uiUpdater.Tick += UiUpdater_Tick;

            _blindTimer = new DispatcherTimer {Interval = blindTime};
            _blindTimer.Tick += BlindTimer_Tick;
        }

        
        private void BlindTimer_Tick(object sender, EventArgs e)
        {
            _blindTimer.Stop();
            _secondsPassed = 0;
            if (_nextLevel != null)
            {
                _currentLevel = _nextLevel;
            }
            _nextLevel = _currentTournament?.TournamentStructure.GetNextLevel(_currentLevel);


            _blindTimer.Start();
            //PlayNextLevelSound
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called every Second to Update the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UiUpdater_Tick(object sender, EventArgs e)
        {
            _secondsPassed++;
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextLevel"></param>
        public void SetNextBlindLevel(BlindLevel nextLevel)
        {
            _nextLevel = nextLevel;
        }
    }
}
