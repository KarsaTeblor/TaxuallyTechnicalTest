namespace Taxually.TechnicalTest.Model
{
    public class VatRegistrationRequest
    {
        /// <summary>
        /// Company's name to register for VAT
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Company's ID to register for VAT
        /// </summary>
        public string CompanyId { get; set; }
        /// <summary>
        /// Company's country code to register for VAT
        /// </summary>
        public string Country { get; set; }
    }
}
