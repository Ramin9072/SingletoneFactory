using SingletoneFactory.ChocolateFactory;

internal class Program
{
    private static void Main(string[] args)
    {
        ChocolateBoiler boiler = ChocolateBoiler.Instance;
        boiler.Fill();
        boiler.Drain();

        // will return the existing instance
        ChocolateBoiler boiler2 = ChocolateBoiler.Instance;
        
    }
}