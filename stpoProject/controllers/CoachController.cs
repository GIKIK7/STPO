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

        public void getCoachListFromDatabase()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = "stpo.database.windows.net",
                UserID = "GIKIK",
                Password = "AdminHaslo137",
                InitialCatalog = "DBstpo"
            };

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


    }
}