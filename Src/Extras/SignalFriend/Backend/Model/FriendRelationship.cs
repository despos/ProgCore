//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR group notifications
// 

namespace SignalFriend.Backend.Model
{
    public class FriendRelationship
    {
        public FriendRelationship(string friend1, string friend2)
        {
            UserName1 = friend1;
            UserName2 = friend2;
        }
        public string UserName1 { get; set; }
        public string UserName2 { get; set; }
    }
}