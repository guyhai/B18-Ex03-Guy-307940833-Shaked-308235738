using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class MotorVehicle
    {
        private List<Wheel> m_Wheels;
        private string m_PlateNumber;
        private string m_Manufacture { get; }
        private float m_EnergyPercentage { get; }
        private eVehicleStatus m_Status;



        protected MotorVehicle()
        {
            m_Wheels = new List<Wheel>();
            m_PlateNumber = string.Empty;
            m_Manufacture = string.Empty;
            m_EnergyPercentage = 0.0f;
        }
        

       

        public enum eVehicleStatus
        {
            inRepair,
            Repaired,
            Done
        }


        public string PlateNumber
        {
            get { return this.m_PlateNumber; }
        }


    }
    public class Wheel
    {
        private string m_Manufacture;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        public Wheel()
        {
            m_Manufacture = null;
            m_CurrentAirPressure = 0.0f;
            m_MaxAirPressure = 0.0f;
        }
        public void inflate(float i_AirToInflate)
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
