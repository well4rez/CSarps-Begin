using System;
namespace fourthlab
{
    class Program
    {
        static void Main(string[] args)
        {
            
            VehicleCollection collection = new VehicleCollection();
            collection.Add(new Vehicle("Toyota", 2015, 80000));
            collection.Add(new Vehicle("Honda", 2018, 120000));
            collection.Add(new Vehicle("Ford", 2010, 90000));
            collection.Add(new Vehicle("BMW", 2017, 150000));
            Console.WriteLine("кары двигаются больше чем 100,000 km:");
            foreach (var vehicle in collection)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}