using BlogAPI.Entites.DO;
using BlogAPI.Entites.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.IServices
{
    public interface ICategoryServices
    {

        Task<List<Category>> getAllCategory();

        Task<Category?> getCategoryByName(string name);


        Task<Category> createCategory(CategoryViewModel category);

        Task<Category?> updateCategory(int id,CategoryViewModel category);
        Task<string ?> deleteCategory(int id);


    }
}
