using Messenger.Core.Abstracts;
using Messenger.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Core.Concrete;
using HtmlAgilityPack;
using Novacode;
using System.Collections.ObjectModel;

namespace Messenger.Core.Concrete
{
    public class ConcreteFriendsManager : IFriendsManager
    {
       
        ChatDirector director = new ChatDirector();


        public IEnumerable<Chat> GetAllChat(IEnumerable<Friend> friends, ref List<Chat> listChat)
        {
            foreach (var item in friends)
            {
                listChat.Add(director.BuildChat(new ConcreteChatBuilder(item.Id)));
            }

            return listChat;
        }

        public Chat GetCurrentChat(string idChat, ref List<Chat> listChat)
        {
            Chat result = null;
            foreach (var item in listChat)
            {
                if (idChat == item.UserInConversationId)
                {
                    result = item;
                    break;
                }

            }

            return result;
        }

        public IEnumerable<Friend> GetFriends()
        {
            List<Friend> result = new List<Friend>();
            string methodName = "friends.get.xml";
            string resp = HttpRequests.GET_http("https://api.vk.com/method/" + methodName + "?" + "user_id" + "=" + Authorization.id + "&fields=domain" + "&access_token=" + Authorization.token + "");

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(resp);
            HtmlNodeCollection IdNode = doc.DocumentNode.SelectNodes("//user_id");
            HtmlNodeCollection LastNameNode = doc.DocumentNode.SelectNodes("//last_name");
            if (IdNode.Count == LastNameNode.Count)
            {

                for (int i = 0; i < IdNode.Count; i++)
                {
                    result.Add(new Friend(LastNameNode[i].InnerHtml, IdNode[i].InnerHtml));
                }
            }
            return result;
        }


        public string SendMessage(string IdFriend, string message, ref List<Chat> listChat)
        {
            string methodName = "messages.send.xml";
            string resp = HttpRequests.POST_http("https://api.vk.com/method/" + methodName + "?" + "user_id" + "=" + IdFriend + "&message=" + message + "&access_token=" + Authorization.token + "", message);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(resp);
            HtmlNodeCollection Node = doc.DocumentNode.SelectNodes("//response");
            var idMessage = Node[0].InnerHtml.ToString();
            foreach (var item in listChat)
            {
                if (IdFriend == item.UserInConversationId)
                {
                    item.Add(new Message(idMessage, message, IdFriend, true));
                    break;
                }
            }
            
            return idMessage;
        }

        public void SetMessagesInChat(IEnumerable<Message> listMessagesComing, ref List<Chat> listChat)
        {
            foreach (Message item in listMessagesComing)
            {
                for (int i = 0; i < listChat.Count; i++)
                {
                    if (item.User_id == listChat[i].UserInConversationId.ToString())
                    {
                        if(IsDoubleMessage(listChat[i], item.Id))
                        listChat[i].Add(new Message(item.Id, item.Body, item.User_id, item.IsSendedMessage));
                    }
                }
            }
        }

        public bool IsDoubleMessage(IEnumerable<Message> listMessages, string Id)
        {
            int IsFalse = 0;
            foreach(var item in listMessages)
            {
                if (item.Id == Id)
                {
                    IsFalse++;
                    break;
                }

            }
            if (IsFalse == 0) return true;
            else return false;
        }


        IEnumerable<Message> IFriendsManager.GetMessages()
        {
            List<Message> result = new List<Message>();
            string methodName = "messages.get.xml";
            string count = "10"; // число получаемых сообщений
            string time_offset = "5"; //макс.время с момента получения сообщения
            string resp = HttpRequests.GET_http("https://api.vk.com/method/" + methodName + "?" + "count" + "=" + count + "&time_offset" + time_offset + "&access_token=" + Authorization.token + "");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(resp);
            HtmlNodeCollection IdMessageNode = doc.DocumentNode.SelectNodes("//mid");
            HtmlNodeCollection TextNode = doc.DocumentNode.SelectNodes("//body");
            HtmlNodeCollection SenderIdNode = doc.DocumentNode.SelectNodes("//uid");
            HtmlNodeCollection IsSentNode = doc.DocumentNode.SelectNodes("//out");
            List<bool> IsSentNodeBool = new List<bool>();

            foreach (var item in IsSentNode)
            {
                if (item.InnerHtml.ToString() == "1") IsSentNodeBool.Add(true);
                else IsSentNodeBool.Add(false);
            }

                for (int i = 0; i < IdMessageNode.Count; i++)
                {
                    result.Add(new Message(IdMessageNode[i].InnerHtml, TextNode[i].InnerHtml, SenderIdNode[i].InnerHtml, IsSentNodeBool[i]));
                }
            
            return result;
        }

        public void SaveHistory(Chat chat)
        {
            using (DocX document = DocX.Create(String.Format("{0}.docx", chat.UserInConversationId)))
            {
                Paragraph p1 = document.InsertParagraph();
                foreach (var item in chat)
                {
                    p1.AppendLine(item.ToString());
                }

                document.Save();
            }
        }
    }
}
