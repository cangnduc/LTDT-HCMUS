class Bai5
{
    public Graphs g;
    public Bai5(string filePath)
    {
        g = new Graphs(filePath);
    }
    public void ShowBai5()
    {
        Console.WriteLine("Yeu cau 5: Tim chu trinh Euler");
        // Kiểm tra đồ thị có phải là đơn đồ thị và liên thông
        if (g.isSimpleGraph && g.IsConnected())
        {
            if (isEulerCycle())
            {
                // Tìm chu trình Euler voi dinh bat dau la 1
                int start = 1;

                FindEulerCycle(start);
            }
            else if (isEulerPath())
            {
                // Tìm đường đi Euler, dinh bat dau la 1 trong 2 dinh bac le cuar do thi.
                Console.WriteLine("Duong di Euler: ");
                FindEulerPath();
            }
            else
            {
                Console.WriteLine("Khong co chu trinh Euler");
            }
        }
        else
        {
            Console.WriteLine("Khong co chu trinh Euler");
        }

    }
    //Kiem tra do thi co chu trinh Euler hay khong
    // Do thi vo huong: tat ca cac dinh deu co bac chan
    public bool isEulerCycle()
    {
        // do thi vo huong, tat ca cac dinh deu co bac chan
        if (g.isUndirected)
        {
            int[] degree = g.GetDegree();
            for (int i = 0; i < degree.Length; i++)
            {
                if (degree[i] % 2 != 0)
                {
                    return false;
                }
            }
        }
        // do thi co huong, tat ca cac dinh deu co bac vao = bac ra
        else if (!g.isUndirected)
        {
            int[,] degree = g.GetDegreeDirected();
            for (int i = 0; i < degree.GetLength(0); i++)
            {
                if (degree[i, 0] != degree[i, 1])
                {
                    return false;
                }
            }
        }
        return true;

    }
    // Kiem tra do thi co duong di Euler hay khong
    public bool isEulerPath()
    {
        // Đồ thị vô hướng, chỉ có duy nhất 2 đỉnh bậc lẻ
        if (g.isUndirected)
        {
            int[] degrees = g.GetDegree();
            int count = 0;
            for (int i = 0; i < degrees.Length; i++)
            {
                if (degrees[i] % 2 != 0)
                {
                    count++;

                }
            }
            if (count != 2) return false;

            return true;
        }
        // Đồ thị có hướng, tồn tại 2 đỉnh u, v, deg+(u) - deg-(u) = 1 và deg+(v) - deg-(v) = -1
        else
        {
            int[,] degrees = g.GetDegreeDirected();
            int count = 0;
            for (int i = 0; i < degrees.GetLength(0); i++)
            {
                if (Math.Abs(degrees[i, 0] - degrees[i, 1]) == 1)
                {
                    count++;

                }

            }
            return count == 2;
        }

    }
    // Tim chu trinh Euler va in ra ket qua
    public void FindEulerCycle(int start)
    {
        if (g.isUndirected)
        { // check undirected graph
            int[] degree = g.GetDegree();
            List<int> path = new List<int>();
            int index = 0;
            path.Add(start);
            index++;
            int u = start;
            while (true)
            {
                int v = -1;
                for (int i = 0; i < g.V; i++)
                {
                    if (g.adjMatrix[u, i].Count > 0)
                    {
                        v = i;
                        break;
                    }
                }
                if (v == -1)
                {
                    break;
                }
                else
                {
                    path.Add(v);
                    index++;
                    g.adjMatrix[u, v].RemoveAt(0);
                    g.adjMatrix[v, u].RemoveAt(0);
                    u = v;
                }
            }
            Console.WriteLine("Chu trinh Euler: ");
            for (int i = 0; i < index; i++)
            {
                Console.Write(path[i] + " ");
            }
        }
        else if (!g.isUndirected) // check directed graph
        {
            int[,] degree = g.GetDegreeDirected();
            List<int> path = new List<int>();
            int index = 0;
            path.Add(start);
            index++;
            int u = start;
            while (true)
            {
                int v = -1;
                for (int i = 0; i < g.V; i++)
                {
                    if (g.adjMatrix[u, i].Count > 0)
                    {
                        v = i;
                        break;
                    }
                }
                if (v == -1)
                {
                    break;
                }
                else
                {
                    path.Add(v);
                    index++;
                    g.adjMatrix[u, v].RemoveAt(0);
                    u = v;
                }
            }
            Console.WriteLine("Chu trinh Euler: ");
            for (int i = 0; i < index; i++)
            {
                Console.Write(path[i] + " ");
            }
        }
        else
        {
            Console.WriteLine("Khong co chu trinh Euler");
        }
    }
    // Tim duong di Euler va in ra ket qua
    public void FindEulerPath()
    {
        if (g.isUndirected && g.IsConnected()) // check undirected graph
        {
            int[] degree = g.GetDegree();
            List<int> path = new List<int>();
            int index = 0;
            int start = 0;
            for (int i = 0; i < degree.Length; i++)
            {
                if (degree[i] % 2 != 0)
                {
                    start = i;
                    break;
                }
            }
            path.Add(start);
            index++;
            int u = start;
            while (true)
            {
                int v = -1;
                for (int i = 0; i < g.V; i++)
                {
                    if (g.adjMatrix[u, i].Count > 0)
                    {
                        v = i;
                        break;
                    }
                }
                if (v == -1)
                {
                    break;
                }
                else
                {
                    path.Add(v);
                    index++;
                    g.adjMatrix[u, v].RemoveAt(0);
                    g.adjMatrix[v, u].RemoveAt(0);
                    u = v;
                }
            }
            Console.WriteLine("Duong di Euler: ");
            for (int i = 0; i < index; i++)
            {
                Console.Write(path[i] + " ");
            }



        }
        else if (!g.isUndirected) // check directed graph
        {
            int[,] degree = g.GetDegreeDirected();
            List<int> path = new List<int>();
            int index = 0;
            int start = 0;
            for (int i = 0; i < degree.GetLength(0); i++)
            {
                if (Math.Abs(degree[i, 0] - degree[i, 1]) == 1)
                {
                    start = i;
                    break;
                }
            }
            path.Add(start);
            index++;
            int u = start;
            while (true)
            {
                int v = -1;
                for (int i = 0; i < g.V; i++)
                {
                    if (g.adjMatrix[u, i].Count > 0)
                    {
                        v = i;
                        break;
                    }
                }
                if (v == -1)
                {
                    break;
                }
                else
                {
                    path.Add(v);
                    index++;
                    g.adjMatrix[u, v].RemoveAt(0);
                    u = v;
                }
            }

            Console.WriteLine("Duong di Euler: ");
            for (int i = 0; i < index; i++)
            {
                Console.Write(path[i] + " ");
            }
        }

    }


}