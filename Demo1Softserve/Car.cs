using System;
using System.Collections.Generic;
using System.Text;

namespace Demo1Softserve
{
    public class Car
    {
        public Car(string numberPlate)
        {
            this.NumberPlate = numberPlate;
            this.IsParked = false;
        }

        public string NumberPlate { get; set; }
        public bool IsParked { get; set; }
    }
}
