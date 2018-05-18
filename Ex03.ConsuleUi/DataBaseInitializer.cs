using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.ConsuleUi;
using Ex03.GarageLogic;

namespace Ex03.ConsuleUi
{
    class DataBaseInitializer
    {

        private DataBase m_DataBase;

        public DataBase InitializeVehicle()
        {
            this.m_DataBase = new DataBase();
            InitializeMotorVehicle();
            InitializeClient();
            return this.m_DataBase;
        }

        private void InitializeClient()
        {

            string Name = UserCommunicator.getStringFromUser("Full Name");
            string PhoneNumber = UserCommunicator.getStringFromUser($"{Name}'s phone number");

            m_DataBase.m_Name = Name;
            m_DataBase.m_PhoneNumber = PhoneNumber;
        }


        private void InitializeMotorVehicle()
        {
            Console.WriteLine("\nMotor Vehicle Questions");
 
            string Manufacture = UserCommunicator.getStringFromUser("Your vehicle's Manufacturer");
            float EnergyPercentage = UserCommunicator.getFloatFromUser("Your energy percentage");

            m_DataBase.m_Manufacture = Manufacture;
            m_DataBase.m_EnergyPercentage = EnergyPercentage;
         
            InitializeVehicleByType();
            List<Wheel> Wheels = UserCommunicator.getWheelsFromUser(m_DataBase.m_VehicleType);
            m_DataBase.m_Wheels = Wheels;

            InitializEngine(); 
        }

        private void InitializeVehicleByType()
        {
            eVehicleType vehicleType = UserCommunicator.GetVehicleTypeFromUser();
            m_DataBase.m_VehicleType = vehicleType;

            switch (vehicleType)
            {
                case eVehicleType.Car:
                    InitializeCar();
                    break;
                case eVehicleType.Truck:
                    InitializeTruck();
                    break;
                case eVehicleType.MotorCycle:
                    InitializeMotorCycle();
                    break;
            }
        }


        private void InitializeCar()
        {
            Car.eColor Color = UserCommunicator.ToCarColor(UserCommunicator.getStringThatEqualsOneOf("What color is your car", new string[] { "Grey", "Blue", "White", "Black" }, false));
            Car.eNumOfDoors NumOfDoors = UserCommunicator.ToNumOfDoors(UserCommunicator.getIntInRange("How many doors your car have?", 2, 5));

            m_DataBase.m_Color = Color;
            m_DataBase.m_NumOfDoors = NumOfDoors;
        }

        private void InitializeMotorCycle()
        {
            int EngineVolume = UserCommunicator.getIntFromUser("Your motor cycle's engine volume");
            MotorCycle.eLicense LicenseType = UserCommunicator.ToLicense(UserCommunicator.getStringFromUser("Your motrorcycle's license type [A/A1/B/B2]"));

            m_DataBase.m_EnergyPercentage = EngineVolume;
            m_DataBase.m_LicenseType = LicenseType;
        }

        private void InitializFuelEngine()
        {
            FuelEngine.eFuelType FuelType;
            float AmountOfFuel = UserCommunicator.getFloatFromUser("How much fuel do you have left");
            float MaxFuelAmount;

            switch (m_DataBase.m_VehicleType)
            {
                case eVehicleType.Car:
                    MaxFuelAmount = 45.0f;
                    FuelType = FuelEngine.eFuelType.Octan98;
                    break;

                case eVehicleType.Truck:
                    MaxFuelAmount = 115.0f;
                    FuelType = FuelEngine.eFuelType.Octan96;
                    break;

                default:     // eVehicleType.MotorCycle
                    MaxFuelAmount = 6.0f;
                    FuelType = FuelEngine.eFuelType.Octan96;
                    break;
            }

            m_DataBase.m_FuelType = FuelType;
            m_DataBase.m_AmountOfFuel = AmountOfFuel;
            m_DataBase.m_MaxFuelAmount = MaxFuelAmount;
        }

        private void InitializElectricEngine()
        {
            float BatteryTimeLeft = UserCommunicator.getFloatFromUser("Your electric engine's battery's remaining time");
            float MaxBatteryLife;

            switch (m_DataBase.m_VehicleType)
            {
                case eVehicleType.Car:
                    MaxBatteryLife = 3.2f;
                    break;

                default:     // eVehicleType.MotorCycle
                    MaxBatteryLife = 1.8f;
                    break;
            }

            m_DataBase.m_BatteryTimeLeft = BatteryTimeLeft;
            m_DataBase.m_MaxBatteryLife = MaxBatteryLife;
        }

        private void InitializEngine()
        {
            bool isElectricEngine = false;
            if (m_DataBase.m_VehicleType != eVehicleType.Truck)
            {
                isElectricEngine = UserCommunicator.getBoolFromUser("Is your vehicle's engine electric");
                m_DataBase.m_IsElectric = isElectricEngine;
            }

            if (isElectricEngine)
            {
                InitializElectricEngine();
            }
            else
            {
                InitializFuelEngine();
            }
        }

        private void InitializeTruck()
        {
            bool RiskyMaterials = UserCommunicator.getBoolFromUser("Does your truck carry risky materials");
            float MaxCarry = UserCommunicator.getFloatFromUser("Your truck's max weight carry");

            m_DataBase.m_RiskyMaterials = RiskyMaterials;
            m_DataBase.m_MaxCarry = MaxCarry;
        }
    } 
}
