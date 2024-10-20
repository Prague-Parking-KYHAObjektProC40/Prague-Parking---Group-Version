
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
    }
}*/
    class Prague_Castle_Parking
    {
        CustomersVehicle[] pLot = new CustomersVehicle[100];
        public void Run()
        {

            while (true)
            {
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<¤>>>>>>>>>>>>>>>>>>>>" //20st. var sin sida. bara för att komma ihåg
                    + "\n<<     Welcome to Prague Castle Park    >>"
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
                }
            }
        }
    }
}