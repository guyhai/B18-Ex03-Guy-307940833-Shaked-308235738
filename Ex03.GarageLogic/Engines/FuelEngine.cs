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


       
        public void PutGas(float i_FuelAmount, eFuelType i_FuelType)
        {
            float amountAfterIncrease = m_AmountOfFuel + i_FuelAmount;
            if (i_FuelType == m_FuelType)
            {
                if (amountAfterIncrease < m_MaxFuelAmount)
                {
                    m_AmountOfFuel = amountAfterIncrease;
                }
                else
                {
                    throw new ValueOutOfRangeException(
                        "Trying to put amount of fuel that exceeds the max of the engine", 0, m_MaxFuelAmount);
                }
            }
            else
            {
                throw new WrongTypeException<eFuelType>(m_FuelType, i_FuelType);
            }
            
        }

        public Type EngineType()
        {
            return this.GetType();
        }


        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

    }
}
