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
        private const int k_NumOfWheels = 4;
        public override void Initialize(Dictionary<string, string> i_Form)
        {
            base.Initialize(i_Form);
            
            string colorStr;
            if (!i_Form.TryGetValue("Color", out colorStr))
            {
                throw new KeyNotFoundException("missing color");
            }

            string numberOfDoorsStr;
            if (!i_Form.TryGetValue("Number of doors", out numberOfDoorsStr))
            {
                throw new KeyNotFoundException("missing number of doors");
            }
            //TODO getter setter for both converting string to enum ... 
            m_Color = colorStr;
            m_NumOfDoors = numberOfDoorsStr;
            //also need to initialize wheels
        }
        public override Dictionary<string, string> MakeForm()
        {
            Dictionary<string, string> form = base.MakeForm();
            form.Add("Color", null);
            form.Add("Number of doors", null);
            //TODO take care of wheels (also need make form perhaps?!)
            return form;
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
