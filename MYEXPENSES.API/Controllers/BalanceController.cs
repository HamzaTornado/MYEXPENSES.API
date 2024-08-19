using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYEXPENSES.API.Dtos;
using MYEXPENSES.API.Models;
using MYEXPENSES.API.Services;

namespace MYEXPENSES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly MyExpensesContext _context;
        private readonly IMapper _mapper;
        private readonly BalanceService _balanceService;

        public BalanceController(MyExpensesContext context, IMapper mapper, BalanceService balanceService)
        {
            _context = context;
            _mapper = mapper;
            _balanceService = balanceService;
        }

        [HttpGet("{month}")]
        public async Task<ActionResult<ReadMonthBalanceDto>> GetMonthBalance(int month)
        {
            var balanceDto =  await _balanceService.GetBalanceByMonth(month);
            return Ok(balanceDto);
        }

        //[HttpGet("getBalanceByMonth/{month}")]
        //public async Task<IActionResult> GetBalanceByMonth(int month)
        //{
        //    try
        //    {
        //        var balanceDto = await _balanceService.GetBalanceByMonth(month);
        //        return Ok(balanceDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it accordingly
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
