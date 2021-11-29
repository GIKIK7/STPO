using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class Rating
    {
        private int m_ID;
        private int m_ID_UserClient;
        private int m_ID_UserCoach;
        private int m_value;

        public Rating(int ID, int IDfrom, int IDto, int rating)
        {
            m_ID = ID;
            m_ID_UserClient = IDfrom;
            m_ID_UserCoach = IDto;
            m_value = rating;
        }

        public Rating(int IDfrom, int IDto, int rating)
        {
            m_ID_UserClient = IDfrom;
            m_ID_UserCoach = IDto;
            m_value = rating;
        }

        public int ID()
        {
            return m_ID;
        }
        public int ID_client()
        {
            return m_ID_UserClient;
        }
        public int ID_coach()
        {
            return m_ID_UserCoach;
        }
        public int value()
        {
            return m_value;
        }
        public void setID(int ID)
        {
            m_ID = ID;
        }
    }
}