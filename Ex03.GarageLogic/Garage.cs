using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<GarageCustomer> m_Customers;


        public Garage()
        {
            this.m_Customers = new List<GarageCustomer>();
        }

        public void Add(GarageCustomer i_customer)
        {
            m_Customers.Add(i_customer);
        }

        private bool DoesContainCar(MotorVehicle i_Vehicle)
        {
            return FindCustomerByPlateNumber(i_Vehicle.PlateNumber) != null;
        }

        public void ChangeStatus(string i_PlateNumber, MotorVehicle.eVehicleStatus i_Status)
        {
            GarageCustomer customer = FindCustomerByPlateNumber(i_PlateNumber);
            customer.Vehicle.Status = i_Status;
        }
        public bool InflateToMax(string i_PlateNumber)
        {
            bool result = false;
            GarageCustomer customer = FindCustomerByPlateNumber(i_PlateNumber);
            if (customer != null)
            {
                foreach (Wheel wheel in customer.Vehicle.Wheels)
                {
                    wheel.InflateToMax();
                }

                result = true;
            }

            return result;
        }
        public bool FuelVehicle(string i_PlateNumber, float i_Amount, FuelEngine.eFuelType i_Type)
        {
            bool isFueled = false;
            GarageCustomer customer = FindCustomerByPlateNumber(i_PlateNumber);
            if (customer != null)
            {

                IEngine engine = customer.Vehicle.Engine;
                if (engine.EngineType() == typeof(FuelEngine))
                {
                    FuelEngine fuelEngine = (FuelEngine) engine;
                    if (i_Type.Equals(fuelEngine.FuelType))
                    {
                        isFueled = fuelEngine.PutGas(i_Amount);
                    }
                    else
                    {
                        throw new ArgumentException("Wrong type of fuel");
                    }

                }
                else
                {
                    throw new ArgumentException("Trying to put gas in an electric engine");
                }
            }

            return isFueled;


        }
        public bool ChargeVehicle(string i_PlateNumber, float i_Amount)
        {
            bool isCharged = false;

            GarageCustomer customer = FindCustomerByPlateNumber(i_PlateNumber);
            if (customer == null)
            {
                return false;
            }
            IEngine engine = customer.Vehicle.Engine;

            if (engine.EngineType() == typeof(ElectricEngine))
            {
                ElectricEngine electricEngine = (ElectricEngine) engine;

                isCharged = electricEngine.chargeBattery(i_Amount);
            }
            else
            {
                throw new ArgumentException("Trying to put gas in an electric engine");
            }

            return isCharged;
        }

        /** returns null if it doesn't exist
         *
         */
        public GarageCustomer FindCustomerByPlateNumber(string i_PlateNumber)
        {
            foreach (GarageCustomer customer in m_Customers)
            {
                if (customer.Vehicle.PlateNumber.Equals(i_PlateNumber))
                {
                    return customer;
                }
            }

            return null;
        }

        public bool isCustomerEnrolled(string i_PlateNumber)
        {
            return FindCustomerByPlateNumber(i_PlateNumber) != null;
        }

        public List<string> filterPlateNumbersByStatus(MotorVehicle.eVehicleStatus i_Status)
        {
            List<string> res = (from customer in m_Customers
                                where customer.Vehicle.Status == i_Status
                select customer.Vehicle.PlateNumber).ToList();
            return res;
        }

        
    }

    public class GarageCustomer
    {
        
        private string m_Name;
        private string m_PhoneNumber;
        private MotorVehicle m_Vehicle;


        public GarageCustomer(string i_Name, string i_PhoneNumber, MotorVehicle i_Vehicle)
        {
            this.m_Name = i_Name;
            this.m_PhoneNumber = i_PhoneNumber;
            this.m_Vehicle = i_Vehicle;
            
        }
        
        /** A method that compares two customers.
         *  By assumption, we don't support a customer with multiple vehicles,
         *  therefore, two customers will be considered equal if they own the same car
         *
         *  Note that two cars are considered equal according to their plate number.
         *
         */
        public bool Equals(GarageCustomer i_Other)
        {
            return i_Other.m_Vehicle.Equals(this.m_Vehicle);
        }



        public string Name
        {
            get { return this.m_Name; }
            set { this.m_Name = value; }
        }
        public string PhoneNumber
        {
            get { return this.m_PhoneNumber; }
            set { this.m_PhoneNumber = value; }
        }
        public MotorVehicle Vehicle
        {
            get { return this.m_Vehicle; }
            set { this.m_Vehicle = value; }
        }

        public override string ToString()
        {
            return $@"Customer Name: {Name}
Customer Phone Number: {PhoneNumber}
Customer Vehicle:
{Vehicle}";
        }

    }
}
