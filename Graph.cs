using System;
using System.IO;
using System.Linq;

class Graph
{

    private int numVertices;
    private int[,] adjacencyMatrix = new int[0, 0];
    // Khởi tạo ma trận kề
    public Graph(string filename)
    {
        this.numVertices = 0;
        this.adjacencyMatrix = new int[0, 0];
        ReadFile(filename);
    }
    public Graph()
    {
        this.numVertices = 0;
        this.adjacencyMatrix = new int[0, 0];
    }
    // Thêm cạnh từ đỉnh source đến đỉnh destination với trọng số weight
    public void AddEdge(int source, int destination, int weight)
    {
        if (adjacencyMatrix[source, destination] == 0)
        {
            adjacencyMatrix[source, destination] = weight;
        }
        else
        {
            adjacencyMatrix[source, destination] += weight;
        }


    }
    // Lấy trọng số từ đỉnh source đến đỉnh destination

    public int GetWeight(int source, int destination)
    {
        return adjacencyMatrix[source, destination];
    }
    // In ma trận kề
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
    // Đọc dữ liệu từ file
    public void ReadFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        this.numVertices = int.Parse(lines[0]);
        this.adjacencyMatrix = new int[numVertices, numVertices];
        for (int i = 1; i < lines.Length; i++)
        {
            string[] tokens = lines[i].Split(" ");
            for (int j = 0; j < tokens.Length / 2; j++)
            {
                AddEdge(i - 1, int.Parse(tokens[2 * j + 1]), int.Parse(tokens[2 * j + 2]));
            }
        }
    }
    // Đếm số cạnh
    public int GetNumEdges()
    {

        int count = 0;
        if (isUndirected())
        {
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i, j] != 0)
                    {

                        count += adjacencyMatrix[i, j];
                        if (i == j)
                        {
                            count += adjacencyMatrix[i, j];
                        }

                    }
                }
            }
            return count / 2;
        }


        return count;
    }
    public int[][] countDegrees()
    {
        int[][] degrees = new int[numVertices][];
        if (isUndirected())
        {
            for (int i = 0; i < numVertices; i++)
            {
                int[] count = new int[2];
                for (int j = 0; j < numVertices; j++)
                {
                    if (this.adjacencyMatrix[i, j] != 0)
                    {
                        count[0] += this.adjacencyMatrix[i, j];
                        if (i == j)
                        {
                            count[0] += this.adjacencyMatrix[i, i];
                        }
                    }
                }
                degrees[i] = count;
            }
        }
        else
        {

            for (int i = 0; i < numVertices; i++)
            {

                int[] count = new int[2];
                for (int j = 0; j < numVertices; j++)
                {

                    count[0] += this.adjacencyMatrix[i, j];

                    count[1] += this.adjacencyMatrix[j, i];

                }
                //Console.WriteLine(count[0] + " " + count[1]);
                degrees[i] = count;
            }
        }


        return degrees;
    }
    public void PrintVertex()
    {

        int[][] degrees = this.countDegrees();
        Console.WriteLine("Bac cua Tung Dinh la:");
        for (int i = 0; i < degrees.Length; i++)
        {

            Console.Write($"{i} ({degrees[i][1]}-{degrees[i][0]}), ");
        }
    }
    // Đếm số đỉnh
    public int GetNumVertices()
    {
        return numVertices;
    }

    public bool isUndirected()
    {
        for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
            {
                if (adjacencyMatrix[i, j] != adjacencyMatrix[j, i])
                {
                    return false;
                }
            }
        }
        return true;

    }


}
