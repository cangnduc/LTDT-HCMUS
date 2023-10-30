using System;
using System.Collections.Generic;
namespace LTDT_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filePath = "graph/djtra.txt";
            //string filePath = "graph/djtra-3.txt";
            //string filePath = "graph/Bai3-1.txt";
            //string filePath = "graph/Bai2-2.txt";
            string filePath = "graph/eluer.txt";
            Bai1 bai1 = new Bai1(filePath);
            bai1.ShowBai1();
            Console.WriteLine("*********************************");
            Bai2 bai2 = new Bai2(filePath);
            bai2.ShowBai2();
            Console.WriteLine("*********************************");
            Bai3 bai3 = new Bai3(filePath);
            bai3.ShowBai3();
            Console.WriteLine("*********************************");
            Bai4 bai4 = new Bai4(filePath);
            bai4.ShowBai4();
            Console.WriteLine("*********************************");
            Bai5 bai5 = new Bai5(filePath);
            bai5.ShowBai5();
        }

    }
}