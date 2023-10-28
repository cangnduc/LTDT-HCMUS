using System;
using System.Collections.Generic;
namespace LTDT_Project
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Bai1 bai1 = new Bai1("graph/eluer.txt");
            bai1.ShowBai1();
            Bai5 bai5 = new Bai5("graph/eluer.txt");
            bai5.ShowBai5();
        }

    }
}