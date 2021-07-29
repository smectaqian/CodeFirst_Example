using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Models
{
    public class User
    {
        /// <summary>
        /// 标识
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    }
}
