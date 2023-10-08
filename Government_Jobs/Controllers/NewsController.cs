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
    public class NewsController : ControllerBase
    {
        private readonly GovernmentJobsContext _context;

        public NewsController(GovernmentJobsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromBody] NewsDto newNews)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (newNews == null)
                    {
                        return BadRequest();
                    }

                    var news = new News { 
                      LatestNews = newNews.LatestNews,
                      Video = newNews.Video,
                      AdsId = newNews.AdsId,
                      InstructionsApplicants = newNews.InstructionsApplicants,
                      
                    };
                    await _context.AddAsync(news);

                    _context.SaveChanges();
                    newNews.Id = news.Id;
                    scope.Complete();
                    return Ok(newNews);
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            var news = await _context.News.ToListAsync();

            try
            {
                return Ok(news);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetNewsById(int Id)
        {
            var news = await _context.News.Where(x=>x.Id==Id).FirstOrDefaultAsync();

            try
            {
                if (news == null)
                {
                    return NotFound($"this id = {Id} is not found");
                }

                return Ok(news);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNews(int id)
        {
            var news = await _context.News.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (news == null)
                    {
                        return NotFound($"this id = {id} is not found");
                    }

                    _context.Remove(news);
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
        public async Task<IActionResult> UpdateNews(int id, NewsDto updatedNews)
        {
            var news = await _context.News.Where(x => x.Id == id).FirstOrDefaultAsync();
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    if (news is not null)
                    {
                        news.LatestNews = updatedNews.LatestNews;
                        news.InstructionsApplicants= updatedNews.InstructionsApplicants;
                        news.Video= updatedNews.Video;
                        news.AdsId= updatedNews.AdsId;

                    }

                    await _context.SaveChangesAsync();
                    updatedNews.Id = news.Id;
                    scope.Complete();
                    return Ok(updatedNews);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

    }
}
