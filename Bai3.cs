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
}