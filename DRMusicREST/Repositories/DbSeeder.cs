using DRMusicREST.DBContext;
using DRMusicREST.Models;
using Microsoft.AspNetCore.Identity;

namespace DRMusicREST.Repositories
{
    public static class DbSeeder
    {
        public static void Seed(MusicRecordDbContext context)
        {
            if (!context.Users.Any())
            {
                var passwordHasher = new PasswordHasher<string>();
                var hashedPassword = passwordHasher.HashPassword(null, "1234");
                context.Users.Add(new User { Username = "admin", Password = hashedPassword, Role = "Admin" });
                context.Users.Add(new User { Username = "user", Password = hashedPassword, Role = "User" });
                context.SaveChanges();
            }
        }
    }
}
