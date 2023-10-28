using System;
using System.Collections.Generic;
namespace LTDT_Project
{
    class Program
    {
        static void Main(string[] args)
        {
           string filePath = "graph/djtra.txt";
            Bai1 bai1 = new Bai1(filePath);
            bai1.ShowBai1();
            Bai5 bai5 = new Bai5(filePath);
            bai5.ShowBai5();
            Bai4 bai4 = new Bai4(filePath);
            bai4.ShowBai4();
        }

    }
}