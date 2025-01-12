namespace FirstCoreMVCWebApplication.SOLID.Creational_Design_Pattern.Singleton
{
    public class Logger
    {
        private const string FILE_PATH = "C:\\log.txt";
        private static Logger _logger;
        private Logger()
        {

        }
        public static Logger GetLogger()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }
            return _logger;
        }

        public void WriteLog(string message)
        {
            lock (this)
            {
                File.WriteAllTextAsync(FILE_PATH, message);
            }
        }
    }
}

// Logger logger = Logger.GetLogger();