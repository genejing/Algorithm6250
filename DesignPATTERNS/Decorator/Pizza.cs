

public abstract class Pizza
{
    public abstract string GetName();
    public abstract int GetPrice();

}


public class PizzaBase : Pizza
{
    private int price = 10;
    private string name = " Pizza Base";

    public override int GetPrice()
    {

        return price;

    }

    public override string GetName()
    {
        return name;
    }
}


public class DecoratorClass : Pizza
{
    protected Pizza pizza = null;
    protected int price = 0;
    protected string name = "Decorator";

    protected DecoratorClass(Pizza pizza)
    {

        this.pizza = pizza;
    }

    public override int GetPrice()
    {

        return price + pizza.GetPrice();
    }

    public override string GetName()
    {

        return string.Format("{0} , {1}", pizza.GetName(), name);
    }
}

public class ChickenTopping : DecoratorClass
{

    public ChickenTopping(Pizza pizza) : base(pizza)
    {
        this.price = 3;
        this.name = "Chicken";

    }
}

public class OnionTopping : DecoratorClass
{

    public OnionTopping(Pizza pizza) : base(pizza)
    {
        this.price = 2;
        this.name = "Onion";

    }
}

public class GreenPepperTopping : DecoratorClass
{

    public GreenPepperTopping(Pizza pizza) : base(pizza)
    {
        this.price = 1;
        this.name = "Green Pepper";

    }
}