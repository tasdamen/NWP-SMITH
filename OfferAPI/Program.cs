using System;

namespace OfferAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8081/";
            new DefaultActor(uri);
            Console.WriteLine("Offer API is running at " + uri);
            Console.ReadKey();
        }
    }
}
