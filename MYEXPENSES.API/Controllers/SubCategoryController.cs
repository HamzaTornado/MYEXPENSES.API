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
    public class SubCategoryController : ControllerBase
    {
        private readonly MyExpensesContext _context;
        private readonly IMapper _mapper;

        public SubCategoryController(MyExpensesContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<ReadSubCategoryDto>>> GetAllSubCategories()
        {
            var subcategories = await _context.SubCategories.ToListAsync();
            var readdto =_mapper.Map<List<ReadSubCategoryDto> >(subcategories);
            return Ok(readdto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadSubCategoryDto>> GetSubCategoriesById(int id)
        {
            var subcategory = await _context.SubCategories.FindAsync(id);
            if (subcategory == null)
            {
                return BadRequest();
            }

            var readdto = _mapper.Map<ReadSubCategoryDto>(subcategory);
            return Ok(readdto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(CreateSubCategoryDto subCategoryDto)
        {
            var existcategory = await _context.Categories.FindAsync(subCategoryDto.CategoryId);
            if (existcategory == null)
            {
                return BadRequest(new Response() { Success = false, Message = "Category not Found"} );
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubCategory subcategory = _mapper.Map<SubCategory>(subCategoryDto);
            try
            {
                _context.Add(subcategory);
                await _context.SaveChangesAsync();

            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditSubCategory(UpdateSubCategoryDto subCategoryDto, int id)
        {
            if (id != subCategoryDto.Id)
            {
                return BadRequest();
            }

            var existingSubCategory = await _context.SubCategories.FindAsync(id);

            if (existingSubCategory == null)
            {
                return BadRequest(new Response() { Success = false, Message = "Category not Found" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Update properties of existingSubCategory with values from subCategoryDto
            _mapper.Map(subCategoryDto, existingSubCategory);

            try
            {
                _context.SubCategories.Update(existingSubCategory);
                await _context.SaveChangesAsync();


                return Ok(existingSubCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var existsubcategory = await _context.SubCategories.FindAsync(id);
            if (existsubcategory == null)
            {
                return BadRequest(new Response() { Success = false, Message = "Category not Found" });
            }

            try
            {
                _context.SubCategories.Remove(existsubcategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok(new Response() { Success = true, Message = $"SubCategory with the ID #{existsubcategory.Id} is Deleted" });
        }
    }
}
