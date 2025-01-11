using AutoMapper;
using BlogApi.Infrastructure.Repositories;
using BlogAPI.Application.IServices;
using BlogAPI.Entites.DO;
using BlogAPI.Entites.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly ICategory icategory;
        private readonly IMapper mapper;

        public CategoryService(ICategory icategory, IMapper mapper)
        {
            this.icategory = icategory;
            this.mapper = mapper;
        }

        public async Task<Category> createCategory(CategoryViewModel category)
        {

            try
            {
                //map  CategoryViewModel to Catogory
                var CategoryDO = mapper.Map<Category>(category);
                //call repos method create

                var res = await icategory.CreateCategory(CategoryDO);

                //map CatogoryDo to CategoryViewModel


                return res;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> deleteCategory(int id)
        {

            try
            {
                var checkCategoryId = await icategory.GetCategoryById(id);
                if (checkCategoryId == null)
                {
                    return null;
                }

                checkCategoryId = await icategory.DeleteCategory(id);

                return "delete Successful";

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public async Task<List<Category>> getAllCategory()
        {
            // thang nay ko can mapp
            try
            {

                var res = await icategory.GetAll();

                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Category?> getCategoryByName(string name)
        {
            try
            {
                var res = await icategory.getCategoryByName(name);
                if (res == null)
                {
                    return null;

                }
                return res;
            }
            catch (Exception ex)
            {
                throw;

            }

        }

        public async Task<Category?> updateCategory(int id, CategoryViewModel category)
        {
            try
            {

                var checkCategoryId = await icategory.GetCategoryById(id);
                if (checkCategoryId == null)
                {
                    return null;

                }
                var res = await icategory.UpdateCategory(id, mapper.Map<Category>(category));

                return res;
            }
            catch (Exception ex)
            {
                throw ;
            }

        }
    }
}
