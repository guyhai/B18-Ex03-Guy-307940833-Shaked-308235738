using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class FueledCar : Car
    {
        
        public FueledCar(string i_Manufacture, string i_WheelManufacture):base ()
        {
            this.Engine = new FuelEngine(FuelEngine.eFuelType.Octan98, 0.0f, 45.0f);
            this.createWheels();
        }

        private void createWheels()
        {
            this.Wheels = new List<Wheel>();

            for (int i = 0; i < 4; i++)
            {
                Wheels.Add(new Wheel());
            }
        }

    }
}
