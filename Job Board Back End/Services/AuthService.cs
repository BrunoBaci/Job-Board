using Job_Board_Back_End.Interfaces;

namespace Job_Board_Back_End.Services;

    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        public AuthService(AppDbContext db) => _db = db;

        public User? Authenticate(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash)) return null;
            return user;
        }

        public bool Register(User user, string password)
        {
            if (_db.Users.Any(u => u.Email == user.Email)) return false;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            _db.Users.Add(user);
            _db.SaveChanges();
            return true;
        }
    }

