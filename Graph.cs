using System;
using System.IO;
using System.Linq;

class Graph
{

    public int numVertices =0;
    public int[,] adjacencyMatrix = new int[0,0];
    public List<int>[] adjacencyList = new List<int>[0];
    public bool isUndirected;
    public int IsolatedVertices;
    // Khởi tạo ma trận kề
    public Graph(string filename)
    {
        
        ReadFile(filename);
        ConvertToAdjacencyList();
        this.isUndirected = CheckIsUndirected();
        this.IsolatedVertices = countIsolatedVertices();
    }
    public Graph()
    {
       
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
    public void PrintadjacencyMatrix()
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
    // Đếm bậc của các đỉnh, dùng mảng 2 chiều lưu bậc của các đỉnh [i][0] là bậc vào, [i][1] là bậc ra
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
    // In bậc của các đỉnh
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
    // Đếm số đỉnh treo, trong đồ thị vô hướng nếu bậc của đỉnh i = 1 thì đỉnh i là đỉnh treo
    // Trong đồ thị có hướng nếu tổng bậc vào và bậc ra của đỉnh i = 1 thì đỉnh i là đỉnh treo
    public int CountLeftNode() {
        int count = 0;
        // [i][0] là bậc của đỉnh i trong đồ thị vô hướng
        // [i][0] là bậc vào, [i][1] là bậc ra => đồ thị có hướng
        int[][] degrees = this.countDegrees(); 
        
        if(this.isUndirected) {
            for (int i = 0; i < degrees.Length; i++)
            {
                if (degrees[i][0] == 1)
                {
                    count++;
                }
            }
        }
        else {
            for (int i = 0; i < degrees.Length; i++)
            {
                if (degrees[i][0] + degrees[i][1] == 1)
                {
                    count++;
                }
            }
        }
        
        return count;
    }
    // Đếm số cạnh khuyên, trong ma trận kề đỉnh nếu i = j và adjacencyMatrix[i,j] > 0 thì đỉnh i có cạnh khuyên
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
    // Đếm số đỉnh cô lập, trong ma trận kề nếu bậc của đỉnh i = 0 thì đỉnh i cô lập
    private int countIsolatedVertices()
    {
        int count = 0;
        // [i][0] là bậc của đỉnh i trong đồ thị vô hướng
        // [i][0] là bậc vào, [i][1] là bậc ra => đồ thị có hướng
        int[][] degrees = this.countDegrees();
        for (int i = 0; i < degrees.Length; i++)
        {
            if (degrees[i][0]  + degrees[i][1] == 0)
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
    // Convert ma trận kề sang danh sách kề
    public void ConvertToAdjacencyList()
    {
        this.adjacencyList = new List<int>[numVertices];
        for (int i = 0; i < numVertices; i++)
        {
            List<int> list = new List<int>();
            for (int j = 0; j < numVertices; j++)
            {
                if (adjacencyMatrix[i, j] != 0)
                {
                    list.Add(j);
                }
            }
            adjacencyList[i] = list;
        }
    }
    // In danh sách kề
    public void PrintAdjacencyList()
    {
        Console.WriteLine("Danh sach ke cua Tung Dinh la:");
        Console.WriteLine(adjacencyList.Length);
        for (int i = 0; i < adjacencyList.Length; i++)
        {
            Console.Write($"{i}: ");
            for (int j = 0; j < adjacencyList[i].Count; j++)
            {
                Console.Write($"{adjacencyList[i][j]} ");
            }
            Console.WriteLine();
        }
    }
    // Đếm số thành phần liên thông
    public bool IsConnected()
    {
        bool[] visited = new bool[numVertices];
        Queue<int> queue = new Queue<int>();
        int count = 0;

        for (int i = 0; i < numVertices; i++)
        {
            if (!visited[i])
            {
                queue.Enqueue(i);
                visited[i] = true;
                count++;

                while (queue.Count > 0)
                {
                    int vertex = queue.Dequeue();
                    foreach (int neighbor in adjacencyList[vertex])
                    {
                        if (!visited[neighbor])
                        {
                            queue.Enqueue(neighbor);
                            visited[neighbor] = true;
                        }
                    }
                }
            }
        }

        return count == 1; // Nếu chỉ có một thành phần liên thông, đồ thị liên thông.
    }


}
