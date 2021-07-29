using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class SQLiteDbContext : DbContext
    {
        public SQLiteDbContext() : base("name = SQLiteDb")
        {
        }
        public SQLiteDbContext(string connectionName) : base(connectionName)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //删除表名的复数约定
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //如果模型变化了，那么重建数据库
            Database.SetInitializer(new SqliteDropCreateDatabaseWhenModelChanges<SQLiteDbContext>(modelBuilder));

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> User { get; set; }
    }
}
