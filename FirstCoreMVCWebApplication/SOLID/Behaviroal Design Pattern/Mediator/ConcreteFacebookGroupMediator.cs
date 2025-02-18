namespace FirstCoreMVCWebApplication.SOLID.Behaviroal_Design_Pattern.Mediator
{
    public class ConcreteFacebookGroupMediator : IFacebookGroupMediator
    {
        private List<User> UsersList = new List<User>();

        public void RegisterUser(User user)
        {
            UsersList.Add(user);
            user.Mediator = this;
        }

        public void SendMessage(string message, User user)
        {
            foreach (var usr in UsersList)
            {
                if (usr != user)
                {
                    usr.Receive(message);
                }
            }
        }
    }
}
