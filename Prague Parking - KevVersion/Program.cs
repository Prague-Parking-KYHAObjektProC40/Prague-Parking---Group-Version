class Garage
{
    public DateTime parkinglotDT = new DateTime();
    public int[] parkinglot = new int[100];
    public int numberOfparkinglot; 
    public void Run()
    {
        //Här tänkte jag att huvud meny skall vara.
    }
    public void Add_vehicle()
    {
        //Lägga till fordon
    }
    public void Remove_vehicle()
    {
        //tar bort fordon
    }
    public void Print_vehicle()
    {
        //Skriver ut hur många som är parkerad och hur många plats det finns.
    }
    public void Find_vehicle()
    {
        //Söka fordon i systemet genom att använda räckvidd t.ex. parkerings kvitto mellan nr. 2-5
    }
    public void Sort_parking_lot()
    {
        //Sorterar parkerings plats och flyttar dem.
    }
}
class vehicle_type
{
    //Om bil eller MC
}
class Program
{
    public static void Main(string[] args)
    {
        var parkgarage = new Garage();
        var vehicle = new vehicle_type();
        parkgarage.Run();
        Console.Write("Tryck Enter för att fortsätta...");
        Console.ReadKey(true);
    }  //Här körs hela programmet och anropar alla class och metoder
}