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
    public class IncomeTypeController : ControllerBase
    {
        private readonly MyExpensesContext _context;
        private readonly IMapper _mapper;

        public IncomeTypeController(MyExpensesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/IncomeTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadIncomeTypeDto>>> GetIncomeTypes()
        {
            var incometypes = await _context.IncomeTypes.ToListAsync();
            if (incometypes == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ReadIncomeTypeDto>>(incometypes));
        }


        // GET: api/IncomeTypes/5

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadIncomeTypeDto>> GetIncomeById(int id)
        {
            var incometype = await _context.IncomeTypes.FindAsync(id);
            if (incometype == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ReadIncomeTypeDto>(incometype));
        }

        // POST: api/IncomeTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> AddIncome(CreateIncomeTypeDto incometypedto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var incometype = _mapper.Map<IncomeType>(incometypedto);
            try
            {
                _context.IncomeTypes.Add(incometype);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return NoContent();
        }
        // PUT: api/IncomeTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> EditIncomeType(int id, UpdateIncomeTypeDto incomedtypeto)
        {
            if (id != incomedtypeto.Id)
            {
                return BadRequest();
            }

            IncomeType incometype = _mapper.Map<IncomeType>(incomedtypeto);

            _context.Entry(incometype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeTypeExists(id))
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


        // DELETE: api/IncomeTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncomeType(int id)
        {
            if (_context.IncomeTypes == null)
            {
                return NotFound();
            }

            var incometype = await _context.IncomeTypes.FindAsync(id);
            if (incometype == null)
            {
                return NotFound();
            }

            try
            {
                _context.IncomeTypes.Remove(incometype);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return NoContent();
        }

        private bool IncomeTypeExists(int id)
        {
            return (_context.IncomeTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }



    }
}
