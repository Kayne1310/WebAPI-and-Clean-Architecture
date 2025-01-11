using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Data;
using BlogAPI.Entites.DO;
using BlogAPI.Application.IServices;
using BlogAPI.Entites.ViewModel;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostServices postServices;

        public PostsController(IPostServices postServices)
        {
            this.postServices = postServices;
        }


        [HttpPost]
        public async Task<ActionResult> createPost([FromBody] CreatePostViewModel post) {

            

            var res= await postServices.CreatePost(post);

            if (res == null)
            {
                return BadRequest("Category not valid");
            }
                return Ok(res);
         

        
        }

    }
}
