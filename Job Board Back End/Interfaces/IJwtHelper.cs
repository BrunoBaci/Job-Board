namespace Job_Board_Back_End.Interfaces
{
    public interface IJwtHElper
    {
        public string GenerateToken(User user);
    }
}
