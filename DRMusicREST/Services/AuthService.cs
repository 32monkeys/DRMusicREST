using DRMusicREST.DBContext;
using DRMusicREST.Models;
using Microsoft.AspNetCore.Identity;

namespace DRMusicREST.Services
{
    public class AuthService
    {
        private readonly MusicRecordDbContext _dbContext;

        public AuthService(MusicRecordDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<User?> AuthenticateUserAsync(string username, string password)
        {
            User? user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            var passwordHasher = new PasswordHasher<string>();
            if (user is not null && passwordHasher.VerifyHashedPassword(null, user.Password, password) == PasswordVerificationResult.Success)
            {
                return Task.FromResult(user);
            }
            return Task.FromResult<User?>(null);
            
        }
    }
}
