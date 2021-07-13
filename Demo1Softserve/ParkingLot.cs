using System;
using System.Collections.Generic;

namespace Demo1Softserve
{
    public class ParkingLot
    {
        private const int CAPACITY = 20;

        protected Dictionary<string, Car> parkedCars;
        protected Dictionary<string, DateTime> parkedTime;

        public Dictionary<string, DateTime> ParkedTime { get { return parkedTime; } }

        public ParkingLot()
        {
            this.parkedCars = new Dictionary<string, Car>();
            this.parkedTime = new Dictionary<string, DateTime>();
        }

        public void Park(Car car)
        {
            if (this.parkedCars.Count == CAPACITY)
            {
                throw new InvalidOperationException("There is not any available spots.");
            }
            else if (this.parkedCars.ContainsKey(car.NumberPlate))
            {
                throw new InvalidOperationException($"Car with numberplate: {car.NumberPlate} is already parked.");
            }
            else
            {
                this.parkedCars.Add(car.NumberPlate, car);
                this.parkedTime.Add(car.NumberPlate, DateTime.Now);
            }
        }

        public void Remove(Car car)
        {
            if (this.parkedCars.ContainsKey(car.NumberPlate))
            {
                this.parkedCars.Remove(car.NumberPlate);
            }
            else
            {
                throw new InvalidOperationException($"Car with numberplate: {car.NumberPlate} is not parked here.");
            }
        }

        public string Info()
        {
            int availableSpots = CAPACITY - this.parkedCars.Count;

            if (availableSpots == 1)
            {
                return $"There is 1 available spot.";
            }
            else if (availableSpots == 0)
            {
                return "There is not any available spots.";
            }

            return $"There are {availableSpots} available spots.";
        }
    }
}