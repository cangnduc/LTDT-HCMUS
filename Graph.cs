using System;
using System.IO;
using System.Linq;

class Graph
{
    private int numVertices;
    private int[,] adjacencyMatrix = new int[0,0 ];
  


    

    public void AddEdge(int source, int destination, int weight)
    {
        adjacencyMatrix[source, destination] = weight;
    }

    public int GetWeight(int source, int destination)
    {
        return adjacencyMatrix[source, destination];
    }

    public void PrintAdjacencyMatrix()
    {
        for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
            {
                Console.Write(adjacencyMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    public void ReadFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        this.numVertices = int.Parse(lines[0]);
        this.adjacencyMatrix = new int[numVertices, numVertices];
        for (int i = 1; i < lines.Length; i++)
        {
            //string[] tokens = lines[i+1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] tokens = lines[i].Split(" ");
           
            for (int j = 0; j < tokens.Length/2 ; j++)
            {
                
                AddEdge(i-1, int.Parse(tokens[2*j+1]), int.Parse(tokens[2*j + 2]));
            }      
        }
        
        
    }
   
   
}