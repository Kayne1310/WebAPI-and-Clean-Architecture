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

        [HttpGet("{id:int}")]
        public async Task<ActionResult> getPostById(int id)
        {
            var res=await postServices.getPostbyId(id);
            if (res == null)
            {
                return NotFound("id not found :" + id);
            }

            return Ok(res);

        }

        [HttpGet]
        public async Task<ActionResult> getAllPost() {
            var res=await postServices.getAllPost();

            if(res == null)
            {
                return NotFound ();

            }
            return Ok(res);
        
        }

        [HttpDelete]
        public async Task<ActionResult> deletePostById(int id)
        {
            var res=await postServices.deletePost(id);
            if (res == 1)
            {
                return Ok("delete id" + id + " Successful");
            }
            return BadRequest("id delete not found " + id);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePostController(int id, [FromBody] UpdatePostViewModel post)
        {

            var res=await postServices.UpdatePostSv(id, post);
            if (res == null)
            {
                return NotFound("id not found " + id);
            }
            return Ok(res);
        }

        [HttpGet("name")]
        public async Task<ActionResult> getPostByName(string name)
        {
            var res=await postServices.getPostByCategoryName(name);

            if (res == null)
            {
                return BadRequest("no name " + name);
            }
            return Ok (res);


        }
    }
}
