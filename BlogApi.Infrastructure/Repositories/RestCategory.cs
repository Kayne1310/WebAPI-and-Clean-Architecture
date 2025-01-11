using BlogAPI.Data;
using BlogAPI.Entites.DO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure.Repositories
{

    public class RestCategory : ICategory
    {
        private readonly BlogAPIContext context;

        public RestCategory(BlogAPIContext context)
        {
            this.context = context;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            var cate = new Category
            {
                Name = category.Name,
                Description = category.Description,
                CreateAt = DateTime.Now,

            };

            await context.AddAsync(cate);
            context.SaveChanges();

            return cate;


        }

        public async Task<Category?> DeleteCategory(int id)
        {
            var res = await context.Category.FindAsync(id);

           
                context.Category.Remove(res);   
                return res;
           
        }

        public async Task<List<Category>> GetAll()
        {
            var res = await context.Category.ToListAsync();

            return res;
        }

        public async Task<Category> GetCategoryById(int id)
        {
           var res=await context.Category.FindAsync(id);
            return res;
        }

        public async Task<Category> getCategoryByName(string name)
        {
            var res = await context.Category.Where(x => x.Name.Contains(name)).FirstOrDefaultAsync();
            //if (res == null)
            //{

            //    return null;
            //}

            return res;
        }

        public async Task<Category> UpdateCategory(int id, Category category)
        {
            var res = await context.Category.FindAsync(id);
           
            res.Name = category.Name;
            res.Description = category.Description;
            res.UpdateAt = DateTime.Now;

            context.SaveChanges();
            return res;
        }
    }
}
