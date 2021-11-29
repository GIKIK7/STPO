using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class Comment
    {
        private int m_ID;
        private int m_ID_UserClient;
        private int m_ID_UserCoach;
        private string m_content;

        public Comment(int ID, int IDfrom, int IDto, string content)
        {
            m_ID = ID;
            m_ID_UserClient = IDfrom;
            m_ID_UserCoach = IDto;
            m_content = content;
        }

        public Comment(int IDfrom, int IDto, string content)
        {
            m_ID_UserClient = IDfrom;
            m_ID_UserCoach = IDto;
            m_content = content;
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
        public string content()
        {
            return m_content;
        }

        public void setID(int ID)
        {
            m_ID = ID;
        }
    }
}