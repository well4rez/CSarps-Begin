using curse3;
using MySql.Data.MySqlClient;

public class GameRepository
{
    private readonly MySqlConnection _connection;

    public GameRepository(MySqlConnection connection)
    {
        _connection = connection;
    }

    public bool Add(Game game)
    {
        string insertQuery = "INSERT INTO games (GameName, PlayerCount, IsMultiplayer) VALUES (@GameName, @PlayerCount, @IsMultiplayer)";
        using (MySqlCommand cmd = new MySqlCommand(insertQuery, _connection))
        {
            cmd.Parameters.AddWithValue("@GameName", game.GameName);
            cmd.Parameters.AddWithValue("@PlayerCount", game.PlayerCount);
            cmd.Parameters.AddWithValue("@IsMultiplayer", game.IsMultiplayer ? 1 : 0);

            int rowInserted = cmd.ExecuteNonQuery();
            if (rowInserted > 0)
                return true;
            return false;
        }
    }

    public bool Delete(int id)
    {
        string deleteQuery = "DELETE FROM games WHERE id = @id";
        using (MySqlCommand cmd = new MySqlCommand(deleteQuery, _connection))
        {
            cmd.Parameters.AddWithValue("@id", id);
            int rowDeleted = cmd.ExecuteNonQuery();
            if (rowDeleted > 0) return true;
            return false;
        }
    }

    public bool Update(Game game)
    {
        string updateQuery = "UPDATE games SET GameName = @GameName, PlayerCount = @PlayerCount, IsMultiplayer = @IsMultiplayer WHERE id = @id";
        using (MySqlCommand cmd = new MySqlCommand(updateQuery, _connection))
        {
            cmd.Parameters.AddWithValue("@GameName", game.GameName);
            cmd.Parameters.AddWithValue("@PlayerCount", game.PlayerCount);
            cmd.Parameters.AddWithValue("@IsMultiplayer", game.IsMultiplayer ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", game.Id);
            int rowUpdated = cmd.ExecuteNonQuery();
            if (rowUpdated > 0) return true;
            return false;
        }
    }

    public Game? Get(int id)
    {
        string selectQuery = "SELECT id, GameName, PlayerCount, IsMultiplayer FROM games WHERE id = @id";
        using (MySqlCommand cmd = new MySqlCommand(selectQuery, _connection))
        {
            cmd.Parameters.AddWithValue("@id", id);

            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    Game game = new Game
                    {
                        Id = reader.GetInt32("id"),
                        GameName = reader.GetString("GameName"),
                        PlayerCount = reader.GetInt32("PlayerCount"),
                        IsMultiplayer = reader.GetInt32("IsMultiplayer") == 1
                    };
                    return game;
                }
            }
        }
        return null;
    }

    public List<Game> GetAll()
    {
        List<Game> games = new List<Game>();
        string selectQuery = "SELECT id, GameName, PlayerCount, IsMultiplayer FROM games";
        using (MySqlCommand conn = new MySqlCommand(selectQuery, _connection))
        using (MySqlDataReader reader = conn.ExecuteReader())
        {
            while (reader.Read())
            {
                Game game = new Game
                {
                    Id = reader.GetInt32("id"),
                    GameName = reader.GetString("GameName"),
                    PlayerCount = reader.GetInt32("PlayerCount"),
                    IsMultiplayer = reader.GetInt32("IsMultiplayer") == 1
                };
                games.Add(game);
            }
            return games;
        }
    }
}