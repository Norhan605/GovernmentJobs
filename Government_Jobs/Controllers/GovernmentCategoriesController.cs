using Government_Jobs.Dtos;
using Government_Jobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Government_Jobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GovernmentCategoriesController : ControllerBase
    {
        private readonly GovernmentJobsContext _context;

        public GovernmentCategoriesController(GovernmentJobsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGovernmentCategories()
        {
            var category = await _context.GovernmentCategories
                .Select(x => new
                {
                    id=x.Id,
                    name=x.CategoryName, 
                    ads=x.Ads,
                    categoryReqAds=x.CategoryReqAds
                })
                .ToListAsync();
            try
            {
               
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAllGovernmentCategoryById(int Id)
        {

            var category = await _context.GovernmentCategories.Where(x => x.Id == Id)
                 .Select(x => new
                 {
                     name = x.CategoryName,
                     ads = x.Ads,
                     categoryReqAds = x.CategoryReqAds
                 }).FirstOrDefaultAsync();

            try
            {
                if (category == null)
                {
                    return NotFound($"this id = {Id} is not found");
                }

                return Ok(category);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGovernmentCategory(int id)
        {
            var category = await _context.GovernmentCategories.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (category == null)
                    {
                        return NotFound($"this id = {id} is not found");
                    }

                    _context.Remove(category);
                    await _context.SaveChangesAsync();
                    scope.Complete();
                    return Ok();
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateGovernmentCategory([FromBody] GovernmentCategoryDto newGovernmentCategory)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (newGovernmentCategory == null)
                    {
                        return BadRequest();
                    }
                    var category = new GovernmentCategory
                    {

                        CategoryName = newGovernmentCategory.CategoryName

                    };
                    _context.Add(category);

                    await _context.SaveChangesAsync();
                    newGovernmentCategory.Id = category.Id;
                    scope.Complete();
                    return Ok(newGovernmentCategory);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGovernmentCategory(int id, GovernmentCategoryDto updatedGovernmentCategory)
        {
            var category = await _context.GovernmentCategories.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (category is not null)
                    {
                        category.CategoryName = updatedGovernmentCategory.CategoryName;


                    }

                    await _context.SaveChangesAsync();
                    updatedGovernmentCategory.Id = category.Id;
                    scope.Complete();
                    return Ok(updatedGovernmentCategory);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
