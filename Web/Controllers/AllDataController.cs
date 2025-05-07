using BL.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServerUI.Controllers
{
    public class AllDataController : Controller
    {
        IBL bl;

        [HttpGet("GetAllData")]
        public IActionResult GetAllData()
        {
            // return Ok((1, 2, 3));
            return Ok((users: bl.Users.GetUsers(), categories: bl.Categories.GetCategories(), schools: bl.Schools.GetSchools(), expenditures: bl.Expenditures.GetExpenditures()
                , suppliers: bl.Suppliers.GetSuppliers()));
        }


    }
}
