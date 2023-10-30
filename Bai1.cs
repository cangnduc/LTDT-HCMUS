class Bai1
{
    public Graphs g;
    public Bai1(string filePath)
    {
        g = new Graphs(filePath);
    }
    public void ShowBai1()
    {
       

        g.PrintGraph();
        Console.WriteLine("Phan tich thong tin do thi");
        Console.WriteLine("So canh cua do thi:" + g.GetNumEdges());
        PrintDegree();
        Console.WriteLine();
        Console.WriteLine("So canh khuyen:" + CountSelfLoops());
        Console.WriteLine("So dinh treo:" + CountLeaf());
        Console.WriteLine("So dinh co lap:" + countIsolatedVertices());
        Console.WriteLine("So canh song song:" + CountParallelEdges());
        Console.WriteLine("Do thi lien thong:" + g.IsConnected());
        Console.WriteLine("Co phai don do thi?: " + g.isSimpleGraph);
    }
    public void PrintDegree()
    {
        if (g.isUndirected)
        {
            Console.WriteLine("Do thi vo huong");
            Console.WriteLine("Bac cua cac dinh:");
            int[] degree = g.GetDegree();
            for (int i = 0; i < degree.Length; i++)
            {
                Console.Write($"{i}({degree[i]})" + " ");
            }
        }
        else
        {
            Console.WriteLine("Do thi co huong");
            Console.WriteLine("Bac vao va ra cua cac dinh:");
            int[,] degree = g.GetDegreeDirected();
            for (int i = 0; i < degree.GetLength(0); i++)
            {
                Console.Write($"{i}({degree[i, 1]},{degree[i, 0]})" + " ");
            }
        }

    }
    public int CountParallelEdges()
    {
        int count = 0;
        for (int i = 0; i < g.V; i++)
        {
            for (int j = 0; j < g.V; j++)
            {
                if (g.adjMatrix[i, j].Count > 1)
                {
                    count++;
                }
            }
        }
        if (g.isUndirected) return count / 2;
        return count;
    }
    public int CountSelfLoops()
    {
        int count = 0;
        for (int i = 0; i < g.V; i++)
        {
            if (g.adjMatrix[i, i].Count > 0)
            {
                count++;
            }
        }
        return count;
    }
    // Đếm số đỉnh treo, đồ thị vô hướng, đỉnh treo có bậc = 1
    // Đồ thị có hướng, đỉnh treo có bậc vào hoặc ra = 1
    public int CountLeaf()
    {
        int count = 0;
        if (g.isUndirected)
        {
            int[] degree = g.GetDegree();
            for (int i = 0; i < degree.Length; i++)
            {
                if (degree[i] == 1)
                {
                    count++;
                }
            }
        }
        else
        {
            int[,] degree = g.GetDegreeDirected();
            for (int i = 0; i < degree.GetLength(0); i++)
            {
                if (degree[i, 0] + degree[i, 1] == 1)
                {
                    count++;
                }
            }
        }

        return count;
    }
    public int countIsolatedVertices()
    {
        int count = 0;
        if (g.isUndirected)
        {
            int[] degree = g.GetDegree();
            for (int i = 0; i < degree.Length; i++)
            {
                if (degree[i] == 0)
                {
                    count++;
                }
            }
        }
        else
        {
            int[,] degree = g.GetDegreeDirected();
            for (int i = 0; i < degree.GetLength(0); i++)
            {
                if (degree[i, 0] + degree[i, 1] == 0)
                {
                    count++;
                }
            }
        }

        return count;
    }

}
