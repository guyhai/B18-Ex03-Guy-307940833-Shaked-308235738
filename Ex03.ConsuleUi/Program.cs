using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsuleUi
{
    public class Program
    {
        public static void Main()
        {
            Garage Garage = new Garage();
            GarageDashBoard DashBoard = new GarageDashBoard(Garage);
            DashBoard.Start();
        }
    }
}
