
using System;
class SubsystemOne{
    public void MethodOne(){

        Console.WriteLine(" I am in function one");
    }
}

class SubsystemTwo{
    public void MethodTwo(){

        Console.WriteLine(" I am in function Two");
    }
}
class SubsystemThree{
    public void MethodThree(){

        Console.WriteLine(" I am in function Three");
    }
}

class Facade{

    private SubsystemOne subsystemOne;
    private SubsystemTwo subsystemTwo;
    private SubsystemThree subsystemThree;

    public Facade(){

        subsystemOne = new SubsystemOne();
        subsystemTwo = new SubsystemTwo();
        subsystemThree = new SubsystemThree();
        
    }

    public void MethodOne(){
        Console.WriteLine("Facade Method one");
        subsystemOne.MethodOne();
        subsystemThree.MethodThree();

    }

    public void MethodTwo(){
        Console.WriteLine("Facade Method Two");
        subsystemTwo.MethodTwo();

    }
}