using System;
using System.Collections.Generic;

namespace ModelClassLibrary
{
    public class Model
    {
        public string[] PointName =
        {
            "Buenos Aires",
            "New York",
            "Cape Town",
            "Liverpool",
            "Casablanca"
        };

        public Dictionary<string, int> DicNameOfPoints = new Dictionary<string, int>();

        public int[,] NodeWeight = new int[5, 5];

        public int[,] CalculatedNode = new int[5, 5];

        public void InitModel()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    NodeWeight[i, j] = new int();
                    NodeWeight[i, j] = 10000;
                }
            }

            NodeWeight[0, 1] = 6; //	Buenos Aires -> New York = 6 days
            NodeWeight[0, 2] = 4; //	Buenos Aires -> Cape Town = 4 days
            NodeWeight[0, 4] = 5; //	Buenos Aires -> Casablanca = 5 days
            NodeWeight[1, 3] = 4; //	New York -> Liverpool = 4 days
            NodeWeight[2, 1] = 8; //	Cape Town -> New York = 8 days
            NodeWeight[3, 2] = 6; //	Liverpool -> Cape Town = 6 days
            NodeWeight[3, 4] = 3; //	Liverpool -> Casablanca = 3 days
            NodeWeight[4, 3] = 3; //	Casablanca -> Liverpool = 3 days
            NodeWeight[4, 2] = 6; //	Casablanca -> Cape Town = 6 days

            for (int i = 0; i < PointName.Length; i++)
            {
                DicNameOfPoints.Add(PointName[i], i);
            }
        }

        public void CalculateNode()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    CalculatedNode[i, j] = NodeWeight[i, j];
                }
            }

            for (int i = 1; i < CalculatedNode.GetLength(0) + 1; i++)
            {
                for (int j = 0; j < CalculatedNode.GetLength(0) - 1; j++)
                {
                    for (int k = 0; k < CalculatedNode.GetLength(0) - 1; k++)
                    {
                        if (CalculatedNode[j, k] > CalculatedNode[j, i - 1] + CalculatedNode[i - 1, k])
                        {
                            CalculatedNode[j, k] = CalculatedNode[j, i - 1] + CalculatedNode[i - 1, k];
                        }
                    }
                }
            }
        }

        public void ShowMatrix(int[,] matrixToShow)
        {
            for (int i = 0; i < matrixToShow.GetLength(0); i++)
            {
                for (int j = 0; j < matrixToShow.GetLength(0); j++)
                {
                    Console.Write(matrixToShow[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        public int ShowTotalJourneyTime(params string[] values)
        {
            var totalJourneyTime = new int();
            totalJourneyTime = 0;

            Console.Write("Total journey time ");

            for (int i = 0; i < values.Length - 1; i++)
            {
                Console.Write(values[i] + " -> ");
            }
            Console.Write(values[values.Length - 1] + " is ");

            //Calculate the total journey time

            for (int i = 1; i < values.Length; i++)
            {
                totalJourneyTime += NodeWeight[DicNameOfPoints[values[i - 1]], DicNameOfPoints[values[i]]];

                if (totalJourneyTime > 10000)
                {
                    Console.WriteLine("Error! The route is missed");
                    totalJourneyTime = -1;
                    break;
                }
            }

            Console.Write(totalJourneyTime+".");
            return totalJourneyTime;
        }

        public int ShowShortJourneyTime(params string[] values)
        {
            var totalShortJourneyTime = new int();
            totalShortJourneyTime = 0;

            Console.Write("Total short journey time of journey: ");

            for (int i = 0; i < values.Length - 1; i++)
            {
                Console.Write(values[i] + " -> ");
            }
            Console.Write(values[values.Length - 1] + " is ");

            //Calculate the short total journey time

            for (int i = 1; i < values.Length; i++)
            {
                totalShortJourneyTime += CalculatedNode[DicNameOfPoints[values[i - 1]], DicNameOfPoints[values[i]]];

                if (totalShortJourneyTime > 10000)
                {
                    Console.WriteLine("Error! The route is missed");
                    totalShortJourneyTime = -1;
                    break;
                }
            }

            Console.WriteLine(totalShortJourneyTime + ".");
            return totalShortJourneyTime;
        }

    }
}