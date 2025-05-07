using BL.Api;
using BL.Models;
using Common.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServerUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpendituresController : ControllerBase
    {
        IBLExpenditures bl;

        public ExpendituresController(IBL bl)
        {
            this.bl = bl.Expenditures;
        }

        [HttpGet("GetAllExpenditures")]
        public IActionResult GetExpenditures()
        {
            return Ok(bl.GetExpenditures());
        }


        [HttpGet("GetExpenditureById/{id}")]
        public IActionResult GetExpenditureById(int id)
        {
            return Ok(bl.GetExpenditureById(id));
        }

        //////[HttpPost("create/{expenditure}")]
        //////public IActionResult Create([FromBody] Expenditure expenditure)
        //////{
        //////    return Ok(bl.Create(expenditure));

        //////}

        //////// PUT api/<CategoryController>/5
        //////[HttpPut("updateExpenditure/{expenditure},{expenditure}")]
        //////public IActionResult updateExpenditure([FromBody] Expenditure expenditure, int id)
        //////{
        //////    return Ok(bl.updateExpenditure(expenditure, id));
        //////}
        ///


        [HttpPost("create")]
        public IActionResult Create([FromBody] BlExpenditure expenditure)
        {
            return Ok(bl.Create(expenditure));

        }

        // PUT api/<CategoryController>/5
        [HttpPut("updateExpenditure/{expenditure},{id}")]
        public void UpdateExpenditure([FromBody] Expenditure expenditure, int id)
        {
            Ok(bl.UpdateExpenditure(expenditure, id));
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.RemoveExpenditures(id);
        }
    }
}
