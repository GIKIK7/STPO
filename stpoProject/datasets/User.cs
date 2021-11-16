using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.datasets
{
    public class User
    {
        private int m_ID;
        private string m_login ;
        private string m_password;
        private bool m_isTrener;

        public User(int ID, string login, string password, bool isTrener)
        {
            m_ID = ID;
            m_login = login;
            m_password = password;
            m_isTrener = isTrener;
        }

        public User(string login, string password, bool isTrener)
        {
            m_login = login;
            m_password = password;
            m_isTrener = isTrener;
        }

        public int ID()
        {
            return m_ID;
        }
        public string login()
        {
            return m_login;
        }
        public string password()
        {
            return m_password;
        }
        public bool isTrener()
        {
            return m_isTrener;
        }
        public void setID(int ID)
        {
            m_ID = ID;
        }
    }
}