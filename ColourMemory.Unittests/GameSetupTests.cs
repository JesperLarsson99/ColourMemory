using Shouldly;
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
        listOfColors.Count.ShouldBe(16);
        distinctColors.Count().ShouldBe(8);
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

        Button[] buttons =
        [
            new(),
            new(),
            new(),
            new()
        ];

        //Act
        Dictionary<Button, Color> cardColors = GameSetup.MatchCardsWithColors(listOfColors, buttons);

        //Assert
        cardColors.Count.ShouldBe(listOfColors.Count);

        foreach (var card in cardColors) 
        {
            card.Value.ShouldBeOfType<Color>();
            card.Key.ShouldBeOfType<Button>();
        }
    }
}
