namespace Colour_Memory;
public class GameplayService
{
    GameplayRepository gameplayRepository = new GameplayRepository();
    public int Points { get; private set; } = 0;

    public async Task<bool> HandleTwoCardsClickedAsync(Button clickedButton1, Button clickedButton2)
    {
        bool matched = false;

        await Task.Delay(2000);

        if (clickedButton1.BackColor == clickedButton2.BackColor)
        {
            matched = true;
            Points++;
        }
        else 
        {
            matched = false;
            Points--;
        }

        return matched;
    }

    public void ResetPoints()
    {
        Points = 0;
    }

    public void SaveScore(string name, int score)
    {
        gameplayRepository.SaveScore(name, score);
    }

    public List<Player> GetPlayerScore()
    {
        return gameplayRepository.GetPlayerScore();
    }
}
