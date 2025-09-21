namespace Colour_Memory;
public interface IGameplayRepository
{
    void SaveScore(Player player);

    List<Player> GetHighscoreList();
}
