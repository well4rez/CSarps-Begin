using MySql.Data.MySqlClient;
using Mysqlx.Connection;

namespace curse3._2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const string database = "csh_one";

            string connectionString = $"Server=localhost;Database={database};User=root;Password=;Port=3306;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    GameRepository gameRepository = new GameRepository(connection);
                    ApplicationConfiguration.Initialize();
                    Application.Run(new GameListForm(gameRepository));
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message );
                }
            }



        }
    }
}