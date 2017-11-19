using Microsoft.Ink;
using System.IO;
using System.Windows;

namespace PokerCardsApp.Cards
{
    /// <summary>
    /// Interaction logic for CardsWhiteboard.xaml
    /// </summary>
    public partial class CardsWhiteboard : Window
    {
        public CardsWhiteboard()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            using (var ms = new MemoryStream())
            {
                TheInkCanvas.Strokes.Save(ms);
                var myInkCollector = new InkCollector();
                var ink = new Ink();
                ink.Load(ms.ToArray());

                using (var context = new RecognizerContext())
                {
                    if (ink.Strokes.Count > 0)
                    {
                        context.Strokes = ink.Strokes;

                        var result = context.Recognize(out var status);
                        string temp = null;
                        foreach (var test in result.GetAlternatesFromSelection())
                        {
                            if (!int.TryParse(test.ToString(), out _)) continue;
                            temp = test.ToString();
                            break;
                        }

                        if (status == RecognitionStatus.NoError)
                        {
                            //TextBox1.Text = result.TopString;
                            if (temp == null)
                            {
                                if (result.TopString.ToString() == "+" || result.TopString == "-")
                                {
                                    temp = result.TopString;
                                }
                                else
                                {
                                    temp = "NaN";
                                }
                            }
                            TextBox1.Text = temp;
                        }
                        else MessageBox.Show("Recognition failed");

                    }
                    else
                        MessageBox.Show("No stroke detected");
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            TheInkCanvas.Strokes.Clear();
        }
    }
}
