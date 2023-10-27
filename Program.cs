using System;
using System.Collections.Generic;
namespace LTDT_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            Cau5 cau5 = new Cau5("graph/cau1-2.txt");
            Cau1 cau1 = new Cau1("graph/cau1-2.txt");
            cau1.showGraph();
            cau5.ShowEluer();
            //Cau2 cau2 = new Cau2("adjacencyMatrix/cau1-1.txt");
            //Console.WriteLine(cau2.g.GetNumEdges());


        }

    }
}