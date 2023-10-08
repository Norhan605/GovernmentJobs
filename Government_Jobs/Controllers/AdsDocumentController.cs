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
    public class AdsDocumentController : ControllerBase
    {
        private readonly GovernmentJobsContext _context;

        public AdsDocumentController(GovernmentJobsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdsDocument()
        {
            var document = await _context.AdsDocuments
                .Select(a => new
                {
                    id=a.Id,
                    document=a.Documents,
                    ads=a.Ads
                })
                .ToListAsync();

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
        public async Task<IActionResult> GetAdsDocumentById(int Id)
        {

            var document = await _context.AdsDocuments
                .Where(x=>x.Id==Id)
                 .Select(a => new
                 {
                     document = a.Documents,
                     ads = a.Ads
                 })
                .FirstOrDefaultAsync();

            try
            {
                if (document == null)
                {
                    return NotFound($"this id = {Id} is not found");
                }

                return Ok(document);
            }
          
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdsDocument(int id)
        {
            var document = await _context.AdsDocuments.Where(x => x.Id == id).FirstOrDefaultAsync();
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

        [HttpPost]

        public async Task<IActionResult> CreateAdsDocument([FromBody] AdsDocumentDto newAdDocument)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (newAdDocument == null)
                    {
                        return BadRequest();
                    }
                    var document = new AdsDocument
                    {

                        Documents = newAdDocument.Documents

                    };
                    _context.Add(document);

                    await _context.SaveChangesAsync();
                    newAdDocument.Id = document.Id;
                    scope.Complete();
                    return Ok(newAdDocument);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdsDocument(int id, AdsDocumentDto updatedAdsDocument)
        {
            var document = await _context.AdsDocuments.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (document is not null)
                    {
                        document.Documents = updatedAdsDocument.Documents;

                    }

                    await _context.SaveChangesAsync();
                    updatedAdsDocument.Id = document.Id;
                    scope.Complete();
                    return Ok(updatedAdsDocument);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


    }
}
