using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engines.IEngine
    {
        private float m_BatteryTimeLeft;    //hours
        private float m_MaxBatteryLife;     //hours

        protected internal ElectricEngine(float i_BatteryTimeLeft, float i_MaxBatteryLife)
        {
            m_BatteryTimeLeft = i_BatteryTimeLeft;
            m_MaxBatteryLife = i_MaxBatteryLife;
        }

        public void chargeBattery(float i_AmountToCharge)
        {
            if (i_AmountToCharge + m_BatteryTimeLeft > m_MaxBatteryLife)
            {
                m_BatteryTimeLeft += i_AmountToCharge;
            }
            else
            {
                throw new ValueOutOfRangeException(
                    "Trying to charge an engine battery over the limit", 0, m_BatteryTimeLeft);
            }
        }

        public Type EngineType()
        {
            return this.GetType();
        }
    }
}
