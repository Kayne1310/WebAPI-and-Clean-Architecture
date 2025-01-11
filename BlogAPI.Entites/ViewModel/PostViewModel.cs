using BlogAPI.Entites.DO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Entites.ViewModel
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Category Category { get; set; }

        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = null;

    }
}
