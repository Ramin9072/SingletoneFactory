namespace SingletoneFactory.ChocolateFactory
{
    public class ChocolateBoiler
    {
        private static ChocolateBoiler _uniqueInstance;

        public static ChocolateBoiler Instance
        {
            get
            {
                if (_uniqueInstance == null)
                {
                    Console.WriteLine("Creating unique instance of Chocolate Boiler");
                    _uniqueInstance = new ChocolateBoiler();
                }

                Console.WriteLine("Returning instance of Chocolate Boiler");
                return _uniqueInstance;
            }
        }

        public ChocolateBoiler()
        {
            Empty = true;
            Boiler = false;
        }

        public void Fill() {
            if (IsEmpty())
            {
                Empty = false;
                Boiler= false;
            }
        }

        public void Drain() {
            if (!IsEmpty() && IsBoiled())
            {
                Empty= true;

            }
        }

        public bool IsEmpty() => Empty;
        public bool IsBoiled() => Boiler;

        public bool Empty { get; set; }
        public bool Boiler { get; set; }

    }
}
