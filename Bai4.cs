class Bai4
{
    public Graphs g;
    public Bai4(string filePath)
    {
        g = new Graphs(filePath);
    }
    public void ShowBai4()
    {
        Console.WriteLine("Bai 4: ");
        if (isNegativeWeight())
        {
            Console.WriteLine("Do thi co trong so am");
            for (int i = 0; i < g.V; i++)
            {
                BellmanFord(0, i);
                Console.WriteLine("--------------------");
            }
        }
        else
        {
            Console.WriteLine("Do thi khong co trong so am");
            for (int i = 0; i < g.V; i++)
            {
                Dijkstra(0, i);
                Console.WriteLine("--------------------");
            }
        }

    }
    // Kiem tra do thi co trong so Am hay khong
    public bool isNegativeWeight()
    {
        if (g.isUndirected)
        {
            for (int i = 0; i < g.V; i++)
            {
                for (int j = 0; j < g.V; j++)
                {
                    if (g.adjMatrix[i, j].Count > 0)
                    {
                        if (g.adjMatrix[i, j][0] < 0)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < g.V; i++)
            {
                for (int j = 0; j < g.V; j++)
                {
                    if (g.adjMatrix[i, j].Count > 0)
                    {
                        if (g.adjMatrix[i, j][0] < 0)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;

    }
    // Tìm đường đi ngắn nhất từ đỉnh đầu tiên đến tất cả các đỉnh destination, bằng thuật toán Dijkstra
    // Dùng biến Pre để lưu đỉnh trước đỉnh hiện tại
    public void Dijkstra(int start, int end)
    {

        int V = g.V;

        List<int> distance = new List<int>();
        List<bool> visited = new List<bool>();
        List<int> pre = new List<int>();
        for (int i = 0; i < V; i++)
        {
            distance.Add(int.MaxValue);
            visited.Add(false);
            pre.Add(-1);
        }
        distance[start] = 0;
        for (int i = 0; i < V - 1; i++)
        {
            int u = MinDistance(distance, visited);
            visited[u] = true;
            for (int v = 0; v < V; v++)
            {
                if (!visited[v] && g.adjMatrix[u, v].Count > 0 && distance[u] != int.MaxValue &&
                    distance[u] + g.adjMatrix[u, v][0] < distance[v])
                {
                    distance[v] = distance[u] + g.adjMatrix[u, v][0];
                    pre[v] = u;
                }
            }
        }
        PrintPath(start, end, distance, pre);
    }
    private int MinDistance(List<int> distance, List<bool> visited)
    {
        int min = int.MaxValue;
        int min_index = -1;
        for (int v = 0; v < g.V; v++)
        {
            if (visited[v] == false && distance[v] <= min)
            {
                min = distance[v];
                min_index = v;
            }
        }
        return min_index;
    }
    // In ra đường đi từ đỉnh bắt đầu đến đỉnh kết thúc
    // Nếu không có đường đi, in ra thông báo không có đường đi
    private void PrintPath(int start, int end, List<int> distance, List<int> pre)
    {
        Console.WriteLine("Đường đi ngắn nhất từ " + start + " đến " + end + ":");
        Console.Write("Đường đi: ");
        int current = end;
        while (current != start)
        {
            if (pre[current] == -1)
            {
                Console.WriteLine("Không có đường đi");
                return;
            }
            
            Console.Write(current + " <- ");
            current = pre[current];
            if (current == start)
            {
                Console.Write(current);
            }
        }
        Console.WriteLine();
        Console.WriteLine("Độ dài đường đi: " + distance[end]);
    }
    // Tìm đường đi ngắn nhất từ đỉnh đầu tiên đến tất cả các đỉnh destination, bằng thuật toán Bellman-Ford
    // Dùng biến Pre để lưu đỉnh trước đỉnh hiện tại
    // Nếu có mạch âm thì hiện thông báo có mạch âm
    public void BellmanFord(int start, int end)
    {
        int V = g.V;
        List<int> distance = new List<int>();
        List<int> pre = new List<int>();
        for (int i = 0; i < V; i++)
        {
            distance.Add(int.MaxValue);
            pre.Add(-1);
        }
        distance[start] = 0;
        for (int i = 0; i < V - 1; i++)
        {
            for (int u = 0; u < V; u++)
            {
                for (int v = 0; v < V; v++)
                {
                    if (g.adjMatrix[u, v].Count > 0 && distance[u] != int.MaxValue &&
                        distance[u] + g.adjMatrix[u, v][0] < distance[v])
                    {
                        distance[v] = distance[u] + g.adjMatrix[u, v][0];
                        pre[v] = u;
                    }
                }
            }
        }
        for (int u = 0; u < V; u++)
        {
            for (int v = 0; v < V; v++)
            {
                if (g.adjMatrix[u, v].Count > 0 && distance[u] != int.MaxValue &&
                    distance[u] + g.adjMatrix[u, v][0] < distance[v])
                {
                    Console.WriteLine("Do thi co mach am");
                    return;
                }
            }
        }

        PrintPath(start, end, distance, pre);
    }
}