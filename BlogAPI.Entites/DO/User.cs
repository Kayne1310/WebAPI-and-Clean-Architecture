using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Entites.DO
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Refeshtoken { get; set; }
        public DateTime Exprired { get; set; }
    }
}
