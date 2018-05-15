using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Garage
    {
        private List<GarageCustomer> m_Customers;


        public Garage()
        {
            this.m_Customers = new List<GarageCustomer>();
        }

        private void addCustomer(GarageCustomer i_customer)
        {
            m_Customers.Add(i_customer);
        }



        public void addCar(string i_PlateNumber, string i_Name, string i_PhoneNumber)
        {
            GarageCustomer customer = FindCustomerByPlateNumber(i_PlateNumber);

            if (customer == null)
            {

            }
            else
            {

            }
        }
        
        /** This has to be by license number and not the vehicle object
         *
         */
        private void addCar(MotorVehicle i_Vehicle, string i_Name, string i_PhoneNumber)
        {
            if (!DoesContainCar(i_Vehicle))
            {
                m_Customers.Add(new GarageCustomer(i_Name, i_PhoneNumber, i_Vehicle));
            }
            else
            {

            }
        }

        private bool DoesContainCar(MotorVehicle i_Vehicle)
        {
            return FindCustomerByPlateNumber(i_Vehicle.PlateNumber) != null;
        }

        public void ChangeStatus(string i_PlateNumber, MotorVehicle.eVehicleStatus i_Status)
        {
            //TODO will change vehicle status according to license plate
        }
        public void InflateToMax(string i_PlateNumber)
        {
            //TODO inflate all wheels of a vehicle to max 
        }
        public void FuelVehicle(string i_PlateNumber, FuelEngine.eFuelType i_Type, float i_Amount)
        {
            //TODO fuel a vehicle
        }
        public void ChargeVehicle(string i_PlateNumber, float i_Amount)
        {

            //TODO charge a vehicle
        }
        public void ShowVehicleDetails(string i_PlateNumber)
        {
            //TODO show full details (manufacture, licence number,wheels(psi and manufacture), owner name, owner phone etc....)
            //probably going to use all the ToString(s) methods
        }

        /** return null if it doesn't exist
         *
         */
        private GarageCustomer FindCustomerByPlateNumber(string i_PlateNumber)
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

    }

    class GarageCustomer
    {
        //i think this might complicate things 
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

    }
}
