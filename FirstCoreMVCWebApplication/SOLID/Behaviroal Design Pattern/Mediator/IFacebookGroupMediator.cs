namespace FirstCoreMVCWebApplication.SOLID.Behaviroal_Design_Pattern.Mediator
{
    public interface IFacebookGroupMediator
    {
        void SendMessage(string msg, User user);
        void RegisterUser(User user);
    }
}
