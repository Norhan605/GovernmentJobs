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
    public class JobAppStatusController : ControllerBase
    {
        private readonly GovernmentJobsContext _context;

        public JobAppStatusController(GovernmentJobsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJopAppStatus()
        {
            var status = await _context.JobAppStatuses.ToListAsync();

            try
            {
                return Ok(status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetJopAppStatusById(int Id)
        {

            var status = await _context.JobAppStatuses.FindAsync(Id);

            try
            {
                if (status == null)
                {
                    return NotFound($"this id = {Id} is not found");
                }

                return Ok(status);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateJopAppStatus([FromBody] JobAppStatusDto newAdJobAppStatus)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (newAdJobAppStatus == null)
                    {
                        return BadRequest();
                    }
                    var status = new JobAppStatus
                    {

                        Status = newAdJobAppStatus.Status,

                    };
                    _context.Add(status);

                    await _context.SaveChangesAsync();
                    newAdJobAppStatus.Id = status.Id;
                    scope.Complete();
                    return Ok(newAdJobAppStatus);
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobAppStatus(int id, JobAppStatusDto updatedJobAppStatus)
        {
            var status = await _context.JobAppStatuses.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (status is not null)
                    {
                        status.Status = updatedJobAppStatus.Status;


                    }

                    await _context.SaveChangesAsync();
                    updatedJobAppStatus.Id = status.Id;
                    scope.Complete();
                    return Ok(updatedJobAppStatus);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobAppStatus(int id)
        {
            var status = await _context.JobAppStatuses.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (status == null)
                    {
                        return NotFound($"this id = {id} is not found");
                    }

                    _context.Remove(status);
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
