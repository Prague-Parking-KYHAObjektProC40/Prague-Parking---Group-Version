using System;
using System.Collections.Generic;

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
            Console.WriteLine("Please choose from the menu options"
                 + "\n1: Add New Customer"
                 + "\n2: Remove Customer"
                 + "\n3: View Lot"
                 + "\n4: Find Vehicle"
                 + "\n0: Exit Program");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("----- Add New Customer -----");

                    string regNumber = GetValidRegistrationNumber();

                    Console.WriteLine("Enter 'CAR' to add a car or 'MC' to add a motorcycle: ");
                    string addInput = Console.ReadLine().ToUpper();

                    if (addInput == "CAR")
                    {
                        storage.AddCars(regNumber); // Add car to storage
                        Console.WriteLine($"Car with reg number '{regNumber}' added.");
                    }
                    else if (addInput == "MC")
                    {
                        storage.AddMCs(regNumber); // Add motorcycle to storage
                        Console.WriteLine($"Motorcycle with reg number '{regNumber}' added.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'CAR' or 'MC'.");
                    }
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("----- Remove a Customer -----");

                    Console.WriteLine("Enter registration number to remove vehicle\nType 'EXIT' to return:");
                    string removeInput = Console.ReadLine().ToUpper();

                    if (removeInput == "EXIT")
                        break;

                    if (storage.Exists(removeInput))
                    {
                        string vehicleType = storage.GetVehicleType(removeInput);

                        if (vehicleType == "CAR" && storage.RemoveCars(removeInput))
                        {
                            Console.WriteLine($"Car with registration number '{removeInput}' removed.");
                        }
                        else if (vehicleType == "MC" && storage.RemoveMCs(removeInput))
                        {
                            Console.WriteLine($"Motorcycle with registration number '{removeInput}' removed.");
                        }
                        else
                        {
                            Console.WriteLine("Error occurred while removing the vehicle.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No vehicle found with the given registration number.");
                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("----- Current vehicles parked -----");
                    for (int plotNum = 0; plotNum < pLot.Length; plotNum++)
                    {
                        var vehicle = pLot[plotNum];
                        if (vehicle == null)
                        {
                            Console.WriteLine($"Lot {plotNum + 1}: This parking lot is empty");
                        }
                        else
                        {
                            Console.WriteLine($"Lot {plotNum + 1}: {vehicle.PlateNum}, {vehicle.VehicleType}, Ticket Lot: {vehicle.TicketLot}");
                        }
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Enter the registration number to find the vehicle:");
                    string searchInput = Console.ReadLine().ToUpper();

                    if (storage.Exists(searchInput))
                    {
                        string vehicleType = storage.GetVehicleType(searchInput);
                        Console.WriteLine($"Vehicle found: {vehicleType} with registration number '{searchInput}'.");
                    }
                    else
                    {
                        Console.WriteLine("No vehicle found with the given registration number.");
                    }
                    break;

                case "0":
                    Console.WriteLine("Exiting program...");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Helper function to get a valid registration number
    static string GetValidRegistrationNumber()
    {
        while (true)
        {
            Console.WriteLine("Please enter the registration number (1-10 characters): ");
            string regNumber = Console.ReadLine().ToUpper();

            if (regNumber.Length >= 1 && regNumber.Length <= 10 && !regNumber.Contains(" "))
            {
                return regNumber;
            }
            else
            {
                Console.WriteLine("Invalid registration number. It must be between 1 to 10 characters with no spaces.");
            }
        }
    }
}

// Define Storage Class
class Storage
{
    private double totalSpace = 100;
    public double AvailableSpace { get; private set; }
    public Item Car { get; private set; }
    public Item MC { get; private set; }

    private Dictionary<string, string> vehicles = new Dictionary<string, string>(); // regNumber -> vehicleType

    public Storage()
    {
        AvailableSpace = totalSpace;
        Car = new Item("Car", 1, 100);
        MC = new Item("MC", 0.5, 200);
    }

    public void AddCars(string regNumber)
    {
        if (!vehicles.ContainsKey(regNumber) && AvailableSpace >= Car.SpacePerItem)
        {
            vehicles[regNumber] = "CAR";
            AvailableSpace -= Car.SpacePerItem;
            Console.WriteLine($"Car with reg number '{regNumber}' added.");
        }
        else
        {
            Console.WriteLine("Not enough space or vehicle already exists.");
        }
    }

    public void AddMCs(string regNumber)
    {
        if (!vehicles.ContainsKey(regNumber) && AvailableSpace >= MC.SpacePerItem)
        {
            vehicles[regNumber] = "MC";
            AvailableSpace -= MC.SpacePerItem;
            Console.WriteLine($"Motorcycle with reg number '{regNumber}' added.");
        }
        else
        {
            Console.WriteLine("Not enough space or vehicle already exists.");
        }
    }

    public bool RemoveCars(string regNumber)
    {
        if (vehicles.ContainsKey(regNumber) && vehicles[regNumber] == "CAR")
        {
            AvailableSpace += Car.SpacePerItem;
            vehicles.Remove(regNumber);
            return true;
        }
        return false;
    }

    public bool RemoveMCs(string regNumber)
    {
        if (vehicles.ContainsKey(regNumber) && vehicles[regNumber] == "MC")
        {
            AvailableSpace += MC.SpacePerItem;
            vehicles.Remove(regNumber);
            return true;
        }
        return false;
    }

    public bool Exists(string regNumber)
    {
        return vehicles.ContainsKey(regNumber);
    }

    public string GetVehicleType(string regNumber)
    {
        return vehicles.ContainsKey(regNumber) ? vehicles[regNumber] : null;
    }

    public string GetStatus()
    {
        return $"Available Space: {AvailableSpace}";
    }
}

class Item
{
    public string Name { get; }
    public double SpacePerItem { get; }
    public int MaxCount { get; }

    public Item(string name, double spacePerItem, int maxCount)
    {
        Name = name;
        SpacePerItem = spacePerItem;
        MaxCount = maxCount;
    }
}

class CustomersVehicle
{
    public string PlateNum { get; set; }
    public string VehicleType { get; set; }
    public int TicketLot { get; set; }

    public CustomersVehicle(string plateNum, string vehicleType, int ticketLot)
    {
        PlateNum = plateNum;
        VehicleType = vehicleType;
        TicketLot = ticketLot;
    }
}
