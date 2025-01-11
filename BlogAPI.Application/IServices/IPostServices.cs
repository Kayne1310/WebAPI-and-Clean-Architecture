using BlogAPI.Entites.DO;
using BlogAPI.Entites.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.IServices
{
    public interface IPostServices
    {

        Task<List<Post>> getAllPost();

        Task<Post> getPostByCategoryName(string categoryName);

        Task<Post?> getPostbyId(int id);

        Task<PostViewModel?> CreatePost(CreatePostViewModel post);

        Task<Post?> updatePost(int id, PostViewModel post);
        Task<int> deletePost(int id);
    }
}
