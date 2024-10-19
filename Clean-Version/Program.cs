class CustomersVehicle
{
    private string plateNum;
    private string vehicleType;
    private int ticketLot;
    //private DateTime enterTime;
    //private DateTime leaveTime;
    public CustomersVehicle(string _plateNum, string _vehicleType, int _ticketLot)
    {
        this.PlateNum = _plateNum;
        this.VehicleType = _vehicleType;
        this.TicketLot = _ticketLot;
        //this.EnterTime = enterTime;
        //this.leaveTime = leaveTime;
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
    /*public DateTime EnterTime
    {
        get { return enterTime; }
        set { enterTime = value; }
    }
    public DateTime LeastTime
    {
        get { return leaveTime; }
        set { leaveTime = value; }
    }*/
}
class Garage
{
    CustomersVehicle[] pLot = new CustomersVehicle[100];
    public void Run()
    {
        
        while (true)
        {
            Console.WriteLine("<<<<<<<<<<<<<<<<<<<<¤>>>>>>>>>>>>>>>>>>>>" //20st. var sin sida. bara för att komma ihåg
                + "\n<<     Welcome to our luxury garage    >>"
                // + "\n<<     Current spaces:" + pLot.Length + "              >>" Här är önskad funktion 1 där man kan förbärttra
                + "\n<<<<<<<<<<<<<<<<<<<<¤>>>>>>>>>>>>>>>>>>>>");
            Console.WriteLine();
            Console.WriteLine("Please choose from the menu options"
                + "\n1: Add New Customer"
                + "\n2: Remove Customer"
                + "\n3: View Lot"
                + "\n4: Find Vehicle"
                + "\n0: Exit Program");

            string menyVal = Console.ReadLine();
            switch (menyVal)
            {
                case "1":
                    {
                        string newPlateNum = "";
                        string newVehicleType = "";
                        int newTicketLot = 0;
                        ConsoleKeyInfo userInput;

                        Console.Clear();
                        Console.WriteLine("----- Add New Customer -----");
      
                        Console.WriteLine("\nPlease write the plate number of the vehicle.");
                        newPlateNum = Console.ReadLine();

                        // Check if the input is empty/null
                        if (string.IsNullOrEmpty(newPlateNum))
                        {
                            Console.WriteLine("You enterd No plate number entered. Returnd to Menu");
                            continue; // Exit the method
                        }


                        Console.WriteLine("Choose a type of the vehicle from below.\nCAR or MC");
                        newVehicleType = Console.ReadLine().ToUpper();

                        if (newVehicleType == "CAR" || newVehicleType == "MC")
                        {

                            // Generate a new ticket number for each customer
                            int currentTicketNumber = 0;  // Start with 0 so the first ticket is 1
                            const int maxTicketNumber = 999;  // Max value for ticket number

                          currentTicketNumber++;

                           
                            // try

                            

                            //Console.Write("Please write the ticket number, from 1 to 100: FG ");
                            //newTicketLot = Convert.ToInt32(Console.ReadLine());
                            //if (newTicketLot > 100 || newTicketLot < 0)

                            if (currentTicketNumber > maxTicketNumber)
                            {
                                // Återställ till 1 om max är uppnått
                                currentTicketNumber = 1;

                            }
                                // Assign the generated ticket number to newTicketLot
                                newTicketLot = currentTicketNumber;

                                    //Console.WriteLine("Please choose the from 1 to 100");
                               

                                // Display the new ticket number for the customer
                                Console.WriteLine($"New ticket for customer: {currentTicketNumber}");

                            //catch (FormatException)
                            //{
                            //Console.WriteLine("Please write a number.");
                            //}
                           // catch (Exception ex)
                            //{
                                //Console.WriteLine(ex.Message);
                            //}
                        }
                        for (int i = 0; i < pLot.Length - 1; i++)
                        {
                            if (pLot[i] == null)
                            {
                                pLot[i] = new CustomersVehicle(newPlateNum, newVehicleType, newTicketLot);
                                break;
                            }

                        else
                            {
                                Console.WriteLine("Try CAR or MC again please to add vehicle");
                            }

                        }
                        Console.WriteLine();
                        Console.WriteLine("\nThe vehicle is now in the system, \n\n Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        }

                        break;

                case "2":
                    {
                        int pLotNum = 0;
                        int index = -1;

                        Console.Clear();
                        Console.WriteLine("----- Remove Customer -----");
                        /*foreach (CustomersVehicle vehicle in pLot)
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
                        *///}
                          //Console.WriteLine("Choose a lotnumber for the vehicle to be removed:"); 
                        Console.WriteLine("Type regestration number for the vehicle to be removed:");
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
                        Console.ReadKey();
                        Console.Clear();
                    }
                        break;
                case "3":
                    {
                        Console.Clear();
                        Console.WriteLine("----- Current vehicle parked -----");
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

                                if  (findVehicle < 1 || findVehicle > 999)  // Kolla om biljetten är mellan 1 och 999
                                    {
                                    Console.WriteLine("Please write the ticket number, from 1 to 999.");
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
                                Console.WriteLine(ex.Message); // Övriga undantag
                            }
                        }
                        int ticketFound = 0;
                        foreach (CustomersVehicle vehicle in pLot)
                        {
                            if (vehicle == null)
                            {
                                continue; // Hoppa över tomma platser
                            }
                            else if (vehicle.TicketLot == ticketFound) // Kontrollera om biljettnumret matchar
                            {
                                Console.WriteLine($"Vehicle found: {vehicle.PlateNum}, Type: {vehicle.VehicleType}, Ticket: {vehicle.TicketLot}");
                                ticketFound++; // Räkna antalet funna fordon
                            }

                        // Kontrollera om några fordon hittades
                        }
                        if (ticketFound == 0)
                        {
                            Console.WriteLine("\nNo vehicle match your search.");
                        }
                        else
                        {
                            Console.WriteLine($"\nYou found {ticketFound} vehicle(s) matching the ticket number.");
                        }

                        // Väntar på att användaren trycker på valfri tangent innan programmet fortsätter
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Oopsi Daisy. Something went wrong. Please try again!");
                    break;
            }
        }
    }

}
class Vehicles
{
    public static void Main(string[] args)
    {
        var parkgarage = new Garage();
        parkgarage.Run();
        Console.Write("class Vehicles text - Press any key to continue...");
        Console.ReadKey(true);
    }
}