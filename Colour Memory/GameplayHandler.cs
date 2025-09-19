namespace Colour_Memory;
internal class GameplayHandler(Form1 form)
{
    internal Dictionary<Button, Color> CardColors = new Dictionary<Button, Color>();
    internal List<Button> ClickedCards = new List<Button>();

    private bool allowedToClick = true;

    internal void StartGame()
    {
        var colors = GameSetup.SetupCardColors();

        CardColors = GameSetup.MatchCardsWithColors(colors, form);
    }

    internal void OnCardClick(object? sender, EventArgs e)
    {
        if (!allowedToClick)
        {
            return;
        }

        var clickedCard = sender as Button;

        if (clickedCard != null)
        {
            clickedCard.BackColor = CardColors[clickedCard];
            clickedCard.Image = null;
            clickedCard.Enabled = false;
            ClickedCards.Add(clickedCard);
        }

        if (ClickedCards.Count == 2)
        {
            allowedToClick = false;
            
            var timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000;

            timer.Tick += (s, args) =>
            {
                timer.Stop();

                if (ClickedCards[0].BackColor == ClickedCards[1].BackColor)
                {
                    ClickedCards.ForEach(card => card.Visible = false);
                }
                else 
                {
                    ClickedCards.ForEach(card => card.Image = Properties.Resources.background);

                    foreach (var card in ClickedCards)
                    {
                        card.Image = Properties.Resources.background;
                        card.Enabled = true;
                    }
                }

                ClickedCards.Clear();
                allowedToClick = true;
            };

            timer.Start();
        }
    }
}
