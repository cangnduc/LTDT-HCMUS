using System;
namespace LTDT_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cau1 cau1 = new Cau1("Graph/cau1-1.txt");
            //cau1.showGraph();
            showGraph();
        }
        public static void showGraph()
        {
            Graph graph = new Graph("Graph/cau1-1.txt");
            graph.PrintAdjacencyMatrix();
            if (graph.isUndirected())
            {
                Console.WriteLine("Do thi vo huong");
            }
            else
            {
                Console.WriteLine("Do thi co huong");
            }
            Console.WriteLine("So dinh cua do thi: " + graph.GetNumVertices());
            Console.WriteLine("So canh cua do thi: " + graph.GetNumEdges());
            graph.PrintVertex();
        }
    }
}