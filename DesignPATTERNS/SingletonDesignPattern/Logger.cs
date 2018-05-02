using System;

class Logger{

    private static Logger instance; // Static instance of the class
    private static int bankBalance ;
    private static object sync = new object(); // Used for synchronization

    private Logger(){} // make constructor as private so no one can create instance

    public void Print(){
        Console.WriteLine("I am printing");
    }
    public static  Logger Instance {
        get{

            if(instance == null){
                    lock(sync){
                    if(instance == null){
                        instance = new Logger();
                    }
                }
            }

            
            return instance;

        }

    }

}