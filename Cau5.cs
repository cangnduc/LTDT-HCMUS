using System;
class Cau5
{
    public string? filePath;
    public Graph graph;
    public Cau5(string filePath)
    {
        this.filePath = filePath;
        if (this.filePath != null)
        {
            this.graph = new Graph(this.filePath);
        }
        else this.graph = new Graph();
    }
    public bool IsEulerGraph()
    {
        // Đồ thị vô hướng, kiểm tra bậc của các đỉnh đều là chẵn
        if (this.graph.isUndirected)
        {
            int[][] degrees = this.graph.countDegrees();
            for (int i = 0; i < degrees.Length; i++)
            {
                if (degrees[i][0] % 2 != 0)
                {
                    return false;
                }
            }
            return true;
        }
        // Đồ thị có hướng, kiểm tra bậc vào bằng bậc ra, Nếu bậc của
        // các đỉnh đều bằng nhau thì đồ thị có chu trình euler, nếu

        else
        {
            int[][] degrees = this.graph.countDegrees();
            for (int i = 0; i < degrees.Length; i++)
            {
                if (degrees[i][0] != degrees[i][1])
                {
                    return false;
                }
            }
            return true;
        }

    }
    // Kiểm tra đồ thị có đường đi Eluer hay không
    // 
    public bool isEulerPath()
    {
        // Đồ thị vô hướng, chỉ có duy nhất 2 đỉnh bậc lẻ
        if (this.graph.isUndirected)
        {
            int[][] degrees = this.graph.countDegrees();
            int count = 0;
            for (int i = 0; i < degrees.Length; i++)
            {
                if (degrees[i][0] % 2 != 0)
                {
                    count++;
                    if (count == 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        // Đồ thị có hướng, tồn tại 2 đỉnh u, v, deg+(u) - deg-(u) = 1 và deg+(v) - deg-(v) = -1
        else
        {
            int[][] degrees = this.graph.countDegrees();
            int count = 0;
            for (int i = 0; i < degrees.Length; i++)
            {
                if (degrees[i][0] - degrees[i][1] == 1)
                {
                    count++;
                    if (count > 1)
                    {
                        return false;
                    }
                }
                else if (degrees[i][0] - degrees[i][1] == -1)
                {
                    count++;
                    if (count > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    // Tìm đường đi Euler
    public void FindEulerPath()
    {
        //Kiểm tra đồ thị vô hướng
        if (this.graph.isUndirected && this.graph.IsSimpleGraph() && this.graph.IsConnected())
        {

            // Đồ thị có đường đi Euler và là đồ thị đơn
            if (this.isEulerPath())
            {
                int[][] degrees = this.graph.countDegrees();
                int start = 0;
                for (int i = 0; i < degrees.Length; i++)
                {
                    if (degrees[i][0] % 2 != 0)
                    {
                        start = i;
                        break;
                    }
                }
                int[] path = new int[this.graph.GetNumEdges() + 1];
                int index = 0;
                int current = start;
                int next = 0;
                while (index < path.Length)
                {
                    path[index] = current;
                    index++;
                    for (int i = 0; i < this.graph.numVertices; i++)
                    {
                        if (this.graph.adjacencyMatrix[current, i] > 0)
                        {
                            next = i;
                            break;
                        }
                    }
                    this.graph.adjacencyMatrix[current, next]--;
                    this.graph.adjacencyMatrix[next, current]--;
                    current = next;
                }
                Console.WriteLine("Duong di Euler: ");
                for (int i = 0; i < path.Length; i++)
                {
                    Console.Write(path[i] + " ");
                }
                Console.WriteLine();
            }
            else if (this.IsEulerGraph())
            {
                int[][] degrees = this.graph.countDegrees();
                int start = 0;
                for (int i = 0; i < degrees.Length; i++)
                {
                    if (degrees[i][0] % 2 != 0)
                    {
                        start = i;
                        break;
                    }
                }
                int[] path = new int[this.graph.GetNumEdges() + 1];
                int index = 0;
                int current = start;
                int next = 0;
                while (index < path.Length)
                {
                    path[index] = current;
                    index++;
                    for (int i = 0; i < this.graph.numVertices; i++)
                    {
                        if (this.graph.adjacencyMatrix[current, i] > 0)
                        {
                            next = i;
                            break;
                        }
                    }
                    this.graph.adjacencyMatrix[current, next]--;
                    this.graph.adjacencyMatrix[next, current]--;
                    current = next;
                }
                Console.WriteLine("Chu trinh Euler: ");
                for (int i = 0; i < path.Length; i++)
                {
                    Console.Write(path[i] + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Không Có Đừng đi Euler");

            }

        }
        else if (this.graph.isUndirected == false && this.graph.IsSimpleGraph() && this.graph.IsConnected())
        {

            // Đồ thị có hướng có đường đi Euler và là đồ thị đơn
            if (this.isEulerPath() && this.graph.IsSimpleGraph())
            {
                int[][] degrees = this.graph.countDegrees();
                // Băt đầu từ đỉnh có bậc vào và bậc ra chênh lệch 1
                int start = 0;
                for (int i = 0; i < degrees.Length; i++)
                {
                    if (Math.Abs(degrees[i][0] - degrees[i][1]) == 1)
                    {
                        start = i;
                        break;
                    }
                }
                int[] path = new int[this.graph.GetNumEdges() + 1]; //đường đi euler
                int index = 0;
                int current = start;
                int next = 0;
                while (index < path.Length)
                {
                    path[index] = current;
                    index++;
                    for (int i = 0; i < this.graph.numVertices; i++)
                    {
                        if (this.graph.adjacencyMatrix[current, i] > 0)
                        {
                            next = i;
                            break;
                        }
                    }
                    this.graph.adjacencyMatrix[current, next]--;
                    current = next;
                }
                Console.WriteLine("Duong di Euler: ");
                for (int i = 0; i < path.Length; i++)
                {
                    Console.Write(path[i] + " ");
                }
                Console.WriteLine();
            }
            else if (this.IsEulerGraph() && this.graph.IsSimpleGraph())
            {
                int[][] degrees = this.graph.countDegrees();
                int start = 0;
                for (int i = 0; i < degrees.Length; i++)
                {
                    if (degrees[i][0] - degrees[i][1] == 1)
                    {
                        start = i;
                        break;
                    }
                }
                int[] path = new int[this.graph.GetNumEdges() + 1];
                int index = 0;
                int current = start;
                int next = 0;
                while (index < path.Length)
                {
                    path[index] = current;
                    index++;
                    for (int i = 0; i < this.graph.numVertices; i++)
                    {
                        if (this.graph.adjacencyMatrix[current, i] > 0)
                        {
                            next = i;
                            break;
                        }
                    }
                    this.graph.adjacencyMatrix[current, next]--;
                }
                Console.WriteLine("Chu trinh Euler: ");
                for (int i = 0; i < path.Length; i++)
                {
                    Console.Write(path[i] + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Không Có Đừng đi Euler");

            }

        }
        else
        {
            Console.WriteLine("Đa đồ thị Không Có Đừng đi Euler");
        }
    }
    public void ShowEluer()
    {
        //Graph Graph = new Graph("Graph/cau1-2.txt");
        if (graph == null)
        {
            Console.WriteLine("Khong the doc file");
            return;
        }
        else
        {

            HandleLogic();

        }


    }
    public void HandleLogic()
    {

        if (graph != null)
        {
            this.FindEulerPath();
        }
    }
}