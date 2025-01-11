using BlogAPI.Entites.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Entites.ViewModel
{
    public class CreatePostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public String Status { get; set; }
     
    }
}
