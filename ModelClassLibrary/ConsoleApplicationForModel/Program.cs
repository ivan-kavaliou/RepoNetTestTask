using ModelClassLibrary;
using System;

namespace ConsoleApplicationForModel
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello Model");

            Model newModel = new Model();

            newModel.InitModel();

            newModel.ShowMatrix(newModel.NodeWeight);

            Console.WriteLine("\n Let's do some calculationt with matrix \n");

            newModel.CalculateNode();

            Console.WriteLine("NodeWeight");
            newModel.ShowMatrix(newModel.NodeWeight);
            Console.WriteLine("CalculatedNode");
            newModel.ShowMatrix(newModel.CalculatedNode);

            newModel.ShowTotalJourneyTime(new string[] {"Buenos Aires","New York","Liverpool",});
            Console.WriteLine("\n");
            newModel.ShowTotalJourneyTime(new string[] { "Buenos Aires","Casablanca","Liverpool"});
            Console.WriteLine("\n");
            newModel.ShowTotalJourneyTime(new string[] { "Buenos Aires", "Cape Town", "New York", "Liverpool", "Casablanca" });
            Console.WriteLine("\n");
            newModel.ShowTotalJourneyTime(new string[] { "Buenos Aires",  "Cape Town",  "Casablanca" });


            Console.ReadLine();
        }
    }
}