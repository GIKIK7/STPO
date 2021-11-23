using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;
    public class UserController
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        private List<User> m_users = new List<User>();

        public void getUserListFromDatabase()
        {
            m_users.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetUser = "SELECT * FROM [dbo].[users]";

            SqlCommand cmdGetUser = new SqlCommand(strGetUser, connection);
            SqlDataReader readerGetUser = cmdGetUser.ExecuteReader();

            while (readerGetUser.Read())
            {
                int userID = Int16.Parse(readerGetUser.GetValue(0).ToString());
                string UserLogin = readerGetUser.GetValue(1).ToString();
                string userPassword = readerGetUser.GetValue(2).ToString();
                bool userIsTrener = bool.Parse(readerGetUser.GetValue(3).ToString());

                User user = new User(userID, UserLogin, userPassword, userIsTrener);
                m_users.Add(user);
            }
            connection.Close();
        }

        public List<User> getUserList()
        {
            return m_users;
        }

        public void addUser(string login, string password, bool isTrener)
        {
            User user = new User(login, password, isTrener);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;


            int user_id = 0;

            String sql = "INSERT INTO [dbo].[users] (login, password, isTrener) VALUES ('" + login + "','" + password + "','" + isTrener + "')";

            cmd = new SqlCommand(sql, connection);

            cmd.ExecuteReader();

            connection.Close();



            connection.Open();

            String getIdUser = "SELECT ID FROM [dbo].[users] WHERE login='" + login + "' AND password='" + password + "'";

            using (SqlCommand command = new SqlCommand(getIdUser, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user_id = Int16.Parse(reader.GetValue(0).ToString());
                    }
                }
            }
            user.setID(user_id);

            m_users.Add(user);

            connection.Close();

        }
    
        public int getUserIDBy(string login, string password)
        {
            foreach (User user in m_users) {
                if(user.login() == login && user.password() == password)
                {
                    return user.ID();
                }
            }
            return 0;
        }

        public int geIDByLogin(string login)
        {
            foreach (User user in m_users)
            {
                if (user.login() == login)
                {
                    return user.ID();
                }
            }
            return 0;
        }

        public User getUserbyID(int ID)
        {
            foreach (User user in m_users)
            {
                if (user.ID() == ID)
                {
                    return user;
                }
            }
            return null;
        }
    
        public bool isUnique(string login)
        {
            foreach (User user in m_users)
            {
                if (user.login() == login)
                {
                    return false;
                }
            }
            return true;
        }
    
        public string getLoginByID(int ID)
        {
            foreach (User user in m_users)
            {
                if(user.ID() == ID)
                {
                    return user.login();
                }
            }
            return "";
        }
    }
}