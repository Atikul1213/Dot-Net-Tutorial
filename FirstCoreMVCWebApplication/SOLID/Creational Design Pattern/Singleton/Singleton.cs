namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Singleton
{
    public sealed class Singleton
    {
        private static volatile Singleton instance;
        private static readonly object lockObject = new object();
        private string data;

        private Singleton(string data)
        {
            this.data = data;
        }

        public static Singleton getInsatance(string data)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Singleton(data);
                }
                return instance;
            }
        }
    }
}
