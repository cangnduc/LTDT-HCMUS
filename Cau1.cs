using System;
class Cau1
{
    public string? filePath;
    public Graph? graph;
    public Cau1(string? filePath)
    {
        this.filePath = filePath;
        if (this.filePath != null)
        {
            this.graph = new Graph(this.filePath);
        }
        else this.graph = new Graph();
    }
    public void showGraph()
    {
        if (this.graph != null)
        {
            this.graph.PrintAdjacencyMatrix();
            Console.WriteLine("So dinh: " + this.graph.GetNumVertices());

        }
    }
}