using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using MuleReplacementPOC.Services;

namespace MuleReplacementPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTrackerController : ControllerBase
    {
        private readonly ExpenseTrackerService _service;

        public ExpenseTrackerController(ExpenseTrackerService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetExpensesDetails()
        {
            var expenses = await _service.GetExpensesAsync();
            return Ok(expenses);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpensesDetails(int id)
        {
            var expenses = await _service.GetExpensesByIdAsync(id);
            return Ok(expenses);
        }




    }
}
