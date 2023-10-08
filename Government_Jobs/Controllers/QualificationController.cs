using Government_Jobs.Dtos;
using Government_Jobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using static System.Reflection.Metadata.BlobBuilder;

namespace Government_Jobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationController : ControllerBase
    {
        private readonly GovernmentJobsContext _context;
       
        public QualificationController(GovernmentJobsContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllQualifications()
        {
            var qualification = await _context.Qualifications
                  .Select(x => new
                  {
                      id = x.Id,
                      qualification1 = x.Qualification1,
                      graduationYear = x.GraduationYear,
                      persentage = x.Persentage,
                      specialization = x.Specializations,
                      grade = x.Grade,
                      qualificationLevel = x.QualificationLevel,
                  }

                ).ToListAsync();

            try
            {
                return Ok(qualification);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        //public async Task<IActionResult> GetAllQualifications()
        //{
        //    var qualification = await _context.Qualifications
        //        .Include(x=>x.Specializations)
        //     .ToListAsync();

        //    try
        //    {
        //        return Ok(qualification);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetQualificationById(int Id)
        {

            var qualification = await _context.Qualifications
                .Where(x => x.Id == Id)
                .Select(x => new
                {
                    qualification1 = x.Qualification1,
                    graduationYear = x.GraduationYear,
                    persentage = x.Persentage,
                    specialization = x.Specializations,
                    grade = x.Grade,
                    qualificationLevel = x.QualificationLevel,
                }

                ).FirstOrDefaultAsync();

            try
            {
                if (qualification == null)
                {
                    return NotFound($"this id = {Id} is not found");
                }

                return Ok(qualification);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteQualification(int id)
        {
            var qualification = await _context.Qualifications.Where(x=>x.Id==id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (qualification == null)
                    {
                        return NotFound($"this id = {id} is not found");
                    }

                    _context.Remove(qualification);
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
        public async Task<IActionResult> CreateQualification([FromBody] QualificationDto newQualification)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (newQualification == null)
                    {
                        return BadRequest();
                    }
                    var qualification = new Qualification
                    {
                        GraduationYear = newQualification.GraduationYear,
                        Persentage = newQualification.Persentage,
                        Qualification1 = newQualification.Qualification1,
                        QualificationLevelId = newQualification.QualificationLevelId,
                        GradeId = newQualification.GradeId,

                    };
                    _context.Add(qualification);

                    await _context.SaveChangesAsync();
                    newQualification.Id = qualification.Id;
                    scope.Complete();
                    return Ok(newQualification);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPut("{id}")]

        public async Task <IActionResult> UpdateQualification(int id, QualificationDto updatedQualification)
        {
            var qualification = await _context.Qualifications.Where(x=>x.Id==id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (qualification is not null)
                    {
                        qualification.GraduationYear = updatedQualification.GraduationYear;
                        qualification.Qualification1 = updatedQualification.Qualification1;
                        qualification.QualificationLevelId = updatedQualification.QualificationLevelId;
                        qualification.Persentage = updatedQualification.Persentage;
                        qualification.GradeId = updatedQualification.GradeId;

                    }

                    await _context.SaveChangesAsync();
                    updatedQualification.Id = qualification.Id;
                    scope.Complete();
                    return Ok(updatedQualification);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


    }
}
