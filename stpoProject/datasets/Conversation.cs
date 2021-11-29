using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class Conversation
    {
        private int m_IDto;
        private int m_IDfrom;

        public Conversation(int IDto, int IDfrom)
        {
            m_IDto = IDto;
            m_IDfrom = IDfrom;
        }

        public int IDto()
        {
            return m_IDto;
        }

        public int IDfrom()
        {
            return m_IDfrom;
        }
    }
}