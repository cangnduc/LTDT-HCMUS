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
            string filePath = "graph/Bai3-1.txt";
            Bai1 bai1 = new Bai1(filePath);
            bai1.ShowBai1();
            
            Bai5 bai5 = new Bai5(filePath);
            bai5.ShowBai5();
            Bai4 bai4 = new Bai4(filePath);
            bai4.ShowBai4();
            Bai3 bai3 = new Bai3(filePath);
            bai3.ShowBai3();
        }

    }
}