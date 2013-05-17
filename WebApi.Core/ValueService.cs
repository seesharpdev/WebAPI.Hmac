namespace WebApi.Core
{
    /// <summary>
    /// The value service.
    /// </summary>
    public class ValueService : IValueService
    {
        /// <summary>
        /// Returns all the values.
        /// </summary>
        /// <returns>
        /// The <see cref="string[]"/>.
        /// </returns>
        public string[] GetValues()
        {
            return new[] { "value1", "value2" };
        }

        /// <summary>
        /// Returns a value by Id.
        /// </summary>
        /// <param name="valueId">
        /// The value id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetValue(int valueId)
        {
            return "value";
        }
    }
}
