using ConsoleApp4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlContext db = new SqlContext();


            List<User> us = new List<User>();
            for (int i = 1; i < 100; i++)
            {
                us.Add(new User() { name = "name" + i, pwd = "123456" });
            }

            db.User.AddRange(us);

            //插入的数据顺序不对，如生成的列表IP自增和序号对不上
            db.SaveChanges();
            ;
            foreach(var item in us)
            {
                Console.WriteLine($"{item.id} {item.name} {item.pwd}");
            }
        }
    }
}
