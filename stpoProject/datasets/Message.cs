using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class Message
    {
        private int m_ID;
        private int m_ID_from;
        private int m_ID_to;
        private string m_content;

        public Message(int ID, int IDfrom, int IDto, string content)
        {
            m_ID = ID;
            m_ID_from = IDfrom;
            m_ID_to = IDto;
            m_content = content;
        }

        public Message(int IDfrom, int IDto, string content)
        {
            m_ID_from = IDfrom;
            m_ID_to = IDto;
            m_content = content;
        }

        public int ID()
        {
            return m_ID;
        }
        public int ID_from()
        {
            return m_ID_from;
        }
        public int ID_to()
        {
            return m_ID_to;
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