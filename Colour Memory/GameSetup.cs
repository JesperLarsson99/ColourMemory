namespace Colour_Memory;
internal static class GameSetup
{
    internal static Dictionary<Button, Color> MatchCardsWithColors(List<Color> colors, Form1 form)
    {
        var cardColors = new Dictionary<Button, Color>();

        for (int i = 0; i < form.Cards.Count; i++)
        {
            cardColors.Add(form.Cards[i], colors[i]);
        }

        return cardColors;
    }

    internal static List<Color> SetupCardColors()
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
