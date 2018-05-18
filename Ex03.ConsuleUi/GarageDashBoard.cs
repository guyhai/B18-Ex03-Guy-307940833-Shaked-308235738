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
                    

            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Console.Clear();
            Start();
        }

        private void FuelUp()
        {
            

        }

        private void InflateToMax()
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
