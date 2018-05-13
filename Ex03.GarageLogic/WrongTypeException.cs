using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class WrongTypeException<T> : ArgumentException
    {
        private T m_Expected;
        private T m_Actual;

        public T Expected
        {
            get { return m_Expected; }
            set { m_Expected = value; }
        }

        public T Actual
        {
            get { return m_Actual; }
            set { m_Actual = value; }
        }

        public WrongTypeException(T i_Expected, T i_Actual)
        {
            this.m_Expected = i_Expected;
            this.m_Actual = i_Actual;
        }

        public override string ToString()
        {
            return string.Format("Expected value: {0}, Actual Value: {1}", Expected, Actual);
        }
    }
}
