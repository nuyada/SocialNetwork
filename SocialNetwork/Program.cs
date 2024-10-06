using SocialNetwork.Business_Logic_Layer.Exceptions;
using SocialNetwork.Business_Logic_Layer.Models;
using SocialNetwork.Business_Logic_Layer.Services;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    class Program
    {
        static MessageService messageService;
        static UserService userService;
        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AunthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;
        public static AddingFriendsView addingFriendsView;
        public static FriendsView userFriendView;
        static void Main(string[] args)
        {
            userService = new UserService();
            messageService = new MessageService();

            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AunthenticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(messageService, userService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();
            addingFriendsView = new AddingFriendsView(userService);
            userFriendView = new FriendsView();
            while (true)
            {
                mainView.Show();
            }
        }
    }
}
