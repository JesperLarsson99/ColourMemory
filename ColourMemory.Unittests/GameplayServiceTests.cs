using Colour_Memory;
using FluentAssertions;
using NSubstitute;
using System.Drawing;
using System.Windows.Forms;

namespace ColourMemory.Unittests;
public class GameplayServiceTests
{
    [Fact]
    public async Task HandleTwoCardsClickedAsync_Should_Return_Matched_And_Increase_Points_If_Colors_Does_Match()
    {
        //Arrange
        Button button1 = new Button
        {
            BackColor = Color.Blue
        };

        Button button2 = new Button
        {
            BackColor = Color.Blue
        };

        var gameplayRepositorySubstitute = Substitute.For<IGameplayRepository>();

        var sut = new GameplayService(gameplayRepositorySubstitute);

        //Act & Assert

        sut.GetPoints().Should().Be(0);

        var matched = await sut.HandleTwoCardsClickedAsync(button1, button2);

        matched.Should().BeTrue();

        sut.GetPoints().Should().Be(1);
    }

    [Fact]
    public async Task HandleTwoCardsClickedAsync_Should_Return_Not_Matched_And_Decrease_Points_If_Colors_Does_Not_Match()
    {
        //Arrange
        Button button1 = new Button
        {
            BackColor = Color.Blue
        };

        Button button2 = new Button
        {
            BackColor = Color.Red
        };

        var gameplayRepositorySubstitute = Substitute.For<IGameplayRepository>();

        var sut = new GameplayService(gameplayRepositorySubstitute);

        //Act & Assert

        sut.GetPoints().Should().Be(0);

        var matched = await sut.HandleTwoCardsClickedAsync(button1, button2);

        matched.Should().BeFalse();

        sut.GetPoints().Should().Be(-1);
    }
}
