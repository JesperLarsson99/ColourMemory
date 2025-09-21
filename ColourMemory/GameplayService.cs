namespace ColourMemory;
public class GameplayService(
    IGameplayRepository gameplayRepository,
    GameConfig gameConfig) : IGameplayService
{

    private int points = 0;

    public async Task<bool> HandleTwoCardsClickedAsync(Button clickedCard1, Button clickedCard2)
    {
        await Task.Delay(gameConfig.WaitTimeMs);

        if (clickedCard1.BackColor == clickedCard2.BackColor)
        {
            points++;
            return true;
        }

        points--;
        return false;
    }

    public void ResetPoints()
    {
        points = 0;
    }

    public void SaveScore(Player player)
    {
        gameplayRepository.SaveScore(player);
    }

    public List<Player> GetHighscoreList()
    {
        return gameplayRepository.GetHighscoreList();
    }

    public int GetPoints()
    {
        return points;
    }
}
