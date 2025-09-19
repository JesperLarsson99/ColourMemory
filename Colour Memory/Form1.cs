namespace Colour_Memory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var gameplayHandler = new GameplayHandler();

            gameplayHandler.StartGame();
        }
    }
}
