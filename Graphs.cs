using System;
using System.Collections.Generic;
using System.Linq;
class Graphs
{
    public int V;
    
    public bool isSimpleGraph = false;
    public bool isUndirected = false;
    // Ma trận kề gôm [V,V] với V là số đỉnh, mỗi phần tử là 1 list chưa trọng số của 1 cạnh nối 2 đỉnh
    public List<int>[,] adjMatrix = new List<int>[0, 0];
    public int numEdges = 0;
    public Graphs(string filePath)
    {
       
        LoadFile2(filePath);
        isUndirected = CheckIsUndirected(); // Kiểm tra đồ thị vô hướng
        numEdges = GetNumEdges(); // Tính số cạnh của đồ thị
        isSimpleGraph = CheckIsSimpleGraph(); // Kiểm tra đơn đồ thị
        
    }
    // Thêm cạnh vào ma trận kề
    public void AddEdge(int u, int v, int w)
    {
        adjMatrix[u, v].Add(w);
    }
    public void RemoveEdge(int u, int v, int w)
    {
        adjMatrix[u, v].Remove(w);
    }
    public void PrintGraph()
    {
        for (int i = 0; i < V; i++)
        {

            for (int j = 0; j < V; j++)
            {
                Console.Write(adjMatrix[i, j].Count + " ");
            }
            Console.WriteLine();
        }
    }
    // Load file text chưa danh sách kề của đồ thị có trọng số
    public void LoadFile2(string filePath)
    {
        try {
            string[] lines = File.ReadAllLines(filePath);
            V = int.Parse(lines[0]);
            adjMatrix = new List<int>[V, V];
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    adjMatrix[i, j] = new List<int>();
                }
            }

            for (int i = 1; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(' ');
                for (int j = 0; j < line.Length / 2; j++)
                {
                    int u = i - 1;
                    int v = int.Parse(line[2 * j + 1]);
                    int w = int.Parse(line[2 * j + 2]);

                    adjMatrix[u, v].Add(w);

                }

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }

    // Kiem tra do thi vo huong, so sanh gia tri dinh qua duong cheo ma tran ke
    public bool CheckIsUndirected()
    {
        bool isUndirected = false;

        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
            {
                isUndirected = adjMatrix[i, j].SequenceEqual(adjMatrix[j, i]);
                if (!isUndirected)
                {
                    return isUndirected;
                }

            }
        }
        return isUndirected;
    }
    // Tính bậc của mỗi đỉnh trong đồ thị vô hướng
    public int[] GetDegree()
    {
        int[] degree = new int[V];
        for (int i = 0; i < V; i++)
        {
            degree[i] = 0;
            for (int j = 0; j < V; j++)
            {
                degree[i] += adjMatrix[i, j].Count;
                if (i == j && adjMatrix[i, j].Count > 0)
                {
                    degree[i] += 1;
                }
            }
        }
        return degree;
    }
    // tính bậc của mỗi đỉnh trong đồ thị có hướng
    public int[,] GetDegreeDirected()
    {
        int[,] degree = new int[V, 2];
        for (int i = 0; i < V; i++)
        {
            degree[i, 0] = 0;
            degree[i, 1] = 0;
            for (int j = 0; j < V; j++)
            {
                degree[i, 0] += adjMatrix[i, j].Count;
                degree[i, 1] += adjMatrix[j, i].Count;
            }
        }
        return degree;
    }
    // Tính số cạnh của đồ thị
    // Đồ thị vô hướng 2e = tổng bậc của các đỉnh
    // Đồ thị có hướng e = tổng bậc vào hoặc ra của các đỉnh
    public int GetNumEdges()
    {
        int numEdges = 0;
        if (isUndirected)
        {
            int[] degree = GetDegree();
            for (int i = 0; i < V; i++)
            {
                numEdges += degree[i];
            }
            numEdges /= 2;
        }
        else
        {
            int[,] degree = GetDegreeDirected();
            for (int i = 0; i < V; i++)
            {
                numEdges += degree[i, 0];
            }
        }
        return numEdges;
    }

    // Kiểm tra có phải đơn đồ thị không ?
    // Đồ thị vô hướng không có cạnh song song
    // Đồ thị có hướng không có cạnh song song và cạnh lặp
    public bool CheckIsSimpleGraph()
    {
        bool isSimpleGraph = true;

        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < V; j++)
            {
                //Console.WriteLine(adjMatrix[i, j].Count);
                if (adjMatrix[i, j].Count > 1)
                {
                    isSimpleGraph = false;
                    break;
                }
            }
        }


        return isSimpleGraph;
    }
    public bool IsConnected()
    {
        bool[] visited = new bool[V];
        for (int i = 0; i < V; i++)
        {
            visited[i] = false;
        }
        DFS(0, visited);
        for (int i = 0; i < V; i++)
        {
            if (!visited[i])
            {
                return false;
            }
        }
        return true;
    }
    public void DFS(int u, bool[] visited)
    {
        visited[u] = true;
        for (int i = 0; i < V; i++)
        {
            if (adjMatrix[u, i].Count > 0 && !visited[i])
            {
                DFS(i, visited);
            }
        }
    }


}