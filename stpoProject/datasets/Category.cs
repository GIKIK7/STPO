using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class Category
    {
        int m_ID;
        string m_name;

        public Category(int ID, string name)
        {
            m_ID = ID;
            m_name = name;
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