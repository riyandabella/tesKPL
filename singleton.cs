namespace tesKPL
{
    public class singleton
    {
        private singleton() { }

        private static singleton _instance;

        public static singleton GetInstance() { 

        if (_instance == null)
            {
            _instance = new singleton();
    }
               return _instance;
 }
    }
}
