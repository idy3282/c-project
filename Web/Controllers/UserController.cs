using BL.Api;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IBLUsers bl;

        public UserController(IBL bl)
        {
            this.bl = bl.Users;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(bl.GetUsers());
        }

        [HttpGet("{id}")]

        public IActionResult GetUserById(int id)
        {
            return Ok(bl.GetUserById(id));
        }

        //// GET api/<UsersController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UsersController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UsersController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        //[HttpPost("create/{category}")]
        //public IActionResult Create([FromBody] Category category)
        //{
        //    return Ok(bl.Create(category));

        //}

        //// PUT api/<CategoryController>/5
        //[HttpPut("updateCategory/{categoty},{id}")]
        //public IActionResult UpdateCategory([FromBody] Category category, int id)
        //{
        //    return Ok(bl.UpdateCategory(category, id));
        //}

        [HttpPost("create")]
        public IActionResult Create([FromBody] User user)
        {
            return Ok(bl.Create(user));

        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.RemoveUser(id);
        }
    }
}
