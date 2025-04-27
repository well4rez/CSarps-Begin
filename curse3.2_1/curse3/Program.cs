using System;
using MySql.Data.MySqlClient;

namespace curse3
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionStr = "Server=localhost;Database=csh_one;User=root;Password=;Port=3306;";

            using (MySqlConnection connection = new MySqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    GameRepository gameRepository = new GameRepository(connection);
                    GameService gameService = new GameService(gameRepository);
                    Run(gameService);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            static void Run(GameService gameService)
            {
                bool exit = false;
                while (!exit)
                {
                    PrintMenu();
                    string? command = Console.ReadLine();
                    Console.Clear();
                    switch (command)
                    {
                        case "1":
                            gameService.AddGame();
                            break;
                        case "2":
                            gameService.GetAll();
                            break;
                        case "3":
                            gameService.GetOne();
                            break;
                        case "4":
                            gameService.Update();
                            break;
                        case "5":
                            gameService.Delete();
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Не то ввел");
                            break;
                    }
                    Console.WriteLine();
                }
            }

            static void PrintMenu()
            {
                Console.WriteLine("1 - Добавить игру");
                Console.WriteLine("2 - Вывести список всех игр");
                Console.WriteLine("3 - Вывести выбранную вами игру");
                Console.WriteLine("4 - Обновить данные об игре");
                Console.WriteLine("5 - Удалить игру");
                Console.WriteLine("0 - Выход");
            }
        }
    }
}