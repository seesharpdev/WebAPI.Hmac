namespace WebApi.Core
{
    /// <summary>
    /// The ValueService interface.
    /// </summary>
    public interface IValueService
    {
        /// <summary>
        /// Returns all the values.
        /// </summary>
        /// <returns>
        /// The <see cref="string[]"/>.
        /// </returns>
        string[] GetValues();

        /// <summary>
        /// Returns a value by Id.
        /// </summary>
        /// <param name="valueId">
        /// The value id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetValue(int valueId);
    }
}