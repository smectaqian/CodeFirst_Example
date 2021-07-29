using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    #region DbContext（定义）
    public class MysqlDbContext : DbContext
    {
        public MysqlDbContext() : base("name = MysqlDb")
        {
        }
        public MysqlDbContext(string connectionName) : base(connectionName)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //删除约定，复数表名约定 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //如果模型改变了，则自动更新数据库,如果不存在则创建
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MysqlDbContext, MysqlDbConfiguration>());

            base.OnModelCreating(modelBuilder);
        }
        //数据表集合
        public virtual DbSet<User> User { get; set; }
    }
    #endregion

    #region Configuration（配置） CreateDatabaseIfNotExists（如果数据库不存在则创建）
    internal sealed class MysqlDbConfiguration : DbMigrationsConfiguration<MysqlDbContext>
    {
        public MysqlDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            //允许自动迁移数据丢失,默认生成时没有这一项（不添加这一项时，只在添加/删除实体类时自动生成，如果我们删除了实体类的一个属性就会抛出异常）
            AutomaticMigrationDataLossAllowed = true;
            this.SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.EntityFramework.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(MysqlDbContext context)
        {
        }
    }
    #endregion
}
