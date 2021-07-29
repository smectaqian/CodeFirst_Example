using ConsoleApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            MysqlDbContext db = new MysqlDbContext();
            for (int i = 1; i < 1000; i++)
            {
                var u = new User() { name = "name" + i, pwd = "123456" };
                db.User.Add(u);
            }
            db.SaveChanges();

            MysqlDbContext db2 = new MysqlDbContext("MysqlDb2");
            for (int i = 1; i < 1000; i++)
            {
                db2.User.Add(new User() { name = "name" + i, pwd = "123456" });
            }
            db2.SaveChanges();
        }
    }
}
