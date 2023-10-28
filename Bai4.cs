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
        }
        else
        {
            Console.WriteLine("Do thi khong co trong so am");
            Dijkstra(0, 4);
        }
        
    }
    // Kiem tra do thi co trong so Am hay khong
    public bool isNegativeWeight() {
        if(g.isUndirected) {
            for(int i = 0; i < g.V; i++) {
                for(int j = 0; j < g.V; j++) {
                    if(g.adjMatrix[i,j].Count > 0) {
                        if(g.adjMatrix[i,j][0] < 0) {
                            return true;
                        }
                    }
                }
            }
        }
        else {
            for(int i = 0; i < g.V; i++) {
                for(int j = 0; j < g.V; j++) {
                    if(g.adjMatrix[i,j].Count > 0) {
                        if(g.adjMatrix[i,j][0] < 0) {
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
        PrintPath(start, end, distance);
        

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
    private void PrintPath(int start, int end, List<int> distance)
    {
        Console.WriteLine("Duong di ngan nhat tu dinh {0} den dinh {1} la: ", start, end);
        Console.WriteLine("Dinh \t\t Khoang cach \t\t Dinh truoc");
        for (int i = 0; i < g.V; i++)
        {
            Console.WriteLine("{0} \t\t {1} \t\t {2}", i, distance[i], i);
        }
    }
}