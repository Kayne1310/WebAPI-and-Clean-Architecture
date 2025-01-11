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

        public async Task<int> deletePost(int id)
        {
                var res=ipost.getPostbyId(id);
            if (res == null)
            {
                return -1;
            }

            await ipost.deletePost(id);

            return 1;


        }

        public async Task<List<PostViewModel>> getAllPost()
        {
            var listPost=await ipost.getAllPost();

            var newlistPost=new List<PostViewModel>();

            foreach (var post in listPost)
            {
                newlistPost.Add(mapper.Map<PostViewModel>(await ipost.getPostReturnCategory(post)));
            }
            return newlistPost;
        }

        public async Task<List<PostViewModel?>> getPostByCategoryName(string categoryName)
        {
            var res=await ipost.getPostByCategoryName(categoryName);

            var newlistPost=new List<PostViewModel>();
            if(res == null)
            {
                return null;
            }

            foreach(var post in res)
            {
                //convert sang post  nhung co data category
              
                newlistPost.Add(mapper.Map<PostViewModel>(await ipost.getPostReturnCategory(post)));
            }
            return newlistPost;

        }

        public async Task<Post?> getPostbyId(int id)
        {
            //check id post isempty
             var checkPostId=await ipost.getPostbyId(id);
            if (checkPostId == null)
            {
                return null;
            }
            var res =await  ipost.getPostReturnCategory(checkPostId);

            return res;          
        }

        public async Task<Post?> UpdatePostSv(int id, UpdatePostViewModel post)
        {
            //map updateviewModel to postdo
            var postdo = mapper.Map<Post>(post);

            //update post
            var res = await ipost.updatePost(id, postdo);

            if(res == null)
            {
                return null;
            }

             return res;
            


        }
        
         

    }
}
