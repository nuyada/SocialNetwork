using SocialNetwork.Business_Logic_Layer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Business_Logic_Layer.Models;
using SocialNetwork.Business_Logic_Layer.Exceptions;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    public class AddingFriendsView
    {
        UserService userService;
        public AddingFriendsView(UserService userService)
        {
            this.userService = userService;
        }
        public void Show(User user)
        {
            try
            {
                UserAddindFriendsData userAddindFriendsData = new UserAddindFriendsData();
                Console.WriteLine("Введите почтовый для добавления в друзья");
                userAddindFriendsData.Email = Console.ReadLine();
                userAddindFriendsData.UserId = user.Id;
                userService.AddFriends(userAddindFriendsData);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден");
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении в друзья");
            }
        }
    }
}
