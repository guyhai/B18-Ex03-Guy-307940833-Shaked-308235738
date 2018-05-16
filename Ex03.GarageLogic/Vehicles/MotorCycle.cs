using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class MotorCycle: MotorVehicle
    {
        private int m_EngingVolume;
        private eLicense m_LicenseType;

        public enum eLicense
        {
            A,
            A1,
            B1,
            B2
        }

        
    }
}
