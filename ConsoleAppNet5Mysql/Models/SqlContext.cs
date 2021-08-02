using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Logging.Console;
namespace ConsoleApp4.Models
{
    public class SqlContext : DbContext
    {
        private static bool _created = false;
        public SqlContext() : base()
        {
            if (!_created)
            {
                _created = true;
                //Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string strConn = "Data Source=localhost;port=3306;Initial Catalog=CodefirstTestDB;user id=root;password=abcABC123;sslMode=None;";
            options.UseMySql(strConn, ServerVersion.Parse("8.0.20-mysql"));

            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseLoggerFactory(MyLoggerFactory).UseSqlite(strConn);
            //    //启用敏感数据记录,可以显示提交的参数
            //    optionsBuilder.EnableSensitiveDataLogging();
            //}

            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
        }

        public DbSet<User> User { get; set; }
    }

    public class User
    {
        /// <summary>
        /// 标识
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required, MaxLength(255)]
        public string name { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required, MaxLength(255)]
        public string RealName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required, MaxLength(255)]
        public string pwd { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int sex { get; set; }
    }
}
