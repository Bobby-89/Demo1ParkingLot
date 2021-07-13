using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Demo1Softserve
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot();

            while (true)
            {
                string command = string.Empty;
                string numberPlate = string.Empty;

                while (!(command == "park" || command == "exit" || command == "info"))
                {
                    Console.WriteLine("Please enter 'park' for parking a car, enter 'exit' for removing a car or enter 'info' to get info.");
                    command = Console.ReadLine();
                }

                if (command == "park")
                {
                    while (ValidateNumberPlate(numberPlate) == false)
                    {
                        Console.WriteLine("Please enter the number");
                        numberPlate = Console.ReadLine();
                    }

                    try
                    {
                        parkingLot.Park(new Car(numberPlate));
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "exit")
                {
                    while (ValidateNumberPlate(numberPlate) == false)
                    {                        
                        Console.WriteLine("List with the parked cars:");
                        foreach (KeyValuePair<string, string> kvp in parkingLot.ParkedTime)
                        {
                            Console.WriteLine
                                ($"Number plate: {kvp.Key} - parked at {kvp.Value} o'clock.");
                        }
                        Console.WriteLine("Please enter the number.");
                        numberPlate = Console.ReadLine();
                    }

                    try
                    {
                        parkingLot.Remove(new Car(numberPlate));
                        parkingLot.ParkedTime.Remove(numberPlate);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                else if (command == "info")
                {
                    Console.WriteLine(parkingLot.Info());
                }
            }

        }
        public static bool ValidateNumberPlate(string numberPlate)
        {
            Regex regexForValidatingNumberPlate = new Regex(@"^[A-Za-z]{1,2}[0-9]{4}[A-Za-z]{2}$");

            if (regexForValidatingNumberPlate.IsMatch(numberPlate))
            {
                return true;
            }

            return false;
        }
    }
}

// TODO: print all number plates on exit command for the operator to choose