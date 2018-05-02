using System;

namespace SingletonDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger log = Logger.Instance;
            log.Print();
        }
    }
}
