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
    public class CategoriesController : ControllerBase
    {
        private readonly MyExpensesContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(MyExpensesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Get All Categories GET Method api/Categories
        [HttpGet]
        public async Task<ActionResult<List<ReadCategoryDto>>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            var readcategorydto = _mapper.Map<List<ReadCategoryDto>>(categories);

            return Ok(readcategorydto);
        }

        // Get Category by ID  GET Method api/Categories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadCategoryDto>> GetCategoryById(int id)
        {

            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            var readcategorydto = _mapper.Map<ReadCategoryDto>(category);

            return Ok(readcategorydto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categorydto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            try
            {
                var category = _mapper.Map<Category>(categorydto);
                _context.Add(category);
                await _context.SaveChangesAsync();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> EditCategory(UpdateCategoryDto categorydto,int id)
        {
            if (id != categorydto.Id)
            {
                return BadRequest();
            }
            var existsCategory = await _context.Categories.FirstOrDefaultAsync(cat=>cat.Id==id);

            if(existsCategory == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _mapper.Map(existsCategory,categorydto);
                _context.Categories.Update(existsCategory);
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

            return Ok(categorydto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var existsCategory = await _context.Categories.FirstOrDefaultAsync(cat => cat.Id == id);

            if(existsCategory == null)
            {
                return NotFound();
            }

            try
            {
                _context.Categories.Remove(existsCategory);
                await _context.SaveChangesAsync();
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return  Ok(new Response() { Success = true, Message = $"Category with the ID #{existsCategory.Id} is Deleted" });
        }

    }
}
