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

            bool isConversationUniq = true;

            foreach (Message message in messages)
            {
                if(message.ID_from() == IDuser || message.ID_to() == IDuser)
                {
                    Conversation conversation = new Conversation(message.ID_to(), message.ID_from());

                    isConversationUniq = true;

                    if (m_conversations.Count > 0)
                    {
                        for (int i = 0; i < m_conversations.Count(); i++)
                        {
                            if ((conversation.IDto() == m_conversations[i].IDto() && conversation.IDfrom() == m_conversations[i].IDfrom())
                                    || (conversation.IDto() == m_conversations[i].IDfrom() && conversation.IDfrom() == m_conversations[i].IDto()))
                            {
                                isConversationUniq = false;
                            }
                        }
                        if (isConversationUniq)
                        {
                            m_conversations.Add(conversation);
                        }
                    }
                    else
                    {
                        m_conversations.Add(conversation);
                    }
                }
            }
        }

        public string printConversations()
        {
            string str = "";
            foreach (Conversation conversation in m_conversations)
            {
                str += "konwersacja z: " + conversation.IDto().ToString() + " " + conversation.IDfrom().ToString() +"  ;";
            }
            return str;
        }

        public List<Conversation> getConversationList()
        {
            return m_conversations;
        }
    }
}