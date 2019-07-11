namespace Quattro.Domain.Dtos
{
    /// <summary>
    /// User registration data transfer object.
    /// </summary>
    public class UserRegistrationDto
    {
        /// <summary>
        /// User email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Username.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Confirmed password.
        /// </summary>
        public string PasswordConfirmation { get; set; }
    }
}
