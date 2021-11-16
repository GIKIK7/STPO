using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace stpoProject.controllers
{
    using datasets;

    public class ClientController
    {

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "stpo.database.windows.net",
            UserID = "GIKIK",
            Password = "AdminHaslo137",
            InitialCatalog = "DBstpo"
        };

        private List<Client> m_clients = new List<Client>();


        public void getClientListFromDatabase()
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            String strGetClient = "SELECT * FROM [dbo].[clients]";

            SqlCommand cmdGetClient = new SqlCommand(strGetClient, connection);
            SqlDataReader readerGetClient = cmdGetClient.ExecuteReader();

            while (readerGetClient.Read())
            {
                int clientID = Int16.Parse(readerGetClient.GetValue(0).ToString());
                int clientUserID = Int16.Parse(readerGetClient.GetValue(1).ToString());
                string clientName = readerGetClient.GetValue(2).ToString();
                string clientLastName = readerGetClient.GetValue(3).ToString();

                Client client = new Client(clientID, clientUserID, clientName, clientLastName);
                m_clients.Add(client);
            }
            connection.Close();
        }
    
        public List<Client> getClientList()
        {
            return m_clients;
        }

        public void addClient(int ID_user, string name, string lastName)
        {

            Client client = new Client(ID_user, name, lastName);

            SqlConnection connection = new SqlConnection(builder.ConnectionString);

            connection.Open();

            SqlCommand cmd;

            String insertStr = "INSERT INTO [dbo].[clients] (ID_user, name, last_name) VALUES ('" + ID_user + "','" + name + "','" + lastName + "')";

            cmd = new SqlCommand(insertStr, connection);

            cmd.ExecuteReader();

            connection.Close();


            connection.Open();

            int coachID = 0;

            String getClientID = "SELECT ID FROM [dbo].[coaches] WHERE ID_user='" + ID_user + "'";

            SqlCommand command = new SqlCommand(getClientID, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                coachID = Int16.Parse(reader.GetValue(0).ToString());
            }

            client.setID(coachID);

            m_clients.Add(client);

            connection.Close();
        }

    }
}