namespace ColourMemory;
public interface IGameplayService
{
    Task<bool> HandleTwoCardsClickedAsync(Button clickedButton1, Button clickedButton2);

    void ResetPoints();

    void SaveScore(Player player);

    List<Player> GetHighscoreList();

    int GetPoints();
}
