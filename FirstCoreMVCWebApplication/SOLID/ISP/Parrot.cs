namespace FirstCoreMVCWebApplication.SOLID.ISP
{
    public class Parrot : Animal, IFlyable
    {
        public override void Eat()
        {
            throw new NotImplementedException();
        }

        public void Flya()
        {
            throw new NotImplementedException();
        }

        public override void Life()
        {
            throw new NotImplementedException();
        }

        public override void Sleep()
        {
            throw new NotImplementedException();
        }
    }
}
