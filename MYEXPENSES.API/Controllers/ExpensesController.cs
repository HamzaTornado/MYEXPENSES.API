using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYEXPENSES.API.Dtos;
using MYEXPENSES.API.Models;
using System.Runtime.CompilerServices;

namespace MYEXPENSES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly MyExpensesContext _context;
        private readonly IMapper _mapper;

        public ExpensesController(MyExpensesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadExpenseDto>>> GetThisMonthExpenses()
        {
            int month = DateTime.Now.Month;
            IEnumerable<Expense> expensesmonth;
            try
            {
                expensesmonth = await _context.Expenses.Where(ex => ex.Month == month).Include(s => s.SubCategory).ToListAsync();
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(_mapper.Map<IEnumerable<ReadExpenseDto>>(expensesmonth));

        }
        [HttpGet("GetAllExpensesByMonth/{month}")]
        public async Task<ActionResult<IEnumerable<ReadExpenseDto>>> GetAllExpensesByMonth(int month)
        {
            
            IEnumerable<Expense> expensesmonth;
            try
            {
                expensesmonth = await _context.Expenses.Where(ex => ex.Month == month).Include(s => s.SubCategory).ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(_mapper.Map<IEnumerable<ReadExpenseDto>>(expensesmonth));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            Expense existexpense;
            try
            {
                existexpense = await _context.Expenses.FindAsync(id);

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
            if (existexpense == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ReadExpenseDto>(existexpense));
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(CreateExpenseDto expenseDto)
        {
            if (ModelState.IsValid)
            {
                var subcategory = await _context.SubCategories.FindAsync(expenseDto.SubCategoryId);
                if(subcategory == null) {
                    return BadRequest(new Response() { Success = false, Message = "invalid Sub-Category"});
                }
                try
                {
                    Expense expense = _mapper.Map<Expense>(expenseDto);
                    _context.Expenses.Add(expense);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }

                return NoContent();
            }

            return BadRequest(ModelState);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditExpense(UpdateExpenseDto expenseDto,int id)
        {
            if (id != expenseDto.Id)
            {
                return BadRequest();
            }
            var existexpense = await _context.Expenses.FindAsync(id);
            if (existexpense == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                try
                {
                    _mapper.Map(expenseDto, existexpense);

                    _context.Expenses.Update(existexpense);
                    await _context.SaveChangesAsync();
                    var changes = _context.SaveChanges();
                    if (changes < 0)
                    {
                        return BadRequest(new Response() { Success = false, Message = $"Failed to update" });
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
                return Ok(expenseDto);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var existexpense =await _context.Expenses.FindAsync(id);

            if(existexpense == null)
            {
                return NotFound();
            }
            try
            {
                _context.Expenses.Remove(existexpense);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(new Response() { Success = true,Message = $"Expense with the ID #{existexpense.Id} is Deleted" }) ;
        }


    }
}
