namespace ColourMemory;
public static class GameSetup
{
    public static Dictionary<Button, Color> MatchCardsWithColors(List<Color> colors, Button[] cards)
    {
        var cardColors = new Dictionary<Button, Color>();

        for (int i = 0; i < cards.Length; i++)
        {
            cardColors.Add(cards[i], colors[i]);
        }

        return cardColors;
    }

    public static List<Color> SetupCardColors()
    {
        var randomGuid = Guid.NewGuid().GetHashCode();
        var random = new Random(randomGuid);

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
