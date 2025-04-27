using System;
using System.Collections.Generic;

namespace curse3
{
    public class GameService
    {
        private readonly GameRepository _gameRepository;

        public GameService(GameRepository repository)
        {
            _gameRepository = repository;
        }
        private int ParseInt()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out var playerCount))
                {
                    return playerCount;
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите число");
                }
            }
        }
        public void AddGame()
        {
            Console.WriteLine("Добавить игру");
            Console.Write("Имя игры: ");
            var gameName = Console.ReadLine()!;
            Console.WriteLine("Количество игроков (онлайн):");
            int playerCount = ParseInt();
            Console.WriteLine("Является ли игра мультиплеерной? (да/нет)");
            string multiplayerInput = Console.ReadLine()!.ToLower();
            bool isMultiplayer = multiplayerInput == "да";

            var result = _gameRepository.Add(new Game(gameName, playerCount, isMultiplayer));

        }

        public void GetAll()
        {
            Console.WriteLine("Список всех игр");
            Console.WriteLine("ID\tКоличество_игроков (Онлайн)\tНазвание\tМультиплеер");
            var games = _gameRepository.GetAll();
            foreach (var game in games)
                Console.WriteLine($"{game.Id}\t{game.PlayerCount}\t{game.GameName}\t{(game.IsMultiplayer ? "Да" : "Нет")}");
        }

        public void GetOne()
        {
            Console.WriteLine("Вывод конкретной игры");
            Console.WriteLine("Введите Id игры");
            int id = ParseInt();
            var game = _gameRepository.Get(id);
            if (game == null)
            {
                Console.WriteLine("Игра с таким id не найдена.");
                return;
            }
            Console.WriteLine("ID\tКоличество_игроков\tНазвание\tМультиплеер");
            Console.WriteLine($"{game.Id}\t{game.PlayerCount}\t{game.GameName}\t{(game.IsMultiplayer ? "Да" : "Нет")}");
        }

        public void Delete()
        {
            Console.WriteLine("Удаление игры");
            Console.WriteLine("Введите Id игры");
            int id = ParseInt();
            var result = _gameRepository.Delete(id);
            if (result)
            {
                Console.WriteLine("Игра успешно удалена!");
            }
            else
            {
                Console.WriteLine("Игра не удалена! Что-то тут не так");
            }
        }

        public void Update()
        {
            Console.WriteLine("Обновление ячейки игры");
            Console.WriteLine("Введите id игры");
            var gameId = ParseInt();
            Console.WriteLine("Название игры: ");
            var gameName = Console.ReadLine()!;
            Console.WriteLine("Количество игроков");
            int playerCount = ParseInt();
            

            Console.WriteLine("Является ли игра мультиплеерной? (да/нет)");
            string multiplayerInput = Console.ReadLine()!.ToLower();
            bool isMultiplayer = multiplayerInput == "да";

            var result = _gameRepository.Update(new Game(gameId, gameName, playerCount, isMultiplayer));
            if (result)
            {
                Console.WriteLine("Пользователь успешно обновлен!");
            }
            else
            {
                Console.WriteLine("Игра не обновлена. Да чтож такое-то!");
            }
        }
    }
}