using SocialNetwork.Business_Logic_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class FriendsView
    {
        public void Show(IEnumerable<User> friends)
        {
            Console.WriteLine("Друзья");
            if(friends.Count() == 0)
            {
                Console.WriteLine("У вас нет друзей");
                return;
            }
            foreach(var friend in friends.ToList())
            {
                Console.WriteLine("Почтовый адрес друга: {0}. Имя друга: {1}. Фамилия друга: {2}", friend.Email, friend.FirstName, friend.LastName);
            }
        }
    }
}
