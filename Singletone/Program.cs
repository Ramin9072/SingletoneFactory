using System;

internal class Program
{
    private static void Main(string[] args)
    {
        SingletoneSample s1 = new SingletoneSample();
        SingletoneSample s2 = new SingletoneSample();

        if (s1 == s2)
            Console.WriteLine("Objects are the same instance");
        else
            Console.WriteLine("Objects are the not same instance");


        Console.WriteLine("---------------------------------------");

        LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
        LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
        LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
        LoadBalancer b4 = LoadBalancer.GetLoadBalancer();
        
        if (b1 == b2 && b2 == b3 && b3 == b4)
        {
            Console.WriteLine("** Same instance ** ");
        }
        
        LoadBalancer balancer = LoadBalancer.GetLoadBalancer();
        for (int i = 0; i < 15; i++)
        {
            string server = balancer.Server;
            Console.WriteLine("Dispatch Request to: " + server);
        }
        
        Console.ReadKey();


    }
}
public class SingletoneSample
{
    static SingletoneSample? instance;

    public static SingletoneSample Instance()
    {
        if (instance == null)
        {
            instance = new SingletoneSample();
        }
        return instance;
    }
}

public class LoadBalancer
{
    static LoadBalancer? instance;
    List<string> servers = new List<string>();

    Random rand = new Random();

    private static object locker = new object();

    protected LoadBalancer()
    {
        servers.Add("Server1");
        servers.Add("Server2");
        servers.Add("Server3");
        servers.Add("Server4");
        servers.Add("Server5");
    }
    public static LoadBalancer GetLoadBalancer()
    {
        if (instance == null)
        {
            lock (locker)
            {
                if (instance == null)
                {
                    instance = new LoadBalancer();
                }
            }
        }
        return instance;
    }

    public string Server
    {
        get
        {
            int r = rand.Next(servers.Count);
            return servers[r].ToString();
        }
    }

}