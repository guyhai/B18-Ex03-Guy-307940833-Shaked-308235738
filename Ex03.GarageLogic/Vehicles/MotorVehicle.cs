using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic
{
    public abstract class MotorVehicle
    {
        private List<Wheel> m_Wheels;
        private string m_PlateNumber;
        private string m_Manufacture;
        private float m_EnergyPercentage;

        private IEngine m_Engine;

        private eVehicleStatus m_Status = eVehicleStatus.inRepair;


        protected internal MotorVehicle(List<Wheel> i_Wheels, string i_PlateNumber, string i_Manufacture,
            float i_EnergyPercentage, IEngine i_Engine)
        {
            m_Wheels = i_Wheels;
            m_PlateNumber = i_PlateNumber;
            m_Manufacture = i_Manufacture;
            m_EnergyPercentage = i_EnergyPercentage;
            m_Engine = i_Engine;
        }

       
        public enum eVehicleStatus
        {
            inRepair,
            Repaired,
            Payed
        }

        /** everyone can get and see the wheels but only internal classes can edit wheels.
         *
         */
        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            internal set { m_Wheels = value; }
        }

        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
            set { this.m_EnergyPercentage = value; }
        }

        public string Manufacture
        {
            get { return m_Manufacture; }
        }

        public IEngine Engine
        {
            get { return m_Engine; }
            set { this.Engine = value; }
        }

        internal eVehicleStatus Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }


        public string PlateNumber
        {
            get { return this.m_PlateNumber; }
        }
//        public string EnergyPercentage
//        {
//            get { return m_EnergyPercentage.ToString(); }
//            set
//            {
//                float toSet = -1.0f;
//
//                try
//                {
//                    toSet = float.Parse(value);
//                }
//                catch (FormatException)
//                {
//                    throw new FormatException("invalid format for energy percentage");
//                }
//
//
//                if (!(toSet <= 100.00f) && (toSet >= 0.0f))   
//                {
//                    throw new ValueOutOfRangeException("energy percentage input out of range", 0.0f, 100.0f);
//                }
//
//                m_EnergyPercentage = toSet;
//            }
//        }


        /** Two motor vehicles will be considered equal if and only if their two plate numbers
         *  are the same.
         *
         */
        public bool Equals(MotorVehicle i_Other)
        {
            return i_Other.PlateNumber.Equals(this.PlateNumber);
        }


    }
    public class Wheel
    {
        private string m_Manufacture;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;


        public Wheel(string i_Manufacture, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Manufacture = i_Manufacture;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }
        public void Inflate(float i_AirToInflate)
        {
            if(i_AirToInflate + m_CurrentAirPressure <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToInflate;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Max air-pressure exceeded");
            }
        }

        public void InflateToMax()
        {
            Inflate(m_MaxAirPressure - m_CurrentAirPressure);
        }
        

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Manufacturer: ");
            stringBuilder.Append(m_Manufacture.ToString());
            stringBuilder.Append(" ");
            stringBuilder.Append("Current Air Pressure: ");
            stringBuilder.Append(m_CurrentAirPressure.ToString());
            stringBuilder.Append(" ");
            stringBuilder.Append("Maximum Air Pressure: ");
            stringBuilder.Append(m_MaxAirPressure.ToString());

            return stringBuilder.ToString();
        }
        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            internal set { m_MaxAirPressure = value; }
        }

        public string Manufacture
        {
            get { return m_Manufacture; }
            set { m_Manufacture = value; }
        }
    }
}
