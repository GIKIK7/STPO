using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class Coach
    {
        private int m_ID;
        private int m_ID_user;
        private string m_name;
        private string m_lastName;
        private int m_ID_category;
        private int m_dietPrice;
        private int m_workoutPrice;

        public Coach(int ID, int ID_user, string name, string lastName, int ID_category)
        {
            m_ID = ID;
            m_ID_user = ID_user;
            m_name = name;
            m_lastName = lastName;
            m_ID_category = ID_category;
        }

        public Coach(int ID_user, string name, string lastName)
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

        public int ID_category()
        {
            return m_ID_category;
        }

        public int dietPrice()
        {
            return m_dietPrice;
        }

        public int workoutPrice()
        {
            return m_workoutPrice;
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

        public void setIDcategory(int IDcategory)
        {
            m_ID_category = IDcategory;
        }

        public void setDietPrice(int price)
        {
            m_dietPrice = price;
        }

        public void setworkoutPrice(int price)
        {
            m_workoutPrice = price;
        }

    }
}