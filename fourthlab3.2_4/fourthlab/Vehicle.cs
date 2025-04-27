public class Vehicle
{
    public string Make { get; set; } 
    public int Year { get; set; }    
    public int Mileage { get; set; } 

    public Vehicle(string make, int year, int mileage)
    {
        Make = make;
        Year = year;
        Mileage = mileage;
    }

    public override string ToString()
    {
        return $"Make: {Make}, Year: {Year}, Mileage: {Mileage}";
    }
}