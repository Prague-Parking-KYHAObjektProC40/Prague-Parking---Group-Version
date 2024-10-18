/*class CustomersVehicle
{
    public CustomersVehicle(string dataplateNum, string datavehicleType, int dataparkingLot)
    {
        plateNumInfo = dataplateNum;
        vehicleTypeInfo = datavehicleType;
        parkingLotInfo = dataparkingLot;
    }
    private string plateNumInfo;
    public string PlateNum
    {
        get { return plateNumInfo; }
    }
    private string vehicleTypeInfo;
    public string VehicleType
    {
        get { return vehicleTypeInfo; }
    }
    private int parkingLotInfo;
    public int ParkingLot
    {
        get { return parkingLotInfo; }
    }
    DateTime tempDate = DateTime.Now;
}
class program
{
    public static void Main(string[] args)
    {
        List<CustomersVehicle> vehiclesList = new List<CustomersVehicle>(100);
        int menyVal;
        Console.WriteLine("<<<<<<<<<<<<<<<<<<<<¤>>>>>>>>>>>>>>>>>>>>" //20st. var sin sida. bara för att komma ihåg
            + "\n<<     Welcome to our luxury garage    >>"
            + "\n<<     Current vehicle:" + vehiclesList.Count + "               >>"
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
                    Console.Clear();
                    Console.WriteLine("Please write the plate number of the vehicle.");
                    string plateNumInfo = Console.ReadLine();
                    Console.WriteLine("Please write the type of the vehicle.");
                    string vehicleTypeInfo = Console.ReadLine();
                    Console.WriteLine("Please write the parking lot number.");
                    Int32.TryParse(Console.ReadLine(), out int parkingLotInfo);

                    Console.WriteLine("The vehicle is now in the system");
                    CustomersVehicle newVehicle = new CustomersVehicle(plateNumInfo, vehicleTypeInfo, parkingLotInfo);
                    vehiclesList.Add(newVehicle);

                    break;
                case 2:
                    Console.Write("Choose the vehicle you want to remove [0 Cancel]: ");
                    int removeVehicle = Convert.ToInt32(Console.ReadLine());
                    //vehiclesList.Remove(removeVehicle);
                    break;
                case 3:
                    Console.Clear();
                    foreach (CustomersVehicle vehicle in vehiclesList)
                    {
                        Console.WriteLine("License Number: " + vehicle.PlateNum + " - " + "Type: " + vehicle.VehicleType + " - " + "Lot: " + vehicle.ParkingLot);
                    }
                    break;
                case 4:
                    Console.WriteLine("Witch vehicle do you want to find? Please write the license number");
                    string licenseNum = Console.ReadLine();
                    bool currentVehicle = false;
                    for (int i = 0; i < vehiclesList.Count; i++)
                    {
                        if (vehiclesList[i].PlateNum == licenseNum)
                        {
                            Console.WriteLine("The current vehicle is on the list");
                            Console.WriteLine("License Number: " + vehiclesList[i].PlateNum + " - " + "Type: " + vehiclesList[i].VehicleType + " - " + "Lot: " + vehiclesList[i].ParkingLot);
                            currentVehicle = true;
                            break;
                        }
                    }
                    if (!currentVehicle)
                    {
                        Console.WriteLine("There is no vehicle in the garage that match your license number.");
                    }
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
}

