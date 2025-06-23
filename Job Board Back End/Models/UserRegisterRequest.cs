namespace Job_Board_Back_End.Models
{
    public class UserRegisterRequest
    {

        /// <summary>
        /// The user's email
        /// </summary>
        public required string Email { get; init; }

        /// <summary>
        /// The user's password.
        /// </summary>
        public required string Password { get; init; }


        /// <summary>
        /// The user's username
        /// </summary>
        public required string Username { get; init; }

        /// <summary>
        /// The user's Role.
        /// </summary>
        public required string Role { get; init; }

    }
}
