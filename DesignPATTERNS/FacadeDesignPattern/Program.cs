using System;

namespace FacadeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade test = new Facade();

            test.MethodOne();
            test.MethodTwo();
        }
    }
}
