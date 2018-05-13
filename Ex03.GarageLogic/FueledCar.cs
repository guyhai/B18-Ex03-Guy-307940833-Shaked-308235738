using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FueledCar : Car
    {
        private const float k_MaximumWheelAirPressure = 32.0f;
        private const float k_MaximumFuelAmount = 45.0f;
        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan98;
        private FuelEngine m_Engine;
        
        public FueledCar(string i_Manufacture, string i_WheelManufacture):base ()
        {
            
            m_Engine = new FuelEngine(k_FuelType, 0.0f, k_MaximumFuelAmount);
           
        }
        private void createWheels()
        {
           
        }

    }
}
