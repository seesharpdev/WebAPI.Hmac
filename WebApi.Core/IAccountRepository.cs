namespace WebApi.Core
{
    /// <summary>
    /// The AccountRepository interface.
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Returns the hashed password.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetHashedPassword(string username);
    }
}
