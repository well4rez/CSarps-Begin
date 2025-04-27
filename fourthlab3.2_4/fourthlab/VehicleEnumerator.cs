using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fourthlab
{
    public class VehicleEnumerator : IEnumerator<Vehicle>
    {
        private List<Vehicle> vehicles;
        private int currentIndex = -1;

        public VehicleEnumerator(List<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
        }

        public Vehicle Current
        {
            get
            {
                if (currentIndex < 0 || currentIndex >= vehicles.Count)
                    throw new InvalidOperationException();//////

                return vehicles[currentIndex];
            }
        }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            while (++currentIndex < vehicles.Count)
            {
                if (vehicles[currentIndex].Mileage < 100000)
                    return true;
            }
            return false;
        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public void Dispose()
        {
            
        }
    }
}
