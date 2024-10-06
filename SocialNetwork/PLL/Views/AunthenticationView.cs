using SocialNetwork.Business_Logic_Layer.Exceptions;
using SocialNetwork.Business_Logic_Layer.Models;
using SocialNetwork.Business_Logic_Layer.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class AunthenticationView
    {
        UserService userService;
        public AunthenticationView(UserService userService)
        {
            this.userService = userService;
        }
        public void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.WriteLine("Введите почтовый адрес:");
            authenticationData.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль:");
            authenticationData.Password = Console.ReadLine();
            try
            {
                var user = this.userService.Authenticate(authenticationData);
                SuccessMessage.Show("Вы успешно вошли в соц сеть");
                SuccessMessage.Show("Добро пожаловать" + " " + user.FirstName);
                Program.userMenuView.Show(user);
            }
            catch(WrongPasswordException)
            {
                AlertMessage.Show("Пароль не коректный");
            }
            catch(UserNotFoundException)
            {
                AlertMessage.Show("пользователь не найден");
            }
        }
    }
}
