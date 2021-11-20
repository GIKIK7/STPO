using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;
    public class MessageController
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        List<Message> m_messages = new List<Message>();

        public void getMessagesListFromDatabase()
        {
            m_messages.Clear();
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetMessages = "SELECT * FROM [dbo].[message]";

            SqlCommand cmdGetMessages = new SqlCommand(strGetMessages, connection);
            SqlDataReader readerGetMessages = cmdGetMessages.ExecuteReader();

            while (readerGetMessages.Read())
            {
                int messageID = Int16.Parse(readerGetMessages.GetValue(0).ToString());
                int messageIDfrom = Int16.Parse(readerGetMessages.GetValue(1).ToString());
                int messageIDto= Int16.Parse(readerGetMessages.GetValue(2).ToString());
                string meessageContent = readerGetMessages.GetValue(3).ToString();

                Message message = new Message(messageID, messageIDfrom, messageIDto, meessageContent);
                m_messages.Add(message);
            }
            connection.Close();
        }

        public void addMessage(int IDfrom, int IDto, string content)
        {

            Message message = new Message(IDfrom, IDto, content);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;

            String insertStr = "INSERT INTO [dbo].[message] (ID_user_from, ID_user_to, Content) VALUES ('" + IDfrom + "','" + IDto + "','" + content + "')";

            using (cmd = new SqlCommand(insertStr, connection))
            {
                cmd.ExecuteReader();
            }

            connection.Close();


            connection.Open();

            int messageID = 0;

            String getMessageID = "SELECT ID FROM [dbo].[message] WHERE Content='" + content + "' AND ID_user_from ='" + IDfrom + "' AND ID_user_to ='" + IDto + "'";

            using (SqlCommand command = new SqlCommand(getMessageID, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        messageID = Int16.Parse(reader.GetValue(0).ToString());
                    }
                }
            }
            message.setID(messageID);

            m_messages.Add(message);

            connection.Close();
        }

        public List<Message> getMessageList()
        {
            return m_messages;
        }
    
        public List<Message> getConversation(int IDfrom, int IDto)
        {
            List<Message> conversation = new List<Message>();
            foreach (Message message in m_messages)
            {
                //We want ALL Messages in conversation between two Users
                if (message.ID_to() == IDto || message.ID_from() == IDfrom || message.ID_to() == IDfrom || message.ID_from() == IDto)
                {
                    conversation.Add(message);
                }
            }
            return conversation;
        }
    }
}