namespace Quattro.Domain.Dtos
{
    /// <summary>
    /// User login data transfer object.
    /// </summary>
    public class UserLoginDto
    {
        /// <summary>
        /// User name or email.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
    }
}
