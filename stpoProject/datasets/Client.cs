using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class Client
    {
        private int m_ID;
        private int m_ID_user;
        private string m_name;
        private string m_lastName;

        public Client(int ID, int ID_user, string name, string lastName)
        {
            m_ID = ID;
            m_ID_user = ID_user;
            m_name = name;
            m_lastName = lastName;
        }

        public Client(int ID_user, string name, string lastName)
        {
            m_ID_user = ID_user;
            m_name = name;
            m_lastName = lastName;
        }

        public int ID()
        {
            return m_ID;
        }
        public int ID_user()
        {
            return m_ID_user;
        }
        public string name()
        {
            return m_name;
        }
        public string lastName()
        {
            return m_lastName;
        }

        public void setID(int ID)
        {
            m_ID = ID;
        }
    }
}