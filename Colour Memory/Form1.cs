using System.Reflection.Metadata.Ecma335;

namespace Colour_Memory;

public partial class Form1 : Form
{
    private List<Button> Cards = new List<Button>();
    private Dictionary<Button, Color> CardColors = new Dictionary<Button, Color>();
    public List<Button> ClickedCards = new List<Button>();

    private GameplayService gameplayHandler;

    private bool allowedToClick = true;

    public Form1()
    {
        InitializeComponent();

        Cards = SetupCards();

        gameplayHandler = new GameplayService();

        SetupGame();

        foreach (var card in Cards)
        {
            card.Click += OnCardClick;
        }
    }

    private async void OnCardClick(object? sender, EventArgs e)
    {
        if (!allowedToClick)
        {
            return;
        }

        var clickedCard = sender as Button;

        if (clickedCard != null)
        {
            ChangeAppearanceOfClickedCard(clickedCard);
            ClickedCards.Add(clickedCard);
        }

        if (ClickedCards.Count == 2)
        {
            allowedToClick = false;

            var matched = await gameplayHandler.HandleTwoCardsClickedAsync(ClickedCards[0], ClickedCards[1]);

            if (matched)
            {
                ClickedCards.ForEach(card => card.Visible = false);
            }
            else
            {
                foreach (var card in ClickedCards)
                {
                    card.Image = Properties.Resources.background;
                    card.Enabled = true;
                }
            }

            ClickedCards.Clear();
            allowedToClick = true;

            pointsLabel.Text = "Poäng: " + gameplayHandler.Points;
        }

        if (!Cards.Any(card => card.Visible))
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        doneWithGameLabel.Text = "Du är nu färdig med detta spel, dina poäng blev: " + gameplayHandler.Points;
        doneWithGameLabel.Visible = true;
        playAgainButton.Visible = true;
    }

    private void ChangeAppearanceOfClickedCard(Button clickedCard)
    {
        clickedCard.BackColor = CardColors[clickedCard];
        clickedCard.Image = null;
        clickedCard.Enabled = false;
    }

    private List<Button> SetupCards()
    {
        return new List<Button>()
        {
            card1,
            card2,
            card3,
            card4,
            card5,
            card6,
            card7,
            card8,
            card9,
            card10,
            card11,
            card12,
            card13,
            card14,
            card15,
            card16
        };
    }

    private void SetupGame()
    {
        var playerScoreList = gameplayHandler.GetPlayerScore();

        playerScoreListview.Columns.Clear();
        playerScoreListview.Columns.Add("Player Name", 100);
        playerScoreListview.Columns.Add("Score", 50);

        AddPlayerScoreListToListbox(playerScoreList);

        var colors = GameSetup.SetupCardColors();

        CardColors = GameSetup.MatchCardsWithColors(colors, Cards);
    }

    private void playAgainButton_Click(object sender, EventArgs e)
    {
        gameplayHandler.ResetPoints();

        SetupGame();

        ResetAllCards();

        playAgainButton.Visible = false;

        pointsLabel.Text = "Poäng: " + gameplayHandler.Points;
        doneWithGameLabel.Visible = false;
    }

    private void ResetAllCards()
    {
        foreach (var card in Cards)
        {
            card.Image = Properties.Resources.background;
            card.Enabled = true;
            card.Visible = true;
        }
    }

    private void AddPlayerScoreListToListbox(List<Player> playerList)
    {
        playerScoreListview.Items.Clear();

        foreach (var playerScore in playerList)
        {
            var listViewItem = new ListViewItem(playerScore.PlayerName);
            listViewItem.SubItems.Add(playerScore.Score.ToString());
            playerScoreListview.Items.Add(listViewItem);
        }
    }
}
