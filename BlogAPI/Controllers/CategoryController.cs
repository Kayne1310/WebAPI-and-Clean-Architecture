using BlogAPI.Application.IServices;
using BlogAPI.Entites.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
        }
        [HttpPost]
        public async Task<ActionResult> createCategory(CategoryViewModel categoryViewModel)
        {
            var res = await categoryServices.createCategory(categoryViewModel);

            return Ok(res);

        }

        [HttpGet]
        public async Task<ActionResult> listCategories()
        {
            var res = await categoryServices.getAllCategory();

            return Ok(res);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> getCategoryByName([FromRoute]string name)
        {

            var res = await categoryServices.getCategoryByName(name);

            if (res == null)
            {
                return NotFound();

            }

            return Ok(res);

        }

        [HttpPut]
        public async Task<ActionResult> updateCategory(int id, CategoryViewModel categoryViewModel)
        {

            var res=await categoryServices.updateCategory(id, categoryViewModel);
            if(res == null)
            {
                return NotFound("Id not found"+id);

            }
            return Ok(res);

        }

        [HttpDelete]
        public async Task<ActionResult> deleteCategory(int id)
        {
            var res= await categoryServices.deleteCategory(id);
            if(res == null)
            {
                return NotFound("not found id" + id);
            }
            return Ok(res);

        }

        

        

       

    }
}
