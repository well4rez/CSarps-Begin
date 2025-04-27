using System;
using System.Collections;
using System.Collections.Generic;
using fourthlab;
namespace fourthlab
{

    public class VehicleCollection : IEnumerable<Vehicle>
    {
        private List<Vehicle> vehicles;

        public VehicleCollection()
        {
            vehicles = new List<Vehicle>();
        }

        public void Add(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        public IEnumerator<Vehicle> GetEnumerator()
        {
            return new VehicleEnumerator(vehicles);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}