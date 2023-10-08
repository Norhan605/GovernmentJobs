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
    public class AdsTypeController : ControllerBase
    {
        private readonly GovernmentJobsContext _context;

        public AdsTypeController(GovernmentJobsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdsType()
        {
            var type = await _context.AdsTypes
                .Select(a => new
                {
                    id=a.Id,
                    type=a.Type,
                    ads=a.Ads
                })
                .ToListAsync();
            try
            {
                
                return Ok(type);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAdsTypeById(int Id)
        {

            var type = await _context.AdsTypes
                .Where(x=>x.Id==Id)
                 .Select(a => new
                 {
                     type = a.Type,
                     ads = a.Ads
                 })
                .FirstOrDefaultAsync();

            try
            {
                if (type == null)
                {
                    return NotFound($"this id = {Id} is not found");
                }

                return Ok(type);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdsType([FromBody] AdsTypeDto newAdType)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (newAdType == null)
                    {
                        return BadRequest();
                    }
                    var type = new AdsType
                    {

                        Type = newAdType.Type

                    };
                    _context.Add(type);

                    await _context.SaveChangesAsync();
                    newAdType.Id = type.Id;
                    scope.Complete();
                    return Ok(newAdType);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdsType(int id, AdsTypeDto updatedAdsType)
        {
            var type = await _context.AdsTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (type is not null)
                    {
                        type.Type = updatedAdsType.Type;

                    }

                    await _context.SaveChangesAsync();
                    updatedAdsType.Id = type.Id;
                    scope.Complete();
                    return Ok(updatedAdsType);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdsType(int id)
        {
            var type = await _context.AdsTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (type == null)
                    {
                        return NotFound($"this id = {id} is not found");
                    }

                    _context.Remove(type);
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






    }
}
