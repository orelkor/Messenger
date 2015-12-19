using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Messenger.Core.Abstracts;
using Messenger.Core.Abstracts.Interpreter;
using Messenger.Core.Abstracts.Observer;
using Messenger.Core.Concrete;
using Messenger.Core.Concrete.Intrpreter;
using Messenger.Core.Concrete.Observer;
using Messenger.Core.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Data;
using System.Windows.Input;

namespace Messenger.ViewModel
{

    public class FriendsViewModel : ViewModelBase, IDataErrorInfo // MainViewModel
    {

        private readonly IFriendsManager _friendsManager;
        private Timer _timer;
        IExpression _expression;
        List<Chat> listChat;

        public FriendsViewModel(IFriendsManager friendsManager)
        {
            if (friendsManager == null) throw new ArgumentNullException("friendsManager");
            _friendsManager = friendsManager;
            listChat = new List<Chat>();
            _friendsManager.GetAllChat(friends, ref listChat);
            _timer = new Timer(4000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _friendsManager.SetMessagesInChat(_friendsManager.GetMessages(), ref listChat);
            RaisePropertyChanged("CurrentChat");
        }

        public ObservableCollection<Friend> friends
        {
            get
            {
                if (Authorization.IsAuthorized = true && _friendsManager != null)
                    return new ObservableCollection<Friend>(_friendsManager.GetFriends());
                else return null;

            }
        }

        private ObservableCollection<Message> _currentChat;
        public ObservableCollection<Message> CurrentChat
        {
            get
            {
                if (Authorization.IsAuthorized = true && _friendsManager != null && _selectedFriend != null)
                {
                    _currentChat = new ObservableCollection<Message>(_friendsManager.GetCurrentChat(_selectedFriend.Id, ref listChat));
                }
                return _currentChat;
            }

            set { _currentChat = value; RaisePropertyChanged("CurrentChat"); }
        }

        private string _message;
        public string Message
        {

            get { return _message; }
            set
            {
                _expression = new SmileExpression(value);
                _message = _expression.Interpret(new SmileContext());

            }

        }

        private Friend _selectedFriend;
        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set { _selectedFriend = value; RaisePropertyChanged("SelectedFriend"); RaisePropertyChanged("CurrentChat"); }
        }


        private RelayCommand _sendMessage;
        public ICommand SendMessage
        {
            get
            {
                if (_sendMessage == null) _sendMessage = new RelayCommand(SendIM, ModelIsValid);
                return _sendMessage;
            }
        }

        private void SendIM()
        {
            if (_message != null && _selectedFriend != null)
            {
                _friendsManager.SendMessage(_selectedFriend.Id, _message, ref listChat);
                _message = null;
                RaisePropertyChanged("Message");
                RaisePropertyChanged("CurrentChat");
            }

        }

        private RelayCommand _save;
        public ICommand Save
        {
            get
            {
                if (_save == null) _save = new RelayCommand(SaveToWord, ModelIsValid);
                return _save;
            }
        }

        private void SaveToWord()
        {
            Chat chat = new Chat();
            chat.UserInConversationId = _currentChat[0].User_id;
            foreach (var item in _currentChat)
            {
                chat.Add(item);
            }
            if (chat != null)
            {
                _friendsManager.SaveHistory(chat);
            }
        }

        private bool ModelIsValid()
        {
            return true;

        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Message" && string.IsNullOrEmpty(Message)) return "Set message";

                return null;
            }
        }

    }
}