using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;
    public class CommentController
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        List<Comment> m_comments = new List<Comment>();

        public void getCommentsFromDatabase()
        {
            m_comments.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetData = "SELECT * FROM [dbo].[comments]";

            SqlCommand cmdGetData = new SqlCommand(strGetData, connection);
            SqlDataReader readerGetData = cmdGetData.ExecuteReader();

            while (readerGetData.Read())
            {
                int ID = Int16.Parse(readerGetData.GetValue(0).ToString());
                int ID_Client= Int16.Parse(readerGetData.GetValue(1).ToString());
                int ID_Coach = Int16.Parse(readerGetData.GetValue(2).ToString());
                string content = readerGetData.GetValue(3).ToString();

                Comment comment = new Comment(ID, ID_Client, ID_Coach, content);
                m_comments.Add(comment);
            }
            connection.Close();
        }

        public void addComment(int ID_Client, int ID_Coach, string content)
        {
            Comment comment = new Comment(ID_Client, ID_Coach, content);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;

            String insertStr = "INSERT INTO [dbo].[comments] (ID_userClient, ID_userCoach, Content) VALUES ('" + ID_Client + "','" + ID_Coach + "','" + content + "')";

            using (cmd = new SqlCommand(insertStr, connection))
            {
                cmd.ExecuteReader();
            }

            connection.Close();


            connection.Open();

            int commentID = 0;

            String getMessageID = "SELECT ID FROM [dbo].[comments] WHERE Content='" + content + "' AND ID_userClient ='" + ID_Client + "' AND ID_userCoach ='" + ID_Coach + "'";

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
            comment.setID(commentID);

            m_comments.Add(comment);

            connection.Close();
        }

        public List<Comment> getCommentsOfCoach(int ID_userCoach)
        {
            List<Comment> comments = new List<Comment>();
            foreach (Comment comment in m_comments)
            {
                if (comment.ID_coach() == ID_userCoach)
                {
                    comments.Add(comment);
                }
            }
            return comments;
        }
    
        public void deleteComment(int ID_userClient, int ID_userCoach, string content)
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;

            String deleteStr = "DELETE [dbo].[comments] WHERE Content='" + content + "' AND ID_userClient ='" + ID_userClient + "' AND ID_userCoach ='" + ID_userCoach + "'";

            cmd = new SqlCommand(deleteStr, connection);

            cmd.ExecuteReader();

            connection.Close();

            foreach (Comment com in m_comments.ToList())
            {
                if (com.ID_client() == ID_userClient && com.ID_coach() == ID_userCoach && com.content() == content)
                {
                    m_comments.Remove(com);
                }
            }

        }
    }
}