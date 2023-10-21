namespace LTDT_Project
{
    class Program
    {
        static void Main(string[] args)
        {
        //Load Adjacency Matrix from file
        Graph graph = new Graph();
        graph.ReadFile("graph.txt");
        graph.PrintAdjacencyMatrix();
    }}
}