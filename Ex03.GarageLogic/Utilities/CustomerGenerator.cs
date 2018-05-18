using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic
{
    static class CustomerGenerator
    {

        public static GarageCustomer Start(DataBase i_UserInput)
        {
            
            return new GarageCustomer(
                i_UserInput.m_Name,
                i_UserInput.m_PhoneNumber,
                VehicleCustomer(i_UserInput)
                );
        }

        private static MotorVehicle VehicleCustomer(DataBase i_UserInput)
        { 
            MotorVehicle vehicle;
            eVehicleType type = i_UserInput.m_VehicleType;
            IEngine engine = InitializeEngine(i_UserInput);

            switch (type)
            {
                case eVehicleType.Car:
                    vehicle = new Car(i_UserInput.m_Wheels, i_UserInput.m_PlateNumber, i_UserInput.m_Manufacture, i_UserInput.m_EnergyPercentage, engine, i_UserInput.m_Color, i_UserInput.m_NumOfDoors);
                    break;
                case eVehicleType.MotorCycle:
                    vehicle = new MotorCycle(i_UserInput.m_Wheels, i_UserInput.m_PlateNumber, i_UserInput.m_Manufacture, i_UserInput.m_EnergyPercentage, engine, i_UserInput.m_EngineVolume, i_UserInput.m_LicenseType);
                    break;
                default: //case eVehicleType.Truck:
                    vehicle = new Truck(i_UserInput.m_Wheels, i_UserInput.m_PlateNumber, i_UserInput.m_Manufacture, i_UserInput.m_EnergyPercentage, engine, i_UserInput.m_RiskyMaterials, i_UserInput.m_MaxCarry);
                    break;
            }

            return vehicle;
        }

        private static IEngine InitializeEngine(DataBase i_UserInput)
        {
            IEngine engine;
            if (i_UserInput.m_IsElectric)
            {
                engine = new ElectricEngine(i_UserInput.m_BatteryTimeLeft, i_UserInput.m_MaxBatteryLife);
            }
            else
            {
                engine= new FuelEngine(i_UserInput.m_FuelType, i_UserInput.m_AmountOfFuel, i_UserInput.m_MaxFuelAmount);
            }

            return engine;
        } 
    }
}
