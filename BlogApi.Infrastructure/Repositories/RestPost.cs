using BlogAPI.Data;
using BlogAPI.Entites.DO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure.Repositories
{
    public class RestPost : IPost
    {
        private readonly BlogAPIContext dbcontext;

        public RestPost(BlogAPIContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<Post> CreatePost(Post post)
        {
            var res = new Post
            {
                CategoryID = post.CategoryID,
                CreatedAt = DateTime.Now,
                Content = post.Content,
                Status = post.Status,
                Title = post.Title,

            };
            await dbcontext.Post.AddAsync(res);
            await dbcontext.SaveChangesAsync();

               res=  await dbcontext.Post.Include(p=>p.Category).FirstOrDefaultAsync(c=>c.Category.ID==res.CategoryID);

            return res;
        }

        public async Task<Post> deletePost(int id)
        {
            var res = await dbcontext.Post.FindAsync(id);

            dbcontext.Post.Remove(res);

            return res;

        }

        public async Task<List<Post>> getAllPost()
        {

            var result = await dbcontext.Post.ToListAsync();
            return result;

        }

        public async Task<Post> getPostByCategoryName(string categoryName)
        {
            var res = await dbcontext.Post.Where(x => x.Category.Name.Contains(categoryName)).FirstOrDefaultAsync();

            return res;


        }

        public async Task<Post> getPostbyId(int id)
        {
            var res = await dbcontext.Post.FindAsync(id);
            return res;
        }

        public async Task<Post> updatePost(int id, Post post)
        {
            var res = await dbcontext.Post.FindAsync(id);

            res.CategoryID = post.CategoryID;
            res.UpdatedAt = DateTime.Now;
            res.Content = post.Content;
            res.Status = post.Status;
            res.Title = post.Title;


            await dbcontext.SaveChangesAsync();
            return res;

        }
    }
}
