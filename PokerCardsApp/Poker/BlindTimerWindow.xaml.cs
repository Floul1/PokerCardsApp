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
        private BlindLevel CurrentLevel;
        private DispatcherTimer UiUpdater;
        private DispatcherTimer BlindTimer;
        private static int SecondsPassed = 0;
        private static TimeSpan TimeRemaining = BlindTime.Subtract(TimeSpan.FromSeconds(SecondsPassed));
        /// <summary>
        /// Constructor for Simple Data
        /// </summary>
        public BlindTimerWindow(TimeSpan blindTime)
        {
            
            InitializeComponent();
            BlindTime = blindTime;
            UiUpdater = new DispatcherTimer {Interval = new TimeSpan(0, 0, 1)}; //Create the UiUpdater
            UiUpdater.Tick += UiUpdater_Tick;

            BlindTimer = new DispatcherTimer {Interval = blindTime};
            BlindTimer.Tick += BlindTimer_Tick;
        }

        
        private void BlindTimer_Tick(object sender, EventArgs e)
        {
            SecondsPassed = 0;
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
            SecondsPassed++;
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        public void SetNextBlindLevel(BlindLevel)
        {

        }
    }
}
