using AutoMapper;
using BlogApi.Infrastructure.Repositories;
using BlogAPI.Application.IServices;
using BlogAPI.Entites.DO;
using BlogAPI.Entites.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services
{
    public class PostService : IPostServices
    {
        private readonly IMapper mapper;
        private readonly IPost ipost;
        private readonly ICategory icategory;

        public PostService(IMapper mapper, IPost ipost,ICategory icategory)
        {
            this.mapper = mapper;
            this.ipost = ipost;
            this.icategory = icategory;
        }

        public async Task<PostViewModel?> CreatePost(CreatePostViewModel post)
        {
            //map top post
            try
            {
                var categoryExists = await icategory.GetCategoryById(post.CategoryId);

                if (categoryExists==null)
                {
                    throw new ArgumentException("Category không hợp lệ.");
                }

                var result = mapper.Map<Post>(post);

                var response = await ipost.CreatePost(result);
                if (response == null)
                {
                    return null;
                }


                var postviewmodel = mapper.Map<PostViewModel>(response);

                return postviewmodel;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public Task<int> deletePost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> getAllPost()
        {
            throw new NotImplementedException();
        }

        public Task<Post> getPostByCategoryName(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<Post?> getPostbyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post?> updatePost(int id, PostViewModel post)
        {
            throw new NotImplementedException();
        }
    }
}
