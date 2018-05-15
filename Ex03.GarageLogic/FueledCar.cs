using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FueledCar : Car
    {
//        private const float k_MaximumWheelAirPressure = 32.0f;  //Shouldn't be here, propperty of wheel
//        private const float k_MaximumFuelAmount = 45.0f;        //Shouldn't be here, property of engine.
//        private const FuelEngine.eFuelType k_FuelType = FuelEngine.eFuelType.Octan98;   //Property of engine as well.
        private FuelEngine m_Engine;
        
        public FueledCar(string i_Manufacture, string i_WheelManufacture):base ()
        {

            m_Engine = new FuelEngine(FuelEngine.eFuelType.Octan98, 0.0f, 45.0f);
            this.createWheels();

        }
        private void createWheels()
        {
           
        }

    }
}
