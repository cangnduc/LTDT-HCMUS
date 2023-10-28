using System.Diagnostics.CodeAnalysis;

class Bai3
{
    public Graphs g;
    public Bai3(string filePath)
    {
        g = new Graphs(filePath);
    }
    public void ShowBai3()
    {
        Console.WriteLine("Bai 3: ");
        if (g.isUndirected && g.IsConnected())
        {
            Console.WriteLine("Giai thuat Prim");
            Prim(0);

            Console.WriteLine("Giai thuat Kruskal");
            Kruskal();
        }
    }
    public void Prim(int start)
    {
        int[] parent = new int[g.V];
        int[] key = new int[g.V];
        bool[] mstSet = new bool[g.V];
        for (int i = 0; i < g.V; i++)
        {
            key[i] = int.MaxValue;
            mstSet[i] = false;
        }
        key[start] = 0;
        parent[start] = -1;
        for (int i = 0; i < g.V - 1; i++)
        {
            int u = MinKey(key, mstSet);
            mstSet[u] = true;
            for (int v = 0; v < g.V; v++)
            {
                if (g.adjMatrix[u, v].Count > 0 && mstSet[v] == false && g.adjMatrix[u, v][0] < key[v])
                {
                    parent[v] = u;
                    key[v] = g.adjMatrix[u, v][0];
                }
            }
        }
        PrintMST(parent, key);
    }
    public int MinKey(int[] key, bool[] mstSet)
    {
        int min = int.MaxValue;
        int min_index = -1;
        for (int v = 0; v < g.V; v++)
        {
            if (mstSet[v] == false && key[v] < min)
            {
                min = key[v];
                min_index = v;
            }
        }
        return min_index;
    }
    public void PrintMST(int[] parent, int[] key)
    {
        int count = 0;
        Console.WriteLine("Canh cua cay khung nho nhat: ");
        for (int i = 1; i < g.V; i++)
        {
            Console.WriteLine($"{parent[i]} - {i}: {key[i]}");
            count += key[i];
        }
        Console.WriteLine("Tong trong so cua cay khung nho nhat: " + count);
    }
    // Tìm và in đường đi ngắn nhất bằng thuật toán Kruskal
    public void Kruskal()
    {
        int V = g.V;
        List<Edge> result = new List<Edge>();
        int e = 0;
        int i = 0;
        List<Edge> edges = new List<Edge>();
        for (int u = 0; u < V; u++)
        {
            for (int v = 0; v < V; v++)
            {
                if (g.adjMatrix[u, v].Count > 0)
                {
                    edges.Add(new Edge(u, v, g.adjMatrix[u, v][0]));
                }
            }
        }
        edges.Sort();
        int[] parent = new int[V];
        int[] rank = new int[V];
        for (int v = 0; v < V; v++)
        {
            parent[v] = v;
            rank[v] = 0;
        }
        while (e < V - 1)
        {
            Edge next_edge = edges[i++];
            int x = Find(parent, next_edge.src);
            int y = Find(parent, next_edge.dest);
            if (x != y)
            {
                result.Add(next_edge);
                Union(parent, rank, x, y);
                e++;
            }
        }
        Console.WriteLine("Canh cua cay khung nho nhat: ");
        int count = 0;
        for (i = 0; i < result.Count; i++)
        {
            Console.WriteLine($"{result[i].src} - {result[i].dest}: {result[i].weight}");
            count += result[i].weight;
        }
        Console.WriteLine("Tong trong so cua cay khung nho nhat: " + count);
    }
    public int Find(int[] parent, int i)
    {
        if (parent[i] == i)
        {
            return i;
        }
        return Find(parent, parent[i]);
    }
    public void Union(int[] parent, int[] rank, int x, int y)
    {
        int xroot = Find(parent, x);
        int yroot = Find(parent, y);
        if (rank[xroot] < rank[yroot])
        {
            parent[xroot] = yroot;
        }
        else if (rank[xroot] > rank[yroot])
        {
            parent[yroot] = xroot;
        }
        else
        {
            parent[yroot] = xroot;
            rank[xroot]++;
        }
    }

}
class Edge : IComparable<Edge>
{
    public int src, dest, weight;
    public Edge(int src, int dest, int weight)
    {
        this.src = src;
        this.dest = dest;
        this.weight = weight;
    }
    
    public int CompareTo([AllowNull] Edge other)
    {
        if (other == null)
        {
            return 1;
        }
        return this.weight - other.weight;
    }
}