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
    public class JobGroupController : ControllerBase
    {
        private readonly GovernmentJobsContext _context;

        public JobGroupController(GovernmentJobsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJopGroups()
        {
            var group = await _context.JobGroups
                .Select(x => new
                {
                    id=x.Id,
                    jobGroup=x.JobGroup1,
                    jobs=x.Jobs,
                    qualitativeGroups=x.QualitativeGroups
                })
                .ToListAsync();
            try
            {

                return Ok(group);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetJopGroupById(int Id)
        {

            var group = await _context.JobGroups
                .Where(x => x.Id == Id)
                   .Select(x => new
                   {
                       jobGroup = x.JobGroup1,
                       jobs = x.Jobs,
                       qualitativeGroups = x.QualitativeGroups
                   }).FirstOrDefaultAsync();

            try
            {
                if (group == null)
                {
                    return NotFound($"this id = {Id} is not found");
                }

                return Ok(group);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobGroup([FromBody] JobGroupDto newJobGroup)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (newJobGroup == null)
                    {
                        return BadRequest();
                    }
                    var group = new JobGroup
                    {

                        JobGroup1 = newJobGroup.JobGroup1

                    };
                    _context.Add(group);

                    await _context.SaveChangesAsync();
                    newJobGroup.Id = group.Id;
                    scope.Complete();
                    return Ok(newJobGroup);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobGroup(int id, JobGroupDto updatedJobGroup)
        {
            var group = await _context.JobGroups.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (group is not null)
                    {
                        group.JobGroup1 = updatedJobGroup.JobGroup1;

                    }

                    await _context.SaveChangesAsync();
                    updatedJobGroup.Id = group.Id;
                    scope.Complete();
                    return Ok(updatedJobGroup);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobGroup(int id)
        {
            var group = await _context.JobGroups.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (group == null)
                    {
                        return NotFound($"this id = {id} is not found");
                    }

                    _context.Remove(group);
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
