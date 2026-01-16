namespace Gym_Manager_System
{
    public class MainClass
    {
        private static MainClass? _instance;
        private static readonly object _lock = new object();

        // Private constructor to prevent instantiation
        private MainClass()
        {
        }

        // Public static property to get the single instance
        public static MainClass Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MainClass();
                        }
                    }
                }
                return _instance;
            }
        }

        
        public void Initialize()
        {
           
        }

        public void Run()
        {
            
        }

        public void Shutdown()
        {
            
        }
    }
}

