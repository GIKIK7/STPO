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
        private int m_ID_assign_coach=0;
        private int m_ID_assign_diet=0;
        private int m_ID_assign_training=0;

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

        public int ID_assign_coach()
        {
            return m_ID_assign_coach;
        }
        public int ID_assign_diet()
        {
            return m_ID_assign_diet;
        }

        public int ID_assign_training()
        {
            return m_ID_assign_training;
        }

        public void setID(int ID)
        {
            m_ID = ID;
        }

        public void setName(string name)
        {
            m_name = name;
        }

        public void setLastName(string lastName)
        {
            m_lastName = lastName;
        }

        public void setID_assign_coach(int ID_assignCoach)
        {
            m_ID_assign_coach = ID_assignCoach;
        }

        public void setID_assign_diet(int ID)
        {
            m_ID_assign_diet = ID;
        }

        public void setID_assign_training(int ID)
        {
            m_ID_assign_training = ID;
        }
    }
}