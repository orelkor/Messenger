using Messenger.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Abstracts
{
    public interface IFriendsManager
    {
        IEnumerable<Friend> GetFriends();
        string SendMessage(string id,string message, ref List<Chat> listChat);
        IEnumerable<Message> GetMessages();
        Chat GetCurrentChat(string id, ref List<Chat> listChat);
        IEnumerable<Chat> GetAllChat(IEnumerable<Friend> friends, ref List<Chat> listChat);
        void SetMessagesInChat(IEnumerable<Message> listMessages, ref List<Chat> listChat);
        bool IsDoubleMessage(IEnumerable<Message> listMessages, string Id);
        void SaveHistory(Chat chat);

    }
}
