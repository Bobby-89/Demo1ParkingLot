using System;
using System.Text.RegularExpressions;

namespace Demo1Softserve
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new ParkingLot();

            Console.WriteLine("Hello, park or remove car from the parking lot by typing '+' for parking car or '-' for removig car following by the car numberplate together without spaces.");
            
            while (true)
            {
                //Regex regexForValidatingNumberPlate = new Regex(@"[a-zA-Z]{1,2}\\+\d{4}[a-zA-Z]{2}");
                Regex regexForValidatingNumberPlate = new Regex(@"^[A-Za-z]{1,2}[0-9]{4}[A-Za-z]{2}$");

                string command = string.Empty;
                string numberPlate = string.Empty;

                while (!(command == "park" || command == "exit" || command == "info"))
                {
                    Console.WriteLine("Please enter 'park' for parking a car or 'exit' for removing a car");
                    command = Console.ReadLine();
                }

                if (command == "park")
                {
                    // TODO: make validating number plate function
                    while (!(regexForValidatingNumberPlate.IsMatch(numberPlate)))
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
                    while (!(regexForValidatingNumberPlate.IsMatch(numberPlate)))
                    {
                        Console.WriteLine("Please enter the number");
                        numberPlate = Console.ReadLine();
                    }

                    try
                    {
                        parkingLot.Remove(new Car(numberPlate));
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
    }
}

// TODO: print all number plates on exit command for the operator to choose