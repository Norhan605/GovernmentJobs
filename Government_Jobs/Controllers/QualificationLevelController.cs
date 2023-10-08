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
    public class QualificationLevelController : ControllerBase
    {

        private readonly GovernmentJobsContext _context;

        public QualificationLevelController(GovernmentJobsContext context)
        {
            _context = context;
        }
       
        [HttpPost]
        public async Task<IActionResult> CreateQualificationLevel([FromBody] QualificationLevelDto newQualificationLevel)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (newQualificationLevel == null)
                    {
                        return BadRequest();
                    }

                    var qualification = new QualificationLevel
                    {
                        QualificationLevel1 = newQualificationLevel.QualificationLevel1
                    };
                    await _context.AddAsync(qualification);

                    _context.SaveChanges();
                    newQualificationLevel.Id = qualification.Id;
                    scope.Complete();
                    return Ok(newQualificationLevel);
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQualificationLevels()
        {
            var qualificationLevels = await _context.QualificationLevels.ToListAsync();

            try
            {
                return Ok(qualificationLevels);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetQualificationLevelById(int Id)
        {

            var qualificationLevel = await _context.QualificationLevels.FindAsync(Id);

            try
            {
                if (qualificationLevel == null)
                {
                    return NotFound($"this id = {Id} is not found");
                }

                return Ok(qualificationLevel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQualificationLevel(int id)
        {
            var qualificationLevel = await _context.QualificationLevels.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (qualificationLevel == null)
                    {
                        return NotFound($"this id = {id} is not found");
                    }

                    _context.Remove(qualificationLevel);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQualificationLevel(int id, QualificationLevelDto updatedQualificationLevel)
        {
            var qualification = await _context.QualificationLevels.FindAsync(id);
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (qualification is not null)
                    {
                        qualification.QualificationLevel1 = updatedQualificationLevel.QualificationLevel1;

                    }


                    await _context.SaveChangesAsync();
                    updatedQualificationLevel.Id = qualification.Id;
                    scope.Complete();
                    return Ok(updatedQualificationLevel);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


    }
}
