using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace stpoProject.controllers
{
    using datasets;
    public class DietController
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        List<Diet> m_diets = new List<Diet>();
        public string showDiet()
        {
            string str = "";
            foreach (Diet diet in m_diets)
            {
                str += diet.ID() + " " + diet.ID_user() + " " + diet.ID_mealList() + " " + diet.date() + " ";
            }
            return str;
        }

        public void getDietsFromDatabase()
        {
            m_diets.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetDiets = "SELECT * FROM [dbo].[diet]";

            SqlCommand cmdGetDiets = new SqlCommand(strGetDiets, connection);
            SqlDataReader readerGetDiets = cmdGetDiets.ExecuteReader();

            while (readerGetDiets.Read())
            {
                int DietID = Int16.Parse(readerGetDiets.GetValue(0).ToString());
                int userID = Int16.Parse(readerGetDiets.GetValue(1).ToString());
                int mealListID = Int16.Parse(readerGetDiets.GetValue(2).ToString());
                DateTime date = DateTime.Parse(readerGetDiets.GetValue(3).ToString());

                Diet Diet = new Diet(DietID, userID, mealListID, date);
                m_diets.Add(Diet);
            }
            connection.Close();
        }
    
        public List<Diet> getDietsOfUser(int ID_user)
        {
            List<Diet> diets = new List<Diet>();
            foreach (Diet diet in m_diets)
            {
                if(diet.ID_user() == ID_user)
                {
                     diets.Add(diet);
                }
            }
            return diets;
        }
    
        public Diet getDietByDate(string date, int ID_user)
        {
            foreach (Diet diet in m_diets)
            {
                if (diet.date() == date && diet.ID_user() == ID_user)
                {
                    return diet;
                }
            }
            return null;
        }

        public void addDiet(int ID_user, int ID_mealList, string dateStr)
        {
            DateTime date = DateTime.Parse(dateStr);

            Diet diet = new Diet(ID_user, ID_mealList, date);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;

            String insertStr = "INSERT INTO [dbo].[diet] (ID_user, ID_mealList ,dateDiet) VALUES ('" + ID_user + "','" + ID_mealList + "','" + dateStr + "')";

            using (cmd = new SqlCommand(insertStr, connection))
            {
                cmd.ExecuteReader();
            }

            connection.Close();


            connection.Open();

            int ID = 0;

            String getID = "SELECT ID FROM [dbo].[diet] WHERE ID_user='" + ID_user + "' AND dateDiet ='" + dateStr + "'";

            using (SqlCommand command = new SqlCommand(getID, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ID = Int16.Parse(reader.GetValue(0).ToString());
                    }
                }
            }
            diet.setID(ID);

            m_diets.Add(diet);

            connection.Close();
        }
    }
}