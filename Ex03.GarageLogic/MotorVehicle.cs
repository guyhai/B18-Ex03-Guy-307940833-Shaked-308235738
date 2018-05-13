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
        private string m_Manufacture { get; set; }
        private float m_EnergyPercentage { get; set; }
        private string m_OwnerName { get; set; }
        private string m_OwnerPhone { get; set; }
        private eVehicleStatus m_Status;



        protected MotorVehicle()
        {
            m_Wheels = new List<Wheel>();
            m_PlateNumber = string.Empty;
            m_Manufacture = string.Empty;
            m_EnergyPercentage = 0.0f;
            m_Status = eVehicleStatus.inRepair;
        }
        public virtual void Initialize(Dictionary<string, string> i_Form)
        {
            string ownerName;
            if (!i_Form.TryGetValue("Car Owner", out ownerName))
            {
                throw new KeyNotFoundException("Car Owner Missing");
            }

            string ownerPhone;
            if (!i_Form.TryGetValue("Owner Phone", out ownerPhone))
            {
                throw new KeyNotFoundException("Owner Phone Missing");
            }

            string manufacture;
            if (!i_Form.TryGetValue("Car Manufacture", out manufacture))
            {
                throw new KeyNotFoundException("Car Manufacture Missing");
            }

            string energyPercent;
            if (!i_Form.TryGetValue("Energy percentage", out energyPercent))
            {
                throw new KeyNotFoundException("Energy percentage Missing");
            }

            

            m_Manufacture = manufacture;
            m_OwnerName = ownerName;
            m_OwnerPhone = ownerPhone;
            EnergyPercentage = energyPercent;

        }
        public virtual Dictionary<string, string> MakeForm()
        {
            Dictionary<string, string> form = new Dictionary<string, string>();
            form.Add("Car Owner", null);
            form.Add("Owner Phone", null);
            form.Add("Car Manufacture", null);
            form.Add("Energy percentage", null);

            return form;
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
        public string EnergyPercentage
        {
            get { return m_EnergyPercentage.ToString(); }
            set
            {
                float toSet = -1.0f;

                try
                {
                    toSet = float.Parse(value);
                }
                catch (FormatException)
                {
                    throw new FormatException("invalid format for energy percentage");
                }


                if (!(toSet <= 100.00f) && (toSet >= 0.0f))   
                {
                    throw new ValueOutOfRangeException("energy percentage input out of range", 0.0f, 100.0f);
                }

                m_EnergyPercentage = toSet;
            }
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
