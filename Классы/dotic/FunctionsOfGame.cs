using System;

public class LetsFight
{
   
        public void GetUserInfo()
        {
            Console.Write("Имя? ");
            string inputName = Console.ReadLine();
            Name = string.IsNullOrEmpty(inputName) ? Name : inputName;

            Console.Write("До какого уровня качнешься? ");
            Level = int.TryParse(Console.ReadLine(), out int level) ? level : Level;

            Console.Write("Хпшка? ");
            Health = int.TryParse(Console.ReadLine(), out int health) ? health : Health;

            Console.Write("Атрибуты силы? ");
            Strength = int.TryParse(Console.ReadLine(), out int strength) ? strength : Strength;

            Console.Write("Ловкость (шанс на миссы)? ");
            Agility = int.TryParse(Console.ReadLine(), out int agility) ? agility : Agility;
        }
    }

    public void EndOfBattle(Character character)  //бойка
    {
        NashVoyaka enemy = new NashVoyaka();
        while (enemy.Health > 0)
        {
            Console.Write("attack (напишите): ");
            string ans2 = Console.ReadLine();
            if (ans2 == "attack")
            {
                enemy.Health -= character.Damage;  //корректное уменьшение здоровья врага
                Console.WriteLine($"Вы нанесли {character.Damage} урона. HP Врага: {enemy.Health}");
            }
            else
            {
                Console.WriteLine($"твой HP: {character.Health}");
                Console.WriteLine($"HP Врага: {enemy.Health}");
            }
        }
        Console.WriteLine("Вы победили врага!");
    }


    public void Gluterfunk()  //начало программы
    {
        LetsFight letsFight = new LetsFight();
        Character character = new Character("Player");
        character.OutputInfo();
        Console.WriteLine("Хотите ввести Свои статы? (да/нет)");
        string ans = Console.ReadLine();
        if (ans?.ToLower() == "да")  //учтём регистр ответа
        {
            character.GetUserInfo();
        }
        else
        {
            Console.WriteLine("Ты даже не стараешься ~~~ Anti Mage");
        }

        letsFight.FightTools(character);  //начало боя
    }
}
