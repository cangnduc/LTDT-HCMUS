using System;
using System.IO;
using System.Linq;

class Graph
{

    private int numVertices;
    private int[,] adjacencyMatrix;
    public bool isUndirected = false;
    public int IsolatedVertices;
    // Khởi tạo ma trận kề
    public Graph(string filename)
    {
        this.numVertices = 0;
        this.adjacencyMatrix = new int[0, 0];
        ReadFile(filename);
        this.isUndirected = CheckIsUndirected();
        this.IsolatedVertices = countIsolatedVertices();
    }
    public Graph()
    {
        this.numVertices = 0;
        this.adjacencyMatrix = new int[0, 0];
    }
    // Thêm cạnh từ đỉnh source đến đỉnh destination với trọng số weight
    public void AddEdge(int source, int destination, int weight)
    {
        if (adjacencyMatrix[source, destination] == 0)
        {
            adjacencyMatrix[source, destination] = weight;
        }
        else
        {
            adjacencyMatrix[source, destination] += weight;
        }


    }
    // Lấy trọng số từ đỉnh source đến đỉnh destination

    public int GetWeight(int source, int destination)
    {
        return adjacencyMatrix[source, destination];
    }
    // In ma trận kề
    public void PrintAdjacencyMatrix()
    {
        for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
            {
                Console.Write(adjacencyMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    // Đọc dữ liệu từ file
    public void ReadFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        this.numVertices = int.Parse(lines[0]);
        this.adjacencyMatrix = new int[numVertices, numVertices];
        for (int i = 1; i < lines.Length; i++)
        {
            string[] tokens = lines[i].Split(" ");
            for (int j = 0; j < tokens.Length / 2; j++)
            {
                AddEdge(i - 1, int.Parse(tokens[2 * j + 1]), int.Parse(tokens[2 * j + 2]));
            }
        }
    }
    // Đếm số cạnh
    public int GetNumEdges()
    {
        // Tìm số cạnh =  tổng degree của các đỉnh / 2 = e
        int count = 0;
        int[][] degrees = this.countDegrees();
        for (int i = 0; i < degrees.Length; i++)
        {
            count += degrees[i][1] + degrees[i][0];
        }
        return count / 2;
        /* if (isUndirected())
        {
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i, j] != 0)
                    {

                        count += adjacencyMatrix[i, j];
                        if (i == j)
                        {
                            count += adjacencyMatrix[i, j];
                        }

                    }
                }
            }
            return count / 2;
        }
        else {
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i, j] != 0)
                    {

                        count += adjacencyMatrix[i, j];
                       

                    }
                }
            }
        }*/

    }
    public int[][] countDegrees()
    {
        int[][] degrees = new int[numVertices][];
        if (this.isUndirected)
        {
            for (int i = 0; i < numVertices; i++)
            {
                int[] count = new int[2];
                for (int j = 0; j < numVertices; j++)
                {
                    if (this.adjacencyMatrix[i, j] != 0)
                    {
                        count[0] += this.adjacencyMatrix[i, j];
                        if (i == j)
                        {
                            count[0] += this.adjacencyMatrix[i, i];
                        }
                    }
                }
                degrees[i] = count;
            }
        }
        else
        {

            for (int i = 0; i < numVertices; i++)
            {

                int[] count = new int[2];
                for (int j = 0; j < numVertices; j++)
                {

                    count[0] += this.adjacencyMatrix[i, j];

                    count[1] += this.adjacencyMatrix[j, i];

                }
                //Console.WriteLine(count[0] + " " + count[1]);
                degrees[i] = count;
            }
        }
        return degrees;
    }
    public void PrintVertex()
    {
        int[][] degrees = this.countDegrees();
        Console.WriteLine("Bac cua Tung Dinh la:");
        if (this.isUndirected)
        {
            for (int i = 0; i < degrees.Length; i++)
            {

                Console.Write($"{i} ({degrees[i][0]}), ");
            }
        }
        else
            for (int i = 0; i < degrees.Length; i++)
            {

                Console.Write($"{i} ({degrees[i][1]}-{degrees[i][0]}), ");
            }
        Console.WriteLine();
    }
    // Đếm số đỉnh
    public int GetNumVertices()
    {
        return numVertices;
    }
    public bool CheckIsUndirected()
    {
        for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
            {
                if (adjacencyMatrix[i, j] != adjacencyMatrix[j, i])
                {
                    return false;
                }
            }
        }
        return true;
    }
    public int CountParallelEdges()
    {
        int parallelEdgeCount = 0;
        for (int i = 0; i < numVertices; i++)
        {
            for (int j = i + 1; j < numVertices; j++)
            {
                if (adjacencyMatrix[i, j] > 1)
                {
                    parallelEdgeCount++;
                }
            }
        }
        return parallelEdgeCount;
    }
    public int CountSelfLoops()
    {
        int selfLoopCount = 0;

        for (int i = 0; i < numVertices; i++)
        {
            if (adjacencyMatrix[i, i] > 0)
            {
                selfLoopCount++;
            }
        }
        return selfLoopCount;
    }
    private int countIsolatedVertices()
    {
        int count = 0;
        int[][] degrees = this.countDegrees();
        for (int i = 0; i < degrees.Length; i++)
        {
            if (degrees[i][0] == 0 && degrees[i][1] == 0)
            {
                count++;
            }
        }
        return count;
    }
    // Kiểm tra đồ thị có phải là đơn đồ thị
    public bool IsSimpleGraph()
    {
        if (this.isUndirected)
        {
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i, j] > 1)
                    {
                        return false;
                    }
                    // có cạnh khuyên
                    else if (i == j && adjacencyMatrix[i, j] > 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        else
        {
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
                {
                    if (adjacencyMatrix[i, j] > 1 || adjacencyMatrix[j, i] > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
    // Kiểm tra đồ thị có chu trình hoặc đường đi euler hay không
    public bool IsEulerGraph()
    {
        // Đồ thị vô hướng, kiểm tra bậc của các đỉnh đều là chẵn
        if (this.isUndirected)
        {
            int[][] degrees = this.countDegrees();
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
            int[][] degrees = this.countDegrees();
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
        if (this.isUndirected)
        {
            int[][] degrees = this.countDegrees();
            int count = 0;
            for (int i = 0; i < degrees.Length; i++)
            {
                if (degrees[i][0] % 2 != 0)
                {
                    count++;
                    if (count > 2)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        // Đồ thị có hướng, tồn tại 2 đỉnh u, v, deg+(u) - deg-(u) = 1 và deg+(v) - deg-(v) = -1
        else
        {
            int[][] degrees = this.countDegrees();
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
        if (this.isUndirected)
        {
            // Đồ thị có đường đi Euler và là đồ thị đơn
            if (this.isEulerPath() && this.IsSimpleGraph())
            {
                int[][] degrees = this.countDegrees();
                int start = 0;
                for (int i = 0; i < degrees.Length; i++)
                {
                    if (degrees[i][0] % 2 != 0)
                    {
                        start = i;
                        break;
                    }
                }
                int[] path = new int[this.GetNumEdges() + 1];
                int index = 0;
                int current = start;
                int next = 0;
                while (index < path.Length)
                {
                    path[index] = current;
                    index++;
                    for (int i = 0; i < this.numVertices; i++)
                    {
                        if (this.adjacencyMatrix[current, i] > 0)
                        {
                            next = i;
                            break;
                        }
                    }
                    this.adjacencyMatrix[current, next]--;
                    this.adjacencyMatrix[next, current]--;
                    current = next;
                }
                Console.WriteLine("Duong di Euler: ");
                for (int i = 0; i < path.Length; i++)
                {
                    Console.Write(path[i] + " ");
                }
                Console.WriteLine();
            }
            else if (this.IsEulerGraph() && this.IsSimpleGraph())
            {
                int[][] degrees = this.countDegrees();
                int start = 0;
                for (int i = 0; i < degrees.Length; i++)
                {
                    if (degrees[i][0] % 2 != 0)
                    {
                        start = i;
                        break;
                    }
                }
                int[] path = new int[this.GetNumEdges() + 1];
                int index = 0;
                int current = start;
                int next = 0;
                while (index < path.Length)
                {
                    path[index] = current;
                    index++;
                    for (int i = 0; i < this.numVertices; i++)
                    {
                        if (this.adjacencyMatrix[current, i] > 0)
                        {
                            next = i;
                            break;
                        }
                    }
                    this.adjacencyMatrix[current, next]--;
                    this.adjacencyMatrix[next, current]--;
                    current = next;
                }
                Console.WriteLine("Duong di Euler: ");
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
    }


}
