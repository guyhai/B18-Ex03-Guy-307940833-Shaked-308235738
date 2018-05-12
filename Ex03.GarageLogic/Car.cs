using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Car : MotorVehicle
    {
        private eColor m_Color;
        private eNumOfDoors m_NumOfDoors;
        public Car()
        {
            //TODO
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
