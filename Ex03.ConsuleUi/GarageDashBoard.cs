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

            Console.WriteLine("Pick the number of action you would like to do:");

            string msg = string.Format
            (
                "Pick the number of action you would like to do:" +
                "1. Insert a car into repair" +
                "2. Display a list of license plates filtered by status" +
                "3. Change a vehicles status" +
                "4. Inflate a car's tiers to maximum" +
                "5. Fuel up a car" +
                "6. Charge up an electric car" +
                "7. Display a car's full data" +
                "8. Exit program"
            );

            int result = UserCommunicator.getIntInRange(msg, 1, 8);
        }

        private void parseAction(int i_Action)
        {
            Console.Clear();

            switch (i_Action)
            {
                case 1:
                    DataBaseInitializer InitDB = new DataBaseInitializer();
                    DataBase newCarDataBase = InitDB.InitializeVehicle();
                    
                    break;
            }
        }
    }
}
