using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYEXPENSES.API.Dtos;
using MYEXPENSES.API.Models;

namespace MYEXPENSES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomesController : ControllerBase
    {
        private readonly MyExpensesContext _context;
        private readonly IMapper _mapper;

        public IncomesController(MyExpensesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Incomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadIncomeDto>>> GetIncomes()
        {
            var incomes = await _context.Incomes.ToListAsync();
          if (incomes == null)
          {
              return NotFound();
          }

            return Ok(_mapper.Map<IEnumerable<ReadIncomeDto>>(incomes));
        }

        // GET: api/Incomes/5

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadIncomeDto>> GetIncomeById(int id)
        {
            var income = await _context.Incomes.FindAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<ReadIncomeDto>(income));
        }

        // POST: api/Incomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddIncome(CreateIncomeDto incomedto)
        {
            if (ModelState.IsValid)
            {
                var incometype = await _context.IncomeTypes.FindAsync(incomedto.IncomeTypeId);
                if (incometype == null)
                {
                    return BadRequest(new Response() { Success = false, Message = "invalid Income Type" });
                }
                var income = _mapper.Map<Income>(incomedto);
                try
                {
                    _context.Incomes.Add(income);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message) ;
                }

                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Incomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> EditIncome(int id, UpdateIncomeDto incomedto)
        {
            if (id != incomedto.Id)
            {
                return BadRequest();
            }

            Income income = _mapper.Map<Income>(incomedto);

            _context.Entry(income).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

       

        // DELETE: api/Incomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            if (_context.Incomes == null)
            {
                return NotFound();
            }
            var income = await _context.Incomes.FindAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            try
            {
                _context.Incomes.Remove(income);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            

            return NoContent();
        }

        private bool IncomeExists(int id)
        {
            return (_context.Incomes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
