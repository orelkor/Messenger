using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Messenger.Core.Abstracts;
using Messenger.Core.Concrete;
using Microsoft.Practices.ServiceLocation;

namespace Messenger.ViewModel
{
   
    public class ViewModelLocator
    {
        private readonly IFriendsManager _friendsManager;
        

        public ViewModelLocator()
        {
            _friendsManager = new ConcreteFriendsManager();
            
        }

        public FriendsViewModel Friends
        {
            get
            {
                return new FriendsViewModel(_friendsManager);
            }
        }

        public static void Cleanup()
        {
           
        }
    }
}