using Microsoft.EntityFrameworkCore;
using webApi.Models;

namespace webApi.Data
{
    public class diaryDbContext : DbContext
    {
        public diaryDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        
    }
}
