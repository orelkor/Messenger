using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace Messenger.Core.Concrete
{
    public static class Authorization
    {
        public static string AppId = "5097957";
        public static string Scope = "friends,messages"; // друзья и сообщения
        
        public static string token;
        public static string id;
        public static bool IsAuthorized;

        public static string url = "https://oauth.vk.com/authorize?client_id=" + AppId + "&redirect_uri=https://oauth.vk.com/blank.html&display=popup&scope=" + Scope + "&response_type=token&v=5.41";
        
     
    }
}
