using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = new PizzaBase();
            Console.WriteLine(pizza.GetName());
            pizza = new ChickenTopping(pizza);

            pizza = new OnionTopping(pizza);
            Console.WriteLine(pizza.GetName());
        }
    }
}
