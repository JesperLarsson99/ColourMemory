namespace Colour_Memory
{
    public partial class Form1 : Form
    {
        public List<Button> Cards = new List<Button>();

        public Form1()
        {
            InitializeComponent();

            Cards = SetupCards();

            var gameplayHandler = new GameplayHandler(this);

            gameplayHandler.StartGame();

            foreach (var card in Cards)
            {
                card.Click += gameplayHandler.OnCardClick;
            }
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
    }
}
