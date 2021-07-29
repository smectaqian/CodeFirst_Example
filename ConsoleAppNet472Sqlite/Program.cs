using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteDbContext db = new SQLiteDbContext();

            var sw = new StreamWriter("sql.log");
            db.Database.Log = (s) =>
            {
                sw.WriteLine(s);
            };

            for (int i = 1; i < 10; i++)
            {
                db.User.Add(new User() { name = "name" + i, pwd = "123456" });
            }
            db.SaveChanges();

            SQLiteDbContext db2 = new SQLiteDbContext("SQLiteDb2");
            for (int i = 1; i < 10; i++)
            {
                db2.User.Add(new User() { name = "name" + i, pwd = "123456" });
            }
            db2.SaveChanges();
            Console.WriteLine("run end!");
            Console.ReadKey();
        }
    }
}
