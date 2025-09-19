using Colour_Memory;
using FluentAssertions;
using System.Drawing;
using System.Windows.Forms;

namespace ColourMemory.Unittests;

public class GameSetupTests
{
    [Fact]
    public void SetupCardColors_Should_Give_A_List_Of_A_Duplicate_Of_Eight_Colors_In_A_Random_Order()
    {
        //Arrange & Act
        var listOfColors = GameSetup.SetupCardColors();
        var distinctColors = listOfColors.Distinct();

        //Assert
        listOfColors.Should().HaveCount(16);
        distinctColors.Should().HaveCount(8);
    }

    [Fact]
    public void MatchCardsWithColors_Should_Combine_Cards_With_Colors()
    {
        //Arrange
        var listOfColors = new List<Color>()
        {
            Color.Red,
            Color.Blue,
            Color.Red,
            Color.Blue
        };

        var buttons = new List<Button>()
        {
            new Button(),
            new Button(),
            new Button(),
            new Button()
        };

        //Act
        Dictionary<Button, Color> cardColors = GameSetup.MatchCardsWithColors(listOfColors, buttons);

        //Assert
        cardColors.Should().HaveCount(listOfColors.Count);

        foreach (var card in cardColors) 
        {
            card.Value.Should().BeOfType<Color>();
            card.Key.Should().BeOfType<Button>();
        }
    }
}
