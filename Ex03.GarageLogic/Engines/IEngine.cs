using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic.Engines
{
    /* By our implemetation currently there is no common fields or methods between
     * the electric engine and the fueled one except that conceptually they are both
     * engines.
     *
     */
    public interface IEngine
    {
        Type EngineType();
    }
}
