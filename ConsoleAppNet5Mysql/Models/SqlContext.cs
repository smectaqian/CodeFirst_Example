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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string strConn = "Data Source=localhost;port=3306;Initial Catalog=TestDB;user id=root;password=abcABC123;";
            optionsBuilder.UseMySql(strConn, ServerVersion.Parse("8.0.20-mysql"));
            //Database.Migrate();
            base.OnConfiguring(optionsBuilder);
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
