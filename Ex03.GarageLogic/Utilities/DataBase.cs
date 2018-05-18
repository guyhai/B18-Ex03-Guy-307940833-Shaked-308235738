using System.Collections.Generic;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic
{
    public struct DataBase
    {
        //Client
        public string m_Name { get; set; }
        public string m_PhoneNumber { get; set; }

        //Car
        public Car.eColor m_Color { get; set; }
        public Car.eNumOfDoors m_NumOfDoors { get; set; }

        //Motor Cycle
        public int m_EngineVolume { get; set; }
        public MotorCycle.eLicense m_LicenseType { get; set; }

        //Truck
        public bool m_RiskyMaterials { get; set; }
        public float m_MaxCarry { get; set; }


        //Motor Vehicle
        public List<Wheel> m_Wheels { get; set; }
        public string m_PlateNumber { get; set; }
        public string m_Manufacture { get; set; }
        public float m_EnergyPercentage { get; set; }

        //Type
        public eVehicleType m_VehicleType { get; set; }

        //**Engines**
        public bool m_IsElectric { get; set; }


        //Electric Engine
        public float m_BatteryTimeLeft { get; set; }    //hours
        public float m_MaxBatteryLife { get; set; }     //hours

        //Fuel Engine
        public FuelEngine.eFuelType m_FuelType { get; set; }
        public float m_AmountOfFuel { get; set; }
        public float m_MaxFuelAmount { get; set; }
    }
}
