using System;

class Item
{
    public string Name { get; set; }
    public int Id { get; set; }
    public double SpacePerItem { get; set; }
    public int MaxCount { get; set; }

    public Item(string name, int id, double spacePerItem, int maxCount)
    {
        Name = name;
        Id = id;
        SpacePerItem = spacePerItem;
        MaxCount = maxCount;
    }
}

class Storage
{
    private double totalSpace = 100; // The total available space is 100
    public double AvailableSpace { get; private set; }
    public Item Car { get; private set; }
    public Item MC { get; private set; }

    private int carCount = 0;
    private int mcCount = 0;

    public Storage()
    {
        AvailableSpace = totalSpace;
        Car = new Item("Car", 4, 1, 100);   // Car takes 1 space per car, max 100 cars
        MC = new Item("MC", 2, 0.5, 200);   // MC takes 0.5 space per MC, max 200 MCs
    }

    // Method to add cars
    public void AddCars(int count)
    {
        double requiredSpace = count * Car.SpacePerItem;

        if (carCount + count <= Car.MaxCount && requiredSpace <= AvailableSpace)
        {
            carCount += count;
            AvailableSpace -= requiredSpace;
            Console.WriteLine($"{count} cars added. Remaining space: {AvailableSpace}");
        }
        else
        {
            Console.WriteLine("Not enough space or max car limit reached.");
        }
    }

    // Method to add MCs
    public void AddMCs(int count)
    {
        double requiredSpace = count * MC.SpacePerItem;

        if (mcCount + count <= MC.MaxCount && requiredSpace <= AvailableSpace)
        {
            mcCount += count;
            AvailableSpace -= requiredSpace;
            Console.WriteLine($"{count} MCs added. Remaining space: {AvailableSpace}");
        }
        else
        {
            Console.WriteLine("Not enough space or max MC limit reached.");
        }
    }

    // Method to get the current item counts
    public void PrintStatus()
    {
        Console.WriteLine($"Cars: {carCount}, MCs: {mcCount}, Available Space: {AvailableSpace}");
    }
}

class Program
{
    static void Main()
    {
        Storage storage = new Storage();

        // Test adding items
        storage.AddCars(50);  // Adds 50 cars, uses 50 spaces (50 * 1)
        storage.AddMCs(40);   // Adds 40 MCs, uses 20 spaces (40 * 0.5)

        // Now total space used is 50 (cars) + 20 (MCs) = 70, so 30 spaces left

        storage.AddCars(20);  // This should succeed, using 20 spaces, leaving 10 spaces

        // Print final status
        storage.PrintStatus(); // Print current storage status
    }
}