using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class Diet
    {
        private int m_ID;
        private int m_ID_user;
        private int m_ID_mealList;
        private DateTime m_date;

        public Diet(int ID, int ID_user, int ID_mealList, DateTime date)
        {
            m_ID = ID;
            m_ID_user = ID_user;
            m_ID_mealList = ID_mealList;
            m_date = date;
        }

        public int ID()
        {
            return m_ID;
        }

        public int ID_user()
        {
            return m_ID_user;
        }

        public int ID_mealList()
        {
            return m_ID_mealList;
        }

        public string date()
        {
            return m_date.Year + "-" + m_date.Month + "-" + m_date.Day;
        }

        public void setID(int ID)
        {
            m_ID = ID;
        }

        public void setID_user(int ID)
        {
            m_ID_user = ID;
        }

        public void setID_meals(int ID)
        {
            m_ID_mealList = ID;
        }

        public void setDate(DateTime date)
        {
            m_date = date;
        }
    }
}