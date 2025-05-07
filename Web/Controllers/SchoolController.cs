using BL.Api;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        IBLSchools bl;

        public SchoolController(IBL bl)
        {
            this.bl = bl.Schools;
        }
        [HttpGet]
        public IActionResult GetSchools()
        {
            return Ok(bl.GetSchools());
        }

        [HttpGet("GetSchoolBySymbol/{s}")]
        public IActionResult GetSchoolBySymbol(int s)
        {
            return Ok(bl.GetSchoolBySymbol(s));
        }
        [HttpGet("GetExpenditures/{s}")]
        public IActionResult GetExpendituresOfSchool(int s)
        {
            return Ok(bl.GetExpendituresOfSchool(s));
        }
        [HttpGet("GetDebtOfSchool/{name}")]
        public IActionResult GetDebtOfSchool(string name)
        {
            return Ok(bl.GetDebtOfSchool(name));
        }
        [HttpGet("GetSumOfEpendituresOfSchool/{name}")]
        public IActionResult GetSumOfEpendituresOfSchool(string name)
        {
            return Ok(bl.GetSumOfEpendituresOfSchool(name));
        }
        // GET: api/<SchoolController>
        //[HttpPost("{s}")]
        //public IActionResult SetB(int s)
        //{
        //    return Ok(bl.SetCurrBudget(s));
        //}

        //// GET api/<SchoolController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<SchoolController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<SchoolController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}


        [HttpPost("create")]
        public IActionResult Create([FromBody] School school)
        {
            return Ok(bl.Create(school));

        }

      

        //// PUT api/<CategoryController>/5
        //[HttpPut("updateCategory/{categoty},{id}")]
        //public IActionResult UpdateCategory([FromBody] Category category, int id)
        //{
        //    return Ok(bl.UpdateCategory(category, id));
        //}

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.RemoveSchool(id);
        }
    }
}
