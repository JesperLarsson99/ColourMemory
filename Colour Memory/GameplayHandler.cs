namespace Colour_Memory;
internal class GameplayHandler(Form1 form)
{
    internal Dictionary<Button, Color> cardColors = new Dictionary<Button, Color>();

    internal void StartGame()
    {
        var colors = GameSetup.SetupCardColors();

        cardColors = GameSetup.MatchCardsWithColors(colors, form);
    }

    internal void OnCardClick(object? sender, EventArgs e)
    {
        var clickedCard = sender as Button;

        if (clickedCard != null)
        {
            clickedCard.BackColor = cardColors[clickedCard];
            clickedCard.Image = null;
        }
    }
}
