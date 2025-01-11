using BlogAPI.Entites.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure.Repositories
{
    public   interface ICategory
    {

        Task<List<Category>> GetAll();
        Task<Category> getCategoryByName(string name); 

        Task<Category> CreateCategory(Category category);

        Task<Category> UpdateCategory(int id,Category category);

        Task<Category> DeleteCategory(int id);

        Task<Category> GetCategoryById(int id);


    }
}
