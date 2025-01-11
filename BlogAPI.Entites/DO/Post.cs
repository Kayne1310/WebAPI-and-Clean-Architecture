using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Entites.DO
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }

        [ForeignKey(nameof(CategoryID))]
        public Category Category { get; set; }


        public String Status { get; set; } 
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime? UpdatedAt { get; set; }=null;



    }
}
