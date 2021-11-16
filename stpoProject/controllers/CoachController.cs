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

                Coach coach = new Coach(coachID, coachtUserID, coachName, coachLastName);
                m_coaches.Add(coach);
            }
            connection.Close();
        }

        public List<Coach> getCoachList()
        {
            return m_coaches;
        }

        public void addCoach(int ID_user, string name, string lastName)
        {

            Coach coach = new Coach(ID_user, name, lastName);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;

            String insertStr = "INSERT INTO [dbo].[coaches] (ID_user, name, last_name) VALUES ('" + ID_user + "','" + name + "','" + lastName + "')";

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
    }
}