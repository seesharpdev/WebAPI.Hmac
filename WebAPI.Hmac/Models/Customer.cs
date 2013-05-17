namespace WebAPI.Hmac.Models
{
    /// <summary>
    /// The customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the phones.
        /// </summary>
        public Phone[] Phones { get; set; }
    }
}