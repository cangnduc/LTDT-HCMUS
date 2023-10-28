class Cau4
{
    private string? filePath;
    public Graph graph;
    public Cau4(string filePath)
    {
        this.filePath = filePath;
        if (this.filePath != null)
        {
            this.graph = new Graph(this.filePath);
        }
        else this.graph = new Graph();
    }
    // Kiểm tra đồ thị có trọng số âm không
    public bool isNegativeWeight()
    {
        for (int i = 0; i < this.graph.numVertices; i++)
        {
            for (int j = 0; j < this.graph.numVertices; j++)
            {
                if (graph.adjacencyMatrix[i, j] < 0)
                {
                    return true;
                }
            }
        }
        return false;
    }
    // Tìm đường đi ngắn nhất từ đỉnh đầu tiên đến tất cả các đỉnh destination, nếu có trọng số âm thì không thể tìm được
    // Dùng biến Pre để lưu đỉnh trước đỉnh hiện tại


    public void Dijkstra(int start, int end)
    {
        int V = graph.numVertices;
        int[] distance = new int[V];
        bool[] visited = new bool[V];

        for (int i = 0; i < V; i++)
        {
            distance[i] = int.MaxValue;
            visited[i] = false;
        }

        distance[start] = 0;

        for (int i = 0; i < V - 1; i++)
        {
            int u = MinDistance(distance, visited);
            visited[u] = true;

            for (int v = 0; v < V; v++)
            {
                if (!visited[v] && graph.adjacencyMatrix[u, v] != 0 && distance[u] != int.MaxValue &&
                    distance[u] + graph.adjacencyMatrix[u, v] < distance[v])
                {
                    distance[v] = distance[u] + graph.adjacencyMatrix[u, v];
                }
            }
        }

        PrintPath(start, end, distance);
    }
    private void PrintPath(int start, int end, int[] distance)
    {
        Console.WriteLine("Đường đi ngắn nhất từ " + start + " đến " + end + ":");
        Console.WriteLine("Đường đi: " + start);

        int current = end;
        while (current != start)
        {
            for (int v = 0; v < graph.numVertices; v++)
            {
                if (distance[current] == distance[start] - graph.adjacencyMatrix[start, current] &&
                    graph.adjacencyMatrix[current, v] != 0)
                {
                    Console.Write(" -> " + current);
                    current = v;
                    break;
                }
            }
        }

        Console.WriteLine(" -> " + end);
        Console.WriteLine("Chi phí: " + distance[end]);
    }
    private int MinDistance(int[] distance, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < graph.numVertices; v++)
        {
            if (!visited[v] && distance[v] <= min)
            {
                min = distance[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

}
