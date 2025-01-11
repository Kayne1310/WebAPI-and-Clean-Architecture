using BlogAPI.Entites.DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Infrastructure.Repositories
{
    public interface IPost
    {

        Task<List<Post>> getAllPost();

        Task<List<Post>> getPostByCategoryName(string categoryName);

        Task<Post> getPostbyId(int id);

         Task<Post> CreatePost(Post post);

        Task<Post> updatePost(int id,Post post);
        Task<Post> deletePost(int id);

        Task<Post> getPostReturnCategory(Post post);

    }
}
