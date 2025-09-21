using System.Data.SQLite;

namespace Colour_Memory;
public class GameplayRepository : IGameplayRepository
{
    string dbPath = $"Data Source={Path.Combine(Application.StartupPath, "colourmemory.db")}";

    public void SaveScore(Player player)
    {
        using (var conn = new SQLiteConnection(dbPath))
        {
            conn.Open();
            string sql = "INSERT INTO Player (PlayerName, Score) VALUES (@name, @score)";
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", player.PlayerName);
                cmd.Parameters.AddWithValue("@score", player.Score);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public List<Player> GetHighscoreList()
    {
        var playerList = new List<Player>();

        using (var conn = new SQLiteConnection(dbPath))
        {
            conn.Open();
            string sql = "Select PlayerName, Score From Player Order By Score Desc";
            using (var cmd = new SQLiteCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var player = new Player();
                    player.PlayerName = reader["PlayerName"].ToString()!;
                    player.Score = int.Parse(reader["Score"].ToString()!);
                    playerList.Add(player);
                }
            }
        }

        return playerList;
    }
}
