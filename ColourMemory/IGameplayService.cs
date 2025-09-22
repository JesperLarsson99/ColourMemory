namespace ColourMemory;
public interface IGameplayService
{
    Task<bool> HandleTwoCardsClickedAsync(Button clickedCard1, Button clickedCard2);

    void ResetPoints();

    void SaveScore(Player player);

    List<Player> GetHighscoreList();

    int GetPoints();
}
