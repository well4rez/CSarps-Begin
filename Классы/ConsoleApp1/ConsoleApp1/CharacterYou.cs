using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CharacterUmolStats
    {
        public string Name = "player";
        public int Level = 1;
        public int Health = 100;
        public int Strength = 1;
        public int Agility = 5;
        public bool LifeStatus = true;

        public int Damage
        {
            get { return Strength * 2; }
        }

        public void OutputInfo()
        {
            Console.WriteLine("Ваши дефолтные значения: ");
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Левел: {Level}");
            Console.WriteLine($"Здоровье: {Health}");
            Console.WriteLine($"Сила: {Strength}");
            Console.WriteLine($"Урон: {Damage}");
            Console.WriteLine($"Ловкость: {Agility}");
        }
    
}
}
