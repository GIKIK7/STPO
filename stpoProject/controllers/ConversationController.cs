using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace stpoProject.controllers
{
    using datasets;
    public class ConversationController
    {
        List<Conversation> m_conversations = new List<Conversation>();

        public void createConversations(int IDuser, List<Message> messages)
        {
            m_conversations.Clear();

            foreach (Message message in messages)
            {
                Conversation conversation = new Conversation(message.ID_to(), message.ID_from());

                if (m_conversations.Count > 0)
                {
                    for(int i=0; i<m_conversations.Count(); i++)
                    {
                        if ( (conversation.IDto() == m_conversations[i].IDto() && conversation.IDfrom() == m_conversations[i].IDfrom()) 
                                || (conversation.IDto() == m_conversations[i].IDfrom() && conversation.IDfrom() == m_conversations[i].IDto()))
                        {
                            
                        }
                        else
                        {
                            m_conversations.Add(conversation);
                        }
                    }
                }
                else
                {
                    m_conversations.Add(conversation);
                }
                
            }
        }

        public string printConversations()
        {
            string str = "";
            foreach (Conversation conversation in m_conversations)
            {
                str += "konwersacja z: " + conversation.IDto().ToString() + " " + conversation.IDfrom().ToString();
            }
            return str;
        }
    }
}