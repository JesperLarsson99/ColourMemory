namespace Colour_Memory;
public class GameplayService(
    IGameplayRepository gameplayRepository) : IGameplayService
{
    private readonly IGameplayRepository _gameplayRepository = gameplayRepository;

    private int points = 0;

    public async Task<bool> HandleTwoCardsClickedAsync(Button clickedButton1, Button clickedButton2)
    {
        bool matched = false;

        await Task.Delay(2000);

        if (clickedButton1.BackColor == clickedButton2.BackColor)
        {
            matched = true;
            points++;
        }
        else 
        {
            matched = false;
            points--;
        }

        return matched;
    }

    public void ResetPoints()
    {
        points = 0;
    }

    public void SaveScore(Player player)
    {
        _gameplayRepository.SaveScore(player);
    }

    public List<Player> GetHighscoreList()
    {
        return _gameplayRepository.GetHighscoreList();
    }

    public int GetPoints()
    {
        return points;
    }
}
