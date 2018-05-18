using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic
{
    public class Truck: MotorVehicle
    {
        private bool m_RiskyMaterials;
        private float m_MaxCarry;

        protected internal Truck(List<Wheel> i_Wheels, string i_PlateNumber, string i_Manufacture, float i_EnergyPercentage, IEngine i_Engine, bool mRiskyMaterials, float mMaxCarry) :
            base(i_Wheels, i_PlateNumber, i_Manufacture, i_EnergyPercentage, i_Engine)
        {
            m_RiskyMaterials = mRiskyMaterials;
            m_MaxCarry = mMaxCarry;
        }

        public override string ToString()
        {
            string res = $@"{base.ToString()}
Carries Risky Materials: {m_RiskyMaterials}
Number of Doors: {m_MaxCarry}";
            return res;
        }
    }

   
}
