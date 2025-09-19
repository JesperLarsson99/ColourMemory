namespace Colour_Memory;
public static class GameSetup
{
    public static Dictionary<Button, Color> MatchCardsWithColors(List<Color> colors, List<Button> cards)
    {
        var cardColors = new Dictionary<Button, Color>();

        for (int i = 0; i < cards.Count; i++)
        {
            cardColors.Add(cards[i], colors[i]);
        }

        return cardColors;
    }

    public static List<Color> SetupCardColors()
    {
        var random = new Random();

        var colors = new List<Color>()
        {
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Pink,
            Color.Brown,
            Color.Yellow,
            Color.Black,
            Color.Orange,
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Pink,
            Color.Brown,
            Color.Yellow,
            Color.Black,
            Color.Orange
        }.OrderBy(c => random.Next()).ToList();

        return colors;
    }
}
