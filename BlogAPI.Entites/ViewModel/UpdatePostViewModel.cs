using BlogAPI.Entites.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Entites.ViewModel
{
    public class UpdatePostViewModel
    {

        public string Title { get; set; }
        public string Content { get; set; }

        public int CategoryID { get; set; }

        public string Status { get; set; }
        public DateTime? UpdatedAt { get; set; } 
    }
}
