using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;
    public class RatingController
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        List<Rating> m_ratings = new List<Rating>();

        public void getRatingsFromDatabase()
        {
            m_ratings.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetData = "SELECT * FROM [dbo].[ratings]";

            SqlCommand cmdGetData = new SqlCommand(strGetData, connection);
            SqlDataReader readerGetData = cmdGetData.ExecuteReader();

            while (readerGetData.Read())
            {
                int ID = Int16.Parse(readerGetData.GetValue(0).ToString());
                int ID_Client = Int16.Parse(readerGetData.GetValue(1).ToString());
                int ID_Coach = Int16.Parse(readerGetData.GetValue(2).ToString());
                int ratingVal = Int16.Parse(readerGetData.GetValue(3).ToString());

                Rating rating = new Rating(ID, ID_Client, ID_Coach, ratingVal);
                m_ratings.Add(rating);
            }
            connection.Close();
        }

        public void addRating(int ID_Client, int ID_Coach, int rate)
        {
            Rating rating = new Rating(ID_Client, ID_Coach, rate);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;

            String insertStr = "INSERT INTO [dbo].[ratings] (ID_userClient, ID_userCoach, rate) VALUES ('" + ID_Client + "','" + ID_Coach + "','" + rate + "')";

            using (cmd = new SqlCommand(insertStr, connection))
            {
                cmd.ExecuteReader();
            }

            connection.Close();


            connection.Open();

            int commentID = 0;

            String getMessageID = "SELECT ID FROM [dbo].[ratings] WHERE rate='" + rate + "' AND ID_userClient ='" + ID_Client + "' AND ID_userCoach ='" + ID_Coach + "'";

            using (SqlCommand command = new SqlCommand(getMessageID, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        commentID = Int16.Parse(reader.GetValue(0).ToString());
                    }
                }
            }
            rating.setID(commentID);

            m_ratings.Add(rating);

            connection.Close();
        }

        public double getAverageRating(int ID_Coach)
        {
            double avr = 0.0;

            int sum = 0;
            int i = 0;

            foreach (Rating rating in m_ratings)
            {
                if(rating.ID_coach() == ID_Coach)
                {
                    i++;
                    sum += rating.value();
                }
            }

            if (i > 0)
            {
                return avr = sum / double.Parse(i.ToString());
            }
            else return 0.0;
        }
    
        public bool youVoted(int ID_userClient, int ID_coach)
        {
            foreach (Rating rating in m_ratings)
            {
                if (rating.ID_client() == ID_userClient && rating.ID_coach() == ID_coach)
                {
                    return true;
                }
            }
            return false;
        }
    
        public int getYourValue(int ID_userClient)
        {
            foreach (Rating rating in m_ratings)
            {
                if (rating.ID_client() == ID_userClient)
                {
                    return rating.value();
                }
            }
            return 1;
        }

        public void updateYourValue(int ID_userClient, int ID_userCoach, int value)
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strUpdateData = "UPDATE [dbo].[ratings] SET rate ='" + value + "' WHERE ID_userClient ='" + ID_userClient + "' AND ID_userCoach ='" + ID_userCoach + "'";

            SqlCommand cmdUpdate = new SqlCommand(strUpdateData, connection);
            cmdUpdate.ExecuteReader();

            connection.Close();
        }

    }
}