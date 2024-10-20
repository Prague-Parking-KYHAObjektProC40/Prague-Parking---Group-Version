


using System;

class Program
{
    static void Main()
    {
        CustomersVehicle[] pLot = new CustomersVehicle[100];
        Storage storage = new Storage();

        bool running = true;



        while (running)

        {

            Console.WriteLine("<<<<<<<<<<<<<<<<<<+>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("<<  Welcome to our luxury garage   >>");
            Console.WriteLine("<<                                 >>");
            Console.WriteLine($"<< Current spaces: {storage.GetStatus()}  >>");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<+>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("<<<<<<<<<<<<<<<<<<+>>>>>>>>>>>>>>>>>>");
            Console.WriteLine("Please choose from the menu options"
                 + "\n1: Add New Customer"
                 + "\n2: Remove Customer"
                 + "\n3: View Lot"
                 + "\n4: Find Vehicle"
                 + "\n0: Exit Program");

            string? choice = Console.ReadLine();

            // Switch-case to handle different user inputs
            switch (choice)

            {
                case "1":

                    Console.Clear();
                    Console.WriteLine("----- Add New Customer -----");


                    // Method to get a valid registration number from the user

                    string regNumber = "";

                    Console.Write("Enter a registration number (1-10 characters, no spaces Type 'EXIT' to return:):");
                    regNumber = Console.ReadLine();

                    if (regNumber == "EXIT")
                    {
                        return;
                    }

                    Console.WriteLine("Enter 'CAR' to add a car or 'MC' to add a motorcycle ");

                    string addInput = Console.ReadLine().ToUpper();


                    // Check if it's between 1 and 10 characters and does not contain spaces
                    if (regNumber.Length >= 1 && regNumber.Length <= 10 && !regNumber.Contains(" "))
                    {

                        if (addInput == "CAR")
                        {

                            storage.AddCars(1);
                            
                            Console.WriteLine($"Car with reg number '{regNumber}'");
                        }

                        else if (addInput == "MC")
                        {

                            storage.AddMCs(1);
                            Console.WriteLine($"MC with reg number '{regNumber}' added");
                        }

                        //TEST for testing
                        else if (addInput == "TEST")
                        {
                            storage.AddCars(99);
                        }

                        /*else
                        {
                            Console.WriteLine("Invalid registration number. It must be 1 to 10 characters long and contain no spaces.");
                        } */




                    }

                    break;

                case "2":

                    Console.WriteLine("----- Remove a Customer -----");




                    //Console.WriteLine("\nPlease write the plate number of the vehicle to remove.");
                    //plateNumToRemove = Console.ReadLine();

                    //Remove new or use //newPlateNum = Console.ReadLine(); ??

                    Console.WriteLine("Enter 'CAR' to remove a car or 'MC' to remove a motorcycle"
                                        + "\nType 'EXIT' to return:");
                    string removeInput = Console.ReadLine().ToUpper();

                    if (removeInput == "CAR")
                    {
                        storage.RemoveCars(1);
                    }

                    else if (removeInput == "MC")
                    {
                        storage.RemoveMCs(1);
                    }

                    //TEST for testing
                    else if (removeInput == "TEST")
                    {
                        storage.RemoveCars(99);
                    }
                    else if (removeInput == "EXIT")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'CAR', 'MC', or 'EXIT'.");
                    }



                    break;

                case "3":
                    {
                        Console.Clear();
                        Console.WriteLine("----- Current vehicles parked -----");
                        int plotNum = 0;
                        foreach (CustomersVehicle vehicle in pLot)
                        {
                            plotNum++;
                            if (vehicle == null)
                            {
                                Console.WriteLine("Lot {0}: This parking lot is empty", plotNum);
                            }
                            else
                            {
                                Console.WriteLine("Lot {0}: {1}, {2}, {3}.", plotNum, vehicle.PlateNum, vehicle.VehicleType, vehicle.TicketLot);
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    break;

                case "4":

                    // Gör något för m3 

                    Console.WriteLine("Du valde m3\n\n");

                    break;

                case "0":

                    // Avsluta programmet 

                    Console.WriteLine("Avslutar...\n\n");

                    running = false;

                    break;

                default:

                    Console.WriteLine("Ogiltigt val, försök igen.\n\n");

                    break;

            }

        }

    }
}

// Define Classes:
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
            Console.WriteLine($"{count} cars added.");

            /* We Can have this line of code if we want to get added + Remaining space avalible
              
             Console.WriteLine($"{count} cars added. Remaining space: {AvailableSpace}");
            */
        }
        else
        {
            Console.WriteLine("Not enough space to park car.");
        }
    }

    // Method to remove cars
    public void RemoveCars(int count)
    {
        double requiredSpace = count * Car.SpacePerItem;
        if (carCount - count >= 0)
        {
            carCount -= count;
            AvailableSpace += requiredSpace;
            Console.WriteLine($"{count} cars removed.");
            /* Uncomment the next line if you want to display the remaining space available */
            // Console.WriteLine($"{count} cars removed. Remaining space: {AvailableSpace}");
        }
        else
        {
            Console.WriteLine("Not enough cars to remove.");
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
            Console.WriteLine($"{count} MCs added.");

            /* We Can have this line of code if we want to get added + Remaining space avalible
             
             Console.WriteLine($"{count} MCs added. Remaining space: {AvailableSpace}"); 

             */
        }
        else
        {
            Console.WriteLine("Not enough space to park MC.");
        }
    }

    // Method to Removet MCs
    public void RemoveMCs(int count)
    {
        double requiredSpace = count * MC.SpacePerItem;
        if (mcCount - count >= 0)
        {

            mcCount -= count;
            AvailableSpace += requiredSpace;

            Console.WriteLine($"{count} MC Removed.");

        }
        else
        {
            Console.WriteLine("No MC to Remove.");
        }
    }
    // Method to get the current item counts
    public void PrintStatus()
    {
        Console.WriteLine($"Cars: {carCount}, MCs: {mcCount}, Available Space: {AvailableSpace}");
    }

    public string GetStatus()
    {
        return $"Available: {AvailableSpace}";
    }

}

public class CustomersVehicle
{
    private string plateNum;
    private string vehicleType;
    private int ticketLot;

    public CustomersVehicle(string plateNum, string vehicleType, int ticketLot)
    {
        this.plateNum = plateNum;
        this.vehicleType = vehicleType;
        this.ticketLot = ticketLot;
    }

    public string PlateNum
    {
        get { return plateNum; }
        set { plateNum = value; }
    }

    public string VehicleType
    {
        get { return vehicleType; }
        set { vehicleType = value; }
    }

    public int TicketLot
    {
        get { return ticketLot; }
        set { ticketLot = value; }
    }
}
