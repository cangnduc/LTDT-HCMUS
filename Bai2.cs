class Bai2
{
    public Graphs g;
    public Bai2(string filePath)
    {
        g = new Graphs(filePath);
    }
    // Đếm số thành phần liên thông của đồ thị và in ra mỗi thành phần liên thông

    public void ShowBai2()
    {
        Console.WriteLine("Yeu cau 2 Duyet do thi: ");
        if (g.IsConnected())
        {
            Console.WriteLine("Giả Thuât DFS:");
            DFS(0, new bool[g.V]);
            Console.WriteLine();
            Console.WriteLine("Giả Thuât BFS:");
            BFS(0);
        }
        else
        {
            Console.WriteLine("Do thi khong lien thong");
            List<List<int>> connectedComponents = ConnectedComponents();
            Console.WriteLine("So thanh phan lien thong: " + connectedComponents.Count);
            for (int i = 0; i < connectedComponents.Count; i++)
            {
                Console.Write("Thanh phan lien thong thu " + (i + 1) + ": ");
                for (int j = 0; j < connectedComponents[i].Count; j++)
                {
                    Console.Write(connectedComponents[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
    public List<List<int>> ConnectedComponents()
    {
        List<List<int>> connectedComponents = new List<List<int>>();
        bool[] visited = new bool[g.V];
        for (int i = 0; i < g.V; i++)
        {
            visited[i] = false;
        }
        for (int i = 0; i < g.V; i++)
        {
            if (!visited[i])
            {
                List<int> connectedComponent = new List<int>();
                DFS(i, visited, connectedComponent);
                connectedComponents.Add(connectedComponent);
            }
        }
        return connectedComponents;
    }
    public void DFS(int u, bool[] visited, List<int> connectedComponent)
    {
        visited[u] = true;
        connectedComponent.Add(u);
        for (int v = 0; v < g.V; v++)
        {
            if (!visited[v] && g.adjMatrix[u, v].Count > 0)
            {
                DFS(v, visited, connectedComponent);
            }
        }
    }
    // Giải thuật DFS, input là đỉnh bắt đầu
    // in ra đường đi từ đỉnh bắt đầu đến tất cả các đỉnh
    public void DFS(int start, bool[] visited)
    {
        visited[start] = true;
        Console.Write(start + " ");
        for (int v = 0; v < g.V; v++)
        {
            if (!visited[v] && g.adjMatrix[start, v].Count > 0)
            {
                DFS(v, visited);
            }
        }
    }
    // Giải thuật BFS, input là đỉnh bắt đầu
    // in ra đường đi từ đỉnh bắt đầu đến tất cả các đỉnh
    public void BFS(int start)
    {
        bool[] visited = new bool[g.V];
        for (int i = 0; i < g.V; i++)
        {
            visited[i] = false;
        }
        Queue<int> queue = new Queue<int>();
        visited[start] = true;
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            int u = queue.Dequeue();
            Console.Write(u + " ");
            for (int v = 0; v < g.V; v++)
            {
                if (!visited[v] && g.adjMatrix[u, v].Count > 0)
                {
                    visited[v] = true;
                    queue.Enqueue(v);
                }
            }
        }
    }
   

}