class CustomersVehicle
{
    private string plateNum;
    private string vehicleType;
    private int ticketLot;
    private DateTime enterTime;
    private DateTime leaveTime;
    public CustomersVehicle(string _plateNum, string _vehicleType, int _ticketLot)
    {
        this.PlateNum = _plateNum;
        this.VehicleType = _vehicleType;
        this.TicketLot = _ticketLot;
        this.EnterTime = enterTime;
        this.leaveTime = leaveTime;
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
    public DateTime EnterTime
    {
        get { return enterTime; }
        set { enterTime = value; }
    }
    public DateTime LeastTime
    {
        get { return leaveTime; }
        set { leaveTime = value; }
    }
}
class Garage
{
    CustomersVehicle[] pLot = new CustomersVehicle[100];
    public string[] limitPlateNum = new string[10];
    int overTimePrice = 5;
    public void Run()
    {
        int menyVal;
        Console.Clear();
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<¤>>>>>>>>>>>>>>>>>>>>" //20st. var sin sida. bara för att komma ihåg
            + "\n<<     Welcome to our luxury garage    >>"
            + "\n<<     Current vehicle:" + pLot.Length + "               >>"
            + "\n<<<<<<<<<<<<<<<<<<<<¤>>>>>>>>>>>>>>>>>>>>");
        Console.WriteLine();
        do
        {
            Console.WriteLine("Please choose from the menu options"
                + "\n1: Add New Customer"
                + "\n2: Remove Customer"
                + "\n3: View Lot"
                + "\n4: Find Vehicle"
                + "\n0: Exit Program");
            menyVal = int.Parse(Console.ReadLine());
            switch (menyVal)
            {
                case 1:
                    AddVehicle();
                    break;
                case 2:
                    RemoveVehicle();
                    break;
                case 3:
                    ViewLot();
                    break;
                case 4:
                    FindVehicle();
                    break;
                case 0:
                    menyVal = 0;
                    break;
                default:
                    Console.WriteLine("Oopsi Daisy. Something went wrong. Please try again!");
                    break;
            }
        }
        while (menyVal != 0);
    }
    private void AddVehicle()
    {
        string newPlateNum = "";
        string newVehicleType = "";
        DateTime newDate = DateTime.Now;
        int newTicketLot = 0;
        ConsoleKeyInfo userInput;

        Console.Clear();
        Console.WriteLine("----- Add New Customer -----");
        while (true)
        {
            Console.WriteLine("Please write the plate number of the vehicle.");
            try
            {
                newPlateNum = Console.ReadLine();
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        while (true)
        {
            Console.WriteLine("Choose a type of the vehicle from below."
                +"\nCar = Z"
                +"\nMotorcycle = X");
            try
            {
                userInput = Console.ReadKey(true);
                newVehicleType = userInput.Key.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (newVehicleType == "Z" || newVehicleType == "X")
            {
                
                break;
            }
            else
            {
                Console.WriteLine("That is out of range, please try again");
            }
        }
        while (true)
        {
            try
            {
                Console.Write("Please write the ticket number, from 1 to 100: ");
                newTicketLot = Convert.ToInt32(Console.ReadLine());
                if (newTicketLot > 100 || newTicketLot < 0)
                {
                    Console.WriteLine("Please choose the from 1 to 100");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please write a number.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        for (int i = 0;i < pLot.Length - 1 ; i++)
        {
            if (pLot[i] == null)
            {
                pLot[i] = new CustomersVehicle(newPlateNum, newVehicleType, newTicketLot);
                break;
            }
            else
            {
                continue;
            }
        }
        Console.WriteLine();
        Console.WriteLine("The vehicle is now in the system"
            +"\nPress any key to continue...");
    }
    private void RemoveVehicle()
    {
        int pLotNum = 0;
        int index = -1;

        Console.Clear();
        Console.WriteLine("----- Remove Customer -----");
        foreach (CustomersVehicle vehicle in pLot)
        {
            pLotNum++;
            if(vehicle == null)
            {
                Console.WriteLine("Lotnumber {0}: is empty", pLotNum);
            }
            else 
            {
                Console.WriteLine("Lotnumber {0}: {1}", pLotNum, vehicle.PlateNum);
            }
        }
        Console.WriteLine("Choose a lotnumber for the \n" +
            "vehicle to be removed.");
        // User input
        while (true)
        {
            try
            {
                index = Convert.ToInt32(Console.ReadLine()) - 1;
                if (index < 0 || index >= pLot.Length)
                {
                    Console.WriteLine("Please choose a lot between 1 and {0}.", pLot.Length);
                }
                else if (pLot[index] == null)
                {
                    Console.WriteLine("That lot is already empty, please choose another lot.");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please write a number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Output
        Console.WriteLine("\n{0} has now left the garage and \n" +
            "the parking lot {1} is now free to use.", pLot[index].PlateNum, index + 1);
        pLot[index] = null;
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }
    private void ViewLot()
    {
        Console.Clear();
        Console.WriteLine("----- Current vehicle parked -----");
        int plotNum = 0;
        foreach (CustomersVehicle vehicle in pLot)
        {
            plotNum++;
            if(vehicle == null)
            {
                Console.WriteLine("Lot {0}: This parking lot is empty", plotNum);
            }
            else
            {
                Console.WriteLine("Lot {0}: {1}, {2}, {3}.",plotNum, vehicle.PlateNum, vehicle.VehicleType, vehicle.TicketLot);
            }
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
    }
    private void FindVehicle()
    {
        Console.Clear();
        Console.WriteLine("----- Find vehicle -----");
        int findVehicle = 0;
        while (true)
        {
            Console.WriteLine("Please write the ticket number: ");
            try
            {
                findVehicle = Convert.ToInt32(Console.ReadLine());
                if (findVehicle > pLot.Length)
                {
                    Console.WriteLine("Please write the ticket number, from 1 to 100.");
                }
                else if (findVehicle < 0)
                {
                    Console.WriteLine("Please write the ticket number, from 1 to 100:");
                }
                else
                {
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please write a number");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        int ticketFound = 0;
        foreach(CustomersVehicle vehicle in pLot)
        {
            if (vehicle == null)
            {
                continue;
            }
            else if (vehicle.TicketLot == ticketFound)
            {
                Console.WriteLine(vehicle.PlateNum);
                ticketFound++;
            }
            else
            {
                continue;
            }
        }
        if (ticketFound == 0)
        {
            Console.WriteLine("\nNo vehicle match your search.");
        }
        else
        {
            Console.WriteLine("\nYou got {0} matches on your search.", ticketFound);
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}
class Vehicles
{
    public static void Main(string[] args)
    {
        var parkgarage = new Garage();
        parkgarage.Run();
        Console.Write("Press any key to continue...");
        Console.ReadKey(true);
    }
}