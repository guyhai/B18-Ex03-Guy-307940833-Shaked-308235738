using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsuleUi
{
    public static class UserCommunicator
    { 


        public static string getStringThatEqualsOneOf(string i_Msg, string[] arr, bool i_CaseSensitive)
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

        public static FuelEngine.eFuelType toFuelType(string i_FuelType)
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

            return fuelType;
        }

        public static MotorCycle.eLicense ToLicense(string i_License)
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

        

        public static int getIntInRange(string i_Msg, int i_Min, int i_Max)
        {
            int fromUser;
            do
            {
                fromUser = getIntFromUser(i_Msg + " [i_Max, i_Min]: ");
            } while (fromUser > i_Max || fromUser < i_Min);

            return fromUser;
        }



        public static Car.eNumOfDoors ToNumOfDoors(int i_NumberOfDoors)
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

        public static Car.eColor ToCarColor(string i_Color)
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

        public static List<Wheel> getWheelsFromUser(eVehicleType i_VehicleType)
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

        public static bool getBoolFromUser(string i_Msg)
        {
            string answer;
            do
            {
                Console.Write(i_Msg + "? [Y/N]: ");
                answer = Console.ReadLine();
            } while (!answer.Equals("Y") && !answer.Equals("N"));

            
            return answer == "Y";
        }

        public static Wheel getWheelFromUser()
        {
            Console.WriteLine("\nWheel Questions");
            string Manufacture = getStringFromUser("What is your wheel manufacturer");
            float CurrentAirPressure = getFloatFromUser("Your current air presure");
            float MaxAirPressure = getFloatFromUser("Max Air Pressure");

            return new Wheel(Manufacture, CurrentAirPressure, MaxAirPressure);
        }



        public static int getIntFromUser(string i_Msg)
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


        public static string getStringFromUser(string i_Msg)
        {
            Console.Write(i_Msg + ": ");
            return Console.ReadLine();
        }

        public static float getFloatFromUser(string i_Msg)
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


        public static eVehicleType GetVehicleTypeFromUser()
        {
            return ToVehiclesType(getStringThatEqualsOneOf("Type of vehicle", new string[] {"truck", "car", "motorcycle"}, false)); 
        }

        public static eVehicleType ToVehiclesType(string i_VehicleType)
        {
            eVehicleType vehicleType;

            if (i_VehicleType.Equals("truck"))
            {
                vehicleType = eVehicleType.Truck;
            }
            else if (i_VehicleType.Equals("car"))
            {
                vehicleType = eVehicleType.Car;
            }
            else                    //MotorCycle
            {
                vehicleType = eVehicleType.MotorCycle;
            }

            return vehicleType;
        }

    }
}
