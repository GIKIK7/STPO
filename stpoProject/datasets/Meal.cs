using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class Meal
    {
        private int m_ID;
        private string m_name;

        public Meal(int ID, string name)
        {
            m_ID = ID;
            m_name = name;
        }

        public void setID(int ID)
        {
            m_ID = ID;
        }

        public int ID()
        {
            return m_ID;
        }

        public string name()
        {
            return m_name;
        }
    }
}