using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic
{
    public class Car : MotorVehicle
    {
        private eColor m_Color;
        private eNumOfDoors m_NumOfDoors;
        private const int k_NumOfWheels = 4;

        protected internal Car(List<Wheel> i_Wheels, string i_PlateNumber, string i_Manufacture, float i_EnergyPercentage, IEngine i_Engine, eColor mColor, eNumOfDoors mNumOfDoors) : 
            base(i_Wheels, i_PlateNumber, i_Manufacture, i_EnergyPercentage, i_Engine)
        {
            m_Color = mColor;
            m_NumOfDoors = mNumOfDoors;
        }

        
        public enum eColor
        {
            Grey,
            Blue,
            White,
            Black   
        }
        public enum eNumOfDoors
        {
            Two,
            Three,
            Four,
            Five
        }
    }
}
