using BL.Api;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        IBLSuppliers bl;

        public SupplierController(IBL bl)
        {
            this.bl = bl.Suppliers;
        }


        // GET: api/<SupplierController>
        [HttpGet("Get")]
        public IActionResult GetSuppliers()
        {
            return Ok(bl.GetSuppliers());
        }

        [HttpGet("GetSupplierByName/{name}")]
        public IActionResult GetSupplierByName(string name)
        {
            return Ok(bl.GetSupplierByName(name));
        }
        [HttpGet("GetSupplierByLnum/{licensedNum}")]
        public IActionResult GetSupplierByLicensedNum(int licensedNum)
        {
            return Ok(bl.GetSupplierByLicensedNum(licensedNum));
        }
        // GET: api/<SupplierController>
        [HttpGet("DebtForSupllier/{name}")]
        public IActionResult DebtForSupllier(string name)
        {
            return Ok(bl.DebtForSupllier(name));
        }
        // GET api/<SupplierController>/5
        [HttpGet("GetSuppliersForSchool/{id}")]
        public IActionResult GetsOfSchool(int id)
        {
            return Ok(bl.GetSuppliersForSchool(id));
        }

        //// POST api/<SupplierController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<SupplierController>/5
        [HttpPost]
        public IActionResult Create([FromBody] Supplier supplier)
        {
            return Ok(bl.Create(supplier));
        }

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

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.RemoveSupplier(id);
        }
    }
}
