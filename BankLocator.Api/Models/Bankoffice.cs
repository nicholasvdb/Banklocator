namespace BankLocator.Api.Models
{
    public class Bankoffice
    {
        public int BankofficeID { get; set; }
        public string Company { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
