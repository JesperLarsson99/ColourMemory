namespace ColourMemory;

public partial class MainForm : Form
{
    private readonly Button[] cards = [];
    private IReadOnlyDictionary<Button, Color> cardsWithMatchingColors = new Dictionary<Button, Color>();
    private readonly List<Button> clickedCards = [];

    private readonly IGameplayService _gameplayService;

    private bool allowedToClick = true;

    private Player? currentPlayer;

    public MainForm(IGameplayService gamePlayService)
    {
        InitializeComponent();

        cards = SetupCards();

        _gameplayService = gamePlayService;

        foreach (var card in cards)
        {
            card.Click += OnCardClick;
        }

        playerScoreListview.Columns.Add("Player Name", 100);
        playerScoreListview.Columns.Add("Score", 50);

        UpdateHighScoreListview();
    }

    private async void OnCardClick(object? sender, EventArgs e)
    {
        if (!allowedToClick)
        {
            return;
        }

        if (sender is Button clickedCard)
        {
            ChangeAppearanceOfClickedCard(clickedCard);
            clickedCards.Add(clickedCard);
        }

        if (clickedCards.Count == 2)
        {
            allowedToClick = false;

            var matched = await _gameplayService.HandleTwoCardsClickedAsync(clickedCards[0], clickedCards[1]);

            if (matched)
            {
                clickedCards.ForEach(card => card.Visible = false);
            }
            else
            {
                foreach (var card in clickedCards)
                {
                    card.Image = Properties.Resources.background;
                    card.Enabled = true;
                }
            }

            clickedCards.Clear();
            allowedToClick = true;

            pointsLabel.Text = "Poäng: " + _gameplayService.GetPoints();
        }

        if (!cards.Any(card => card.Visible))
        {
            currentPlayer!.Score = _gameplayService.GetPoints();
            _gameplayService.SaveScore(currentPlayer);
            ResetGame();

            UpdateHighScoreListview();
        }
    }

    private void ResetGame()
    {
        doneWithGameLabel.Text = "Du är nu färdig med detta spel, dina poäng blev: " + _gameplayService.GetPoints();
        doneWithGameLabel.Visible = true;
        playAgainButton.Visible = true;
    }

    private void ChangeAppearanceOfClickedCard(Button clickedCard)
    {
        clickedCard.BackColor = cardsWithMatchingColors[clickedCard];
        clickedCard.Image = null;
        clickedCard.Enabled = false;
    }

    private void UpdateHighScoreListview()
    {
        var playerScoreList = _gameplayService.GetHighscoreList();

        AddPlayerScoreListToListbox(playerScoreList);
    }

    private Button[] SetupCards()
    {
        return
        [
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
        ];
    }

    private void SetupGame()
    {
        var colors = GameSetup.SetupCardColors();

        cardsWithMatchingColors = GameSetup.MatchCardsWithColors(colors, cards);
    }

    private void PlayAgainButton_Click(object sender, EventArgs e)
    {
        playAgainButton.Visible = false;

        doneWithGameLabel.Visible = false;

        playerNameLabel.Visible = true;
        startGameButton.Visible = true;
        playerNameTextbox.Visible = true;
    }

    private void MakeCardsGameReady()
    {
        foreach (var card in cards)
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

    private void StartGameButton_Click(object sender, EventArgs e)
    {
        _gameplayService.ResetPoints();

        SetupGame();
        MakeCardsGameReady();

        foreach (var card in cards)
        {
            card.Visible = true;
        }

        currentPlayer = new Player(playerNameTextbox.Text);

        playerNameLabel.Visible = false;
        startGameButton.Visible = false;
        playerNameTextbox.Visible = false;
        pointsLabel.Text = "Poäng: " + _gameplayService.GetPoints();
    }
}
