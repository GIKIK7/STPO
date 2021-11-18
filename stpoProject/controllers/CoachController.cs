using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;
    public class CoachController
    {

        private List<Coach> m_coaches = new List<Coach>();

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        public void getCoachListFromDatabase()
        {
            m_coaches.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetCoach = "SELECT * FROM [dbo].[coaches]";

            SqlCommand cmdGetCoach = new SqlCommand(strGetCoach, connection);
            SqlDataReader readerGetCoach = cmdGetCoach.ExecuteReader();

            while (readerGetCoach.Read())
            {
                int coachID = Int16.Parse(readerGetCoach.GetValue(0).ToString());
                int coachtUserID = Int16.Parse(readerGetCoach.GetValue(1).ToString());
                string coachName = readerGetCoach.GetValue(2).ToString();
                string coachLastName = readerGetCoach.GetValue(3).ToString();
                int ID_category = 0;

                if (readerGetCoach.GetValue(4).ToString() != "")
                {
                    ID_category = Int16.Parse(readerGetCoach.GetValue(4).ToString());
                }

                Coach coach = new Coach(coachID, coachtUserID, coachName, coachLastName, ID_category);
                m_coaches.Add(coach);
            }
            connection.Close();
        }

        public List<Coach> getCoachList()
        {
            return m_coaches;
        }

        public Coach getCoachByIDuser(int ID)
        {
            foreach (Coach coach in m_coaches)
            {
                if (coach.ID_user() == ID)
                {
                    return coach;
                }
            }
            return null;
        }

        public void addCoach(int ID_user, string name, string lastName, int ID_category)
        {

            Coach coach = new Coach(ID_user, name, lastName);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;

            String insertStr = "INSERT INTO [dbo].[coaches] (ID_user, name, last_name, ID_category) VALUES ('" + ID_user + "','" + name + "','" + lastName + "','" + ID_category + "')";

            using (cmd = new SqlCommand(insertStr, connection))
            {
                cmd.ExecuteReader();
            }

            connection.Close();


            connection.Open();

            int coachID = 0;

            String getCoachID = "SELECT ID FROM [dbo].[coaches] WHERE ID_user='" + ID_user +"'";

            using (SqlCommand command = new SqlCommand(getCoachID, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        coachID = Int16.Parse(reader.GetValue(0).ToString());
                    }
                }
            }
            coach.setID(coachID);

            m_coaches.Add(coach);

            connection.Close();
        }
    
        public int getIDuserByIDcoach(int ID)
        {
            foreach (Coach coach in m_coaches)
            {
                if(coach.ID() == ID)
                {
                    return coach.ID_user();
                }
            }
            return -1;
        }
    
        public void updateCoach(string name, string lastName, int category, int ID_user)
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String updateCoach = "UPDATE [dbo].[coaches] SET name ='" + name + "', last_name='" + lastName + "', ID_category='" + category
                + "'WHERE ID_user =" + ID_user;


            SqlCommand cmdEditCoach = new SqlCommand(updateCoach, connection);
            cmdEditCoach.ExecuteReader();

            connection.Close();

            foreach (Coach coach in m_coaches)
            {
                if (coach.ID_user() == ID_user)
                {
                    coach.setName(name);
                    coach.setLastName(lastName);
                    coach.setIDcategory(category);
                }
            }
        }    
    }
}