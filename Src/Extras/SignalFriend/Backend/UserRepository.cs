//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   EXTRAS 
//   SignalR group notifications
// 

using System.Collections.Generic;
using System.Linq;
using SignalFriend.Backend.Model;

namespace SignalFriend.Backend
{
    public class UserRepository
    {
        private static IList<User> _users;
        private static IList<FriendRelationship> _friends; 

        public static IList<User> Users()
        {
            if (_users != null)
                return _users;

            _users = new List<User>
            {
                new User("dino", "dino", 32, "Rome"),
                new User("bob", "bob", 45, "New York"),
                new User("alice", "alice", 29, "Boston"),
                new User("john", "john", 41, "London"),
                new User("mary", "mary", 50, "Melbourne")
            };
            return _users;
        }

        public static IList<FriendRelationship> FriendRelationships()
        {
            if (_friends != null)
                return _friends;

            _friends = new List<FriendRelationship>
            {
                new FriendRelationship("dino", "alice"),
                new FriendRelationship("mary", "dino")
            };
            return _friends;
        }

        public static void RemoveFriend(string friend1, string friend2)
        {
            var list = FriendRelationships();
            var friendToRemove = list.Single(
                f => f.UserName1 == friend1 && f.UserName2 == friend2 ||
                     f.UserName1 == friend2 && f.UserName2 == friend1);
            list.Remove(friendToRemove);
        }

        public static void AddFriend(string friend1, string friend2)
        {
            // Check both are users (create if not)
            var u1 = Users().SingleOrDefault(u => u.UserName == friend1);
            if (u1 == null)
            {
                u1 = new User(friend1, friend1, 0, "");     
                Users().Add(u1);
            }
            var u2 = Users().SingleOrDefault(u => u.UserName == friend2);
            if (u2 == null)
            {
                u2 = new User(friend2, friend2, 0, "");
                Users().Add(u2);
            }

            var friend = new FriendRelationship(friend1, friend2);
            FriendRelationships().Add(friend);
        }

        public static IList<User> FriendsOf(string user)
        {
            var relationships = (from f in UserRepository.FriendRelationships()
                where f.UserName1 == user || f.UserName2 == user
                                 select f).ToList();
            var users = new List<User>();
            foreach (var r in relationships)
            {
                var friendName = (r.UserName1 == user
                    ? r.UserName2
                    : r.UserName1);
                var found = (from u in UserRepository.Users() where u.UserName == friendName select u)
                    .SingleOrDefault();
                if (user != null)
                    users.Add(found);
            }
            return users;
        }
    }
}