using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsuleUi
{
    class GarageDashBoard
    {
        private Garage m_Garage;

        public GarageDashBoard(Garage i_Garage)
        {
            m_Garage = i_Garage;
        }

        public void Start()
        {
            printStartPage();
        }

        private void printStartPage()
        {
            Console.WriteLine("Welcome to Garage Main Dashboard");
            Console.WriteLine("=================================");
            Console.WriteLine();

            
            string msg = 
@"Choose an action:

1. Insert a car into repair
2. Display a list of license plates filtered by status
3. Change a vehicles status
4. Inflate a vehicle's tiers to maximum
5. Fuel up a vehicle
6. Charge up an electric vehicle
7. Display a vehicle's full data
8. Exit program

";

            int result = UserCommunicator.getIntInRange(msg + "Pick the number of action you would like to do ", 1, 8);
            parseAction(result);
        }

        private void parseAction(int i_Action)
        {
            Console.Clear();


            switch (i_Action)
            {
                case 1:
                    
                    string PlateNumber = UserCommunicator.getStringFromUser("Your vehicle's plate number");
                    if (!m_Garage.isCustomerEnrolled(PlateNumber))
                    {
                        DataBaseInitializer InitDB = new DataBaseInitializer();
                        DataBase newCarDataBase = InitDB.InitializeVehicle();
                        newCarDataBase.m_PlateNumber = PlateNumber;
                        m_Garage.Add(CustomerGenerator.Start(newCarDataBase));
                        Console.Clear();
                        Console.WriteLine($"{newCarDataBase.m_Name}, your car have been added, and it's status is \"In Repair\"");
                    }
                    else
                    {
                        string name = m_Garage.FindCustomerByPlateNumber(PlateNumber).Name;
                        Console.WriteLine($"Welcome back {name}, your car status changed to \"In Repair\"");
                        m_Garage.ChangeStatus(PlateNumber, MotorVehicle.eVehicleStatus.inRepair);

                    }

                    break;

                case 2:
                    DisplayAllPlateNumbersFiltered();
                    break;
                case 3:
                    changeCarStatus();
                    break;
                case 4:
                    InflateToMax();
                    break;
                case 5:
                    FuelUp();
                    break;
                case 6:
                    chargeUpElectric();
                    break;
                case 7:
                    printVehicleDetails();
                    break;
                case 8:
                    Console.WriteLine("Bye Bye\nPress any key to exit...");
                    Console.ReadLine();
                    return;                  

            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
            Start();
        }

        private void DisplayAllPlateNumbersFiltered()
        {
            List<string> toPrintPayed = m_Garage.filterPlateNumbersByStatus(MotorVehicle.eVehicleStatus.Payed);
            List<string> toPrintRepaired = m_Garage.filterPlateNumbersByStatus(MotorVehicle.eVehicleStatus.Repaired);
            List<string> toPrintInRepair = m_Garage.filterPlateNumbersByStatus(MotorVehicle.eVehicleStatus.inRepair);

            Console.WriteLine("In Repair");
            foreach (string s in toPrintInRepair)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Repaired");
            foreach (string s in toPrintRepaired)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Payed");
            foreach (string s in toPrintPayed)
            {
                Console.WriteLine(s);
            }

            Console.ReadLine();
        }

        private void printVehicleDetails()
        {
            string plateNumber = getPlateNumber();
            bool isEnrolled = m_Garage.isCustomerEnrolled(plateNumber);

            if (isEnrolled)
            {
                Console.WriteLine(m_Garage.FindCustomerByPlateNumber(plateNumber));
            }
            else
            {
                Console.WriteLine("Car not found have a blessed day");
            }
        }

        private void chargeUpElectric()
        {
            string plateNumber = getPlateNumber();
            bool charged = m_Garage.isCustomerEnrolled(plateNumber);

            if (charged)
            {
                float amount = UserCommunicator.getFloatFromUser("How much to charge");
                try
                {
                    charged = m_Garage.ChargeVehicle(plateNumber, amount);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong arguments, vehicles haven't been charged");
                }
            }
            else
            {
                printNotEnrolled();
            }

        }

        private void FuelUp()
        {
            string plateNumber = getPlateNumber();
            bool fueled = m_Garage.isCustomerEnrolled(plateNumber);

            if (fueled)
            {
                float fuel = UserCommunicator.getFloatFromUser("How much fuel to put in");
                FuelEngine.eFuelType type = UserCommunicator.toFuelType(
                    UserCommunicator.getStringThatEqualsOneOf("Fuel Type",
                        new string[] {"Soler", "Octan95", "Octan96", "Octan98"}, false));

                try
                {
                    fueled = m_Garage.FuelVehicle(plateNumber, fuel, type);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong arguments, vehicles haven't been fueled up.");
                }
            }
            else
            {
                printNotEnrolled();
            }
        }

        private void InflateToMax()
        {
            try
            {
                bool inflated = m_Garage.InflateToMax(getPlateNumber());

                if (inflated)
                {
                    Console.WriteLine("Wheels have been inflated");
                }
                else
                {
                    printNotEnrolled();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong arguments, wheels haven't been inflated");
            }
        }

        private void changeCarStatus()
        {
            string plateNumber = getPlateNumber();

            if (!m_Garage.isCustomerEnrolled(plateNumber))
            {
                printNotEnrolled();
            }
            else
            {
                MotorVehicle.eVehicleStatus status = UserCommunicator.ToVehicleStatus(
                    UserCommunicator.getStringThatEqualsOneOf("Pick a status", new string[] { "In Repair", "Payed", "Repaired" }, false));
                m_Garage.ChangeStatus(plateNumber, status);
                Console.WriteLine($"Your car status changed to \"{status}\"");
            }
        }

        private string getPlateNumber()
        {
            return UserCommunicator.getStringFromUser("What is the plate number of the car");
        }

        private void printNotEnrolled()
        {
            Console.WriteLine("Plate number is not enrolled\nGoing to main menu (no operation have been done)");
        }
    }
}
