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
    public class SpecializationController : ControllerBase
    {
        private readonly GovernmentJobsContext _context;

        public SpecializationController(GovernmentJobsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecialization()
        {
            var type = await _context.Specializations
                .Select(s => new
                {
                   id=s.Id,
                   specialization=s.Specialization1,
                   qualification = s.Qualification
                }).ToListAsync();

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
        public async Task<IActionResult> GetSpecializationById(int Id)
        {

            var specialize = await _context.Specializations.Where(x=>x.Id==Id).FirstOrDefaultAsync();

            try
            {
                if (specialize == null)
                {
                    return NotFound($"this id = {Id} is not found");
                }

                return Ok(specialize);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateSpecialization([FromBody] SpecializationDto newSpecialize)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (newSpecialize == null)
                    {
                        return BadRequest();
                    }
                    var specialize = new Specialization
                    {

                        Specialization1 = newSpecialize.Specialization1,
                        QualificationId = newSpecialize.QualificationId

                    };
                    _context.Add(specialize);

                    await _context.SaveChangesAsync();
                    newSpecialize.Id = specialize.Id;
                    scope.Complete();
                    return Ok(newSpecialize);
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSpacialization(int id, SpecializationDto updatedSpecialize)
        {
            var specialize = await _context.Specializations.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (specialize is not null)
                    {
                        specialize.Specialization1 = updatedSpecialize.Specialization1;


                    }

                    await _context.SaveChangesAsync();
                    updatedSpecialize.Id = specialize.Id;
                    scope.Complete();
                    return Ok(updatedSpecialize);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialization(int id)
        {
            var specialize = await _context.Specializations.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {

                    if (specialize == null)
                    {
                        return NotFound($"this id = {id} is not found");
                    }

                    _context.Remove(specialize);
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
