using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engines.IEngine
    {

        private eFuelType m_FuelType;
        private float m_AmountOfFuel;
        private float m_MaxFuelAmount;

        protected internal FuelEngine(eFuelType i_FuelType, float i_AmountOfFuel, float i_MaxFuelAmount)
        {
            this.m_FuelType = i_FuelType;
            this.m_AmountOfFuel = i_AmountOfFuel;
            this.m_MaxFuelAmount = i_MaxFuelAmount;
        }


       
        public bool PutGas(float i_FuelAmount)
        {
            bool res = false;
            float amountAfterIncrease = m_AmountOfFuel + i_FuelAmount;
            
            if (amountAfterIncrease < m_MaxFuelAmount)
            {
                m_AmountOfFuel = amountAfterIncrease;
                res = true;
            }
            else
            {
                throw new ValueOutOfRangeException(
                    "Trying to put amount of fuel that exceeds the max of the engine", 0, m_MaxFuelAmount);
            }

            return res;


        }

        public Type EngineType()
        {
            return this.GetType();
        }

        public float MaxFuelAmount
        {
            get { return m_MaxFuelAmount; }
        }

        public eFuelType FuelType
        {
            get { return m_FuelType; }
        }

        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public override string ToString()
        {

            string res = $@"{base.ToString()}
Type of Engine: Fuel Engine
Fuel Type: {m_FuelType}
Max Fuel Amount: {m_MaxFuelAmount}
Amount Of Fuel Left: {m_AmountOfFuel}";
            return res;
        }

    }
}
