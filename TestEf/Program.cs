using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TestEf
{
    class Program
    {
        static void Main(string[] args)
        {
            sdncpEntities se = new sdncpEntities();
            string test = se.admins.FirstOrDefault().Passwd;
            List<admin> list= se.admins.ToList();
           // Console.WriteLine(test);
            foreach (admin item in list)
            {
                Console.WriteLine(item.Username);
            }
            var m2 = se.Database.SqlQuery<admin>("select * from admin where 1=1").ToList();
            foreach (admin item in m2)
            {
                Console.WriteLine(item.id);
            }
            ////增加
            //admin a = new admin();
            //a.id = 15;
            //a.Username = "shinidie";
            //a.Passwd = "123456";
            //a.type = "你大爷";
            //a.managekind = "1";
            //a.content = "闭嘴";
            //se.admins.Add(a);
            //int res = se.SaveChanges();
            //Console.WriteLine(res);

            //更新
            admin t = se.admins.First(a1 => a1.id == 13);
            t.type = "你二大爷";            
            se.SaveChanges();

            int res2 = se.Database.ExecuteSqlCommand("delete from admin where id in (14,15)");
            Console.WriteLine(res2);
        }
    }
}
