using System;
class Cau5
{
    public string? filePath;
    public Graph? graph;
    public Cau5(string? filePath)
    {
        this.filePath = filePath;
        if (this.filePath != null)
        {
            this.graph = new Graph(this.filePath);
        }
        else this.graph = new Graph();
    }

    public void showGraph()
    {
        //Graph graph = new Graph("Graph/cau1-2.txt");
        if (graph == null)
        {
            Console.WriteLine("Khong the doc file");
            return;
        }
        else
        {
            graph.PrintAdjacencyMatrix();
            if (graph.isUndirected)
            {
                Console.WriteLine("Do thi vo huong");
            }
            else
            {
                Console.WriteLine("Do thi co huong");
            }
            Console.WriteLine("So dinh cua do thi: " + graph.GetNumVertices());
            Console.WriteLine("So canh cua do thi: " + graph.GetNumEdges());
            Console.WriteLine("So cap dinh xuat hien canh boi: " + graph.CountParallelEdges());
            Console.WriteLine("So canh khuyen cua do thi: " + graph.CountSelfLoops());
            Console.WriteLine("So dinh co lap: " + graph.IsolatedVertices);
            graph.PrintVertex();
            //Console.WriteLine("Don do thi: " + graph.IsSimpleGraph());
            HandleLogic();

        }


    }
    public void HandleLogic()
    {

        if (graph != null && graph.IsSimpleGraph())
        {
            if (graph.IsEulerGraph())
            {
                Console.WriteLine("Do thi Euler");
            }
            else if (graph.isEulerPath()) {
                Console.WriteLine("Do thi co duong di Euler");
            }
            else
            {
                Console.WriteLine("Khong phai do thi Euler");
            }
            graph.FindEulerPath();
        }
    }
}