namespace Job_Board_Back_End.Interfaces
{
    public interface IAuthService
    {
        public User? Authenticate(string email, string password);

        public bool Register(User user, string password);
    }
}
