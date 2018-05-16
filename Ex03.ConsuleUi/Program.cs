using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsuleUi
{
    class Program
    {
        private Dictionary<string, string> i_Form;

        public static void Main(string[] args)
        {
            
        }


        public static void InitializeVehicle()
        {
            InitializeMotorVehicle();
        }

        private static void InitializeMotorCycle()
        {
            int m_EngingVolume = getIntFromUser("Your vehicle's engine volume");
            MotorCycle.eLicense m_LicenseType = ToLicense(getStringFromUser("Your motrorcycle's license type [A/A1/B/B2]"));
        }

        private static void InitializFuelEngine()
        {
            FuelEngine.eFuelType FuelType = toFuelType(getStringThatEqualsOneOf(
                "Your vehicle's fuel type", new string[] {"Soler", "Octan95", "Octan96", "Octan98"}, false));
            float AmountOfFuel = getFloatFromUser("Amount of fuel left in vehicle:");
            float MaxFuelAmount = getFloatFromUser("Tunk capaciy (max amount of fuel in the vehicle)");
        }

        private static string getStringThatEqualsOneOf(string i_Msg, string[] arr, bool i_CaseSensitive)
        {
            string userInput;
            bool ValidAnswer = false;
            StringBuilder sufix = new StringBuilder("[");
            foreach (string s in arr)
            {
                sufix.Append(s);
                sufix.Append(", ");
            }

            sufix.Remove(sufix.Length - 1, 2);
            sufix.Append(" ]");
            
            do
            {
                userInput = getStringFromUser(i_Msg + sufix);
                    //Case insensitive

                if (!i_CaseSensitive)
                {
                    userInput.ToLower();
                }

                foreach (string s in arr)
                {
                    if (!i_CaseSensitive)
                    {
                        s.ToLower();
                    }
                    
                    if (s.Equals(userInput))
                    {
                        ValidAnswer = true;
                        break;
                    }
                }
            } while (!ValidAnswer);

            return userInput;
        }

        private static FuelEngine.eFuelType toFuelType(string i_FuelType)
        {
            FuelEngine.eFuelType fuelType;

            if (i_FuelType.Equals("soler"))
            {
                fuelType = FuelEngine.eFuelType.Soler;
            }
            else if (i_FuelType.Equals("octan95"))
            {
                fuelType = FuelEngine.eFuelType.Octan95;
            }
            else if (i_FuelType.Equals("octan96"))
            {
                fuelType = FuelEngine.eFuelType.Octan96;
            }
            else                    //Octan98
            {
                fuelType = FuelEngine.eFuelType.Octan98;
            }
        }

        private static void InitializElectricEngine()
        {

        }

        private static void InitializEngine()
        {
            bool isElectricEngine = getBoolFromUser("Is your vehicle's engine electric");
            if (isElectricEngine)
            {
                InitializElectricEngine();
            }
            else
            {
                InitializFuelEngine();
            }
        }


        private static void InitializeTruck()
        {
            bool RiskyMaterials = getBoolFromUser("Does your truck carry risky materials");
            float MaxCarry = getFloatFromUser("Your truck's max weight carry");
        }

        private static MotorCycle.eLicense ToLicense(string i_License)
        {
            MotorCycle.eLicense license;

            if (i_License.Equals("a"))
            {
                license = MotorCycle.eLicense.A;
            }
            else if (i_License.Equals("a1"))
            {
                license = MotorCycle.eLicense.A1;
            }
            else if (i_License.Equals("b1"))
            {
                license = MotorCycle.eLicense.B1;
            }
            else                    //b2
            {
                license = MotorCycle.eLicense.B2;
            }

            return license;
        }

        private static void InitializeCar()
        {
            Car.eColor Color = ToCarColor(getStringThatEqualsOneOf("What color is your car", new string[] {"Grey","Blue","White","Black"}, false));
            Car.eNumOfDoors NumOfDoors = ToNumOfDoors(getIntInRange("How many doors your car have?", 2, 5));
        }

        private static int getIntInRange(string i_Msg, int i_Min, int i_Max)
        {
            int fromUser;
            do
            {
                fromUser = getIntFromUser(i_Msg + " [i_Max, i_Min]: ");
            } while (fromUser > i_Max || fromUser < i_Min);

            return fromUser;
        }



        private static Car.eNumOfDoors ToNumOfDoors(int i_NumberOfDoors)
        {
            Car.eNumOfDoors numOfDoors;

            if (i_NumberOfDoors == 2)
            {
                numOfDoors = Car.eNumOfDoors.Two;
            }
            else if (i_NumberOfDoors == 3)
            {
                numOfDoors = Car.eNumOfDoors.Three;
            }
            else if (i_NumberOfDoors == 4)
            {
                numOfDoors = Car.eNumOfDoors.Four;
            }
            else                    //5
            {
                numOfDoors = Car.eNumOfDoors.Five;
            }

            return numOfDoors;

        }

        private static void InitializeMotorVehicle()
        {
            Console.WriteLine("\nMotor Vehicle Questions");
            string PlateNumber = getStringFromUser("Your vehicle's plate number");
            string Manufacture = getStringFromUser("Your vehicle's Manufacturer");

            float EnergyPercentage = getFloatFromUser("Your energy percentage");
            List<Wheel> Wheels = getWheelsFromUser();
        }

        private static Car.eColor ToCarColor(string i_Color)
        {

            Car.eColor O_Color;
            if (i_Color.Equals("grey"))
            {
                O_Color = Car.eColor.Grey;
            }
            else if (i_Color.Equals("blue"))
            {
                O_Color = Car.eColor.Blue;
            }
            else if (i_Color.Equals("white"))
            {
                O_Color = Car.eColor.White;
            }
            else                    //Black
            {
                O_Color = Car.eColor.Black;
            }

            return O_Color;
        }

        private static List<Wheel> getWheelsFromUser()
        {
            Console.WriteLine("\nWheels Questions");
            int numOfWheels = getIntFromUser("How many wheels does your car have");

            List<Wheel> wheels = new List<Wheel>();
            Wheel wheel = getWheelFromUser();
            bool allWheelsTheSame = getBoolFromUser("Are all wheels the same");
            for (int i = 1; i < numOfWheels; i++)
            {
                
                if (!allWheelsTheSame)
                {
                    wheel = getWheelFromUser();
                }

                wheels.Add(wheel);
            }

            return wheels;
        }

        private static bool getBoolFromUser(string i_Msg)
        {
            string answer;
            do
            {
                Console.Write(i_Msg + "? [Y/N]: ");
                answer = Console.ReadLine();
            } while (!answer.Equals("Y") && !answer.Equals("N"));

            
            return answer == "Y";
        }

        private static Wheel getWheelFromUser()
        {
            Console.WriteLine("\nWheel Questions");
            string Manufacture = getStringFromUser("What is your wheel manufacturer");
            float CurrentAirPressure = getFloatFromUser("Your current air presure");
            float MaxAirPressure = getFloatFromUser("Max Air Pressure");

            return new Wheel(Manufacture, CurrentAirPressure, MaxAirPressure);
        }



        private static int getIntFromUser(string i_Msg)
        {
            string answer;
            int result;
            do
            {
                Console.Write(i_Msg + " (integer): ");
                answer = Console.ReadLine();
            } while (!int.TryParse(answer, out result));

            return result;
        }


        private static string getStringFromUser(string i_Msg)
        {
            Console.Write(i_Msg + ": ");
            return Console.ReadLine();
        }

        private static float getFloatFromUser(string i_Msg)
        {
            string answer;
            float result;
            do
            {
                Console.Write(i_Msg + " (floating number): ");
                answer = Console.ReadLine();
            } while (!float.TryParse(answer, out result));

            return result;
        }

    }
}
