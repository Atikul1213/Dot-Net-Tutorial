namespace FirstCoreMVCWebApplication.SOLID.Behaviroal_Design_Pattern.Mediator
{
    public class ConcreteUser : User
    {
        public ConcreteUser(string name) : base(name)
        {

        }
        public override void Receive(string message)
        {
            Console.WriteLine(this.Name + " : Received Message: " + message);
        }
        public override void Send(string message)
        {
            Console.WriteLine(this.Name + ": Sending Message = " + message + "\n");
            Mediator.SendMessage(message, this);
        }
    }
}
