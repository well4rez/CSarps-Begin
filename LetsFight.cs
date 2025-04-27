using System;

public class LetsFight
{
    public void FightTools(Character character)
    {
        NashVoyaka enemy = new NashVoyaka();
        while (enemy.Health > 0)
        {
            Console.Write("attack (напишите): ");
            string ans2 = Console.ReadLine();
            if (ans2 == "attack")
            {
                enemy.Health -= character.Damage;
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

    public static void Main(string[] args)
    {
        LetsFight letsFight = new LetsFight();
        Character character = new Character("Player");
        character.OutputInfo();

        Console.WriteLine("Хотите ввести Свои статы? (да/нет)");
        string ans = Console.ReadLine();
        if (ans?.ToLower() == "да")
        {
            character.GetUserInfo();
        }
        else
        {
            Console.WriteLine("Ты даже не стараешься ~~~ Anti Mage");
        }

        letsFight.FightTools(character);
    }
}
