using System;

namespace tab_deneme.Classes
{
    internal class Captains
    {
        //Captain Attributes
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public int Licenses { get; set; } //assume that licenses ​​are kept by license number
    }

    internal class Crew
    {
        //Crew Attributes
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public string Position { get; set; }
    }

    internal class Ships
    {
        //Ship Attributes
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int YearOfConstruction { get; set; }
        public string ShipType { get; set; }
        public int PassangerCapacity { get; set; }
        public double PetrolCapacityInLiters { get; set; }
        public int ContainerCapacity { get; set; }
        public double MaximumWeightForContainers { get; set; }
    }

    internal class Ports
    {
        //Port Attributes
        public string Name { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public bool RequiresPassport { get; set; }
        public double DockingFee { get; set; }
    }

    internal class Voyages
    {
        //Voyages Attributes
        public int ID { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string DeparturePort { get; set; }
    }
}
