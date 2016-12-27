using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestEf2
{
    class Program
    {
        static void Main(string[] args)
        {
            njEntities nj = new njEntities();
            string test = nj.sys_user.FirstOrDefault().USERNAME;
            Console.WriteLine(test);
        }
    }
}
