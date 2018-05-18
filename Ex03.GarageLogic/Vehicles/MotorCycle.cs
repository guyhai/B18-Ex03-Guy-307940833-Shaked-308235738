using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic.Engines;

namespace Ex03.GarageLogic
{
    public class MotorCycle: MotorVehicle
    {
        private int m_EngineVolume;
        private eLicense m_LicenseType;

        protected internal MotorCycle(List<Wheel> i_Wheels, string i_PlateNumber, string i_Manufacture, float i_EnergyPercentage, IEngine i_Engine, int mEngineVolume, eLicense mLicenseType) : 
            base(i_Wheels, i_PlateNumber, i_Manufacture, i_EnergyPercentage, i_Engine)
        {
            m_EngineVolume = mEngineVolume;
            m_LicenseType = mLicenseType;
        }

        public enum eLicense
        {
            A,
            A1,
            B1,
            B2
        }

        
    }
}
