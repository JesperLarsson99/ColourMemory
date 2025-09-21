namespace ColourMemory;
public interface IGameplayRepository
{
    void SaveScore(Player player);

    List<Player> GetHighscoreList();
}
