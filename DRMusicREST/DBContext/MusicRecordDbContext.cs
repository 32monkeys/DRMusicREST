using DRMusicREST.Models;
using Microsoft.EntityFrameworkCore;

namespace DRMusicREST.DBContext
{
    public class MusicRecordDbContext : DbContext
    {
        public MusicRecordDbContext(DbContextOptions<MusicRecordDbContext> options) : base(options)
        {
        }

        public DbSet<MusicRecord> MusicRecords { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
