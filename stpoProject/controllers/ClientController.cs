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
        private List<Client> m_clients = new List<Client>();
        public void getClientListFromDatabase()
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

    }
}