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
    public class JobDocumentController : ControllerBase
    {
        private readonly GovernmentJobsContext _context;

        public JobDocumentController(GovernmentJobsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetJobDocuments()
        {
            var document = await _context.JobDocuments.ToListAsync();

            try
            {
                return Ok(document);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetJobDocumentId(int Id)
        {
            var document = await _context.JobDocuments.FindAsync(Id);

            try
            {
                if (document == null)
                {
                    return NotFound($"this id = {Id} is not found");
                }

                return Ok(document);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobDocuments([FromBody] JobDocumentsDto newJobDocument)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (newJobDocument == null)
                    {
                        return BadRequest();
                    }
                    var document = new JobDocument
                    {
                        JobProposal = newJobDocument.JobProposal,
                        PersonalImg = newJobDocument.PersonalImg,
                        JobStatusStatement = newJobDocument.JobStatusStatement,
                        Statement = newJobDocument.Statement,
                        AchievementsFile = newJobDocument.AchievementsFile,
                        CareerDevelopment = newJobDocument.CareerDevelopment,
                        NationalId = newJobDocument.NationalId,
                        CriminalRecordId = newJobDocument.CriminalRecordId,
                        Certificate = newJobDocument.Certificate,
                        EmploymentAppId = newJobDocument.EmploymentAppId,
                        TrainingCertificates = newJobDocument.TrainingCertificates,
                        StatementOfEmploymentStatus = newJobDocument.StatementOfEmploymentStatus,
                        
                    };
                    _context.Add(document);

                    await _context.SaveChangesAsync();
                    newJobDocument.Id = document.Id;
                    scope.Complete();
                    return Ok(newJobDocument);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateJobDocument(int id, JobDocumentsDto updatedJobDocument)
        {
            var document = await _context.JobDocuments.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (document is not null)
                    {
                        document.Certificate = updatedJobDocument.Certificate;
                        document.EmploymentAppId = updatedJobDocument.EmploymentAppId;
                        document.CareerDevelopment = updatedJobDocument.CareerDevelopment;
                        document.AchievementsFile = updatedJobDocument.AchievementsFile;
                        document.NationalId = updatedJobDocument.NationalId;
                        document.CriminalRecordId = updatedJobDocument.CriminalRecordId;
                        document.TrainingCertificates = updatedJobDocument.TrainingCertificates;
                        document.JobProposal = updatedJobDocument.JobProposal;
                        document.JobStatusStatement = updatedJobDocument.JobStatusStatement;
                        document.Statement = updatedJobDocument.Statement;
                        document.PersonalImg = updatedJobDocument.PersonalImg;
                        document.StatementOfEmploymentStatus = updatedJobDocument.StatementOfEmploymentStatus;

                    }

                    await _context.SaveChangesAsync();
                    updatedJobDocument.Id = document.Id;
                    scope.Complete();
                    return Ok(updatedJobDocument);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobDocument(int id)
        {
            var document = await _context.JobDocuments.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (document == null)
                    {
                        return NotFound($"this id = {id} is not found");
                    }

                    _context.Remove(document);
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
