using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Models;
using System.Linq;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiaryController : ControllerBase
    {
        private readonly diaryDbContext _context;

        public DiaryController(diaryDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddEntry([FromBody] DiaryEntry entry)
        {
            entry.Id = Guid.NewGuid();
            await _context.DiaryEntries.AddAsync(entry);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEntries()
        {
            var list = await _context.DiaryEntries.ToListAsync();
            return Ok(list);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEntry([FromRoute] Guid id)
        {
            var entry = await _context.DiaryEntries.FindAsync(id);

            if (entry == null)
            {
                return NotFound();
            }
            else
            {
                _context.DiaryEntries.Remove(entry);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }
}
