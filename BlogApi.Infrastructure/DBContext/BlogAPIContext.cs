using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Entites.DO;

namespace BlogAPI.Data
{
    public class BlogAPIContext : DbContext
    {
        public BlogAPIContext (DbContextOptions<BlogAPIContext> options)
            : base(options)
        {
        }

        public DbSet<BlogAPI.Entites.DO.Post> Post { get; set; }
        public DbSet<Category> Category { get; set; }
        
    }
}
