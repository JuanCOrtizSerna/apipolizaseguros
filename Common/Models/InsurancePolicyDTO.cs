
namespace Common.Models
{
    public class InsurancePolicyDTO
    {
        public string Id { get; set; }

        public string PolicyNumber { get; set; }

        public string ClientName { get; set; }

        public string ClientIdentification { get; set; }

        public string ClientCity { get; set; }

        public string ClientAddress { get; set; }

        public DateTime ClientDateBirth { get; set; }

        public DateTime PolicyCreationDate { get; set; }

        public DateTime PolicyExpirationDate { get; set; }

        public string PolicyCoverage { get; set; }

        public float MaximumPolicyValue { get; set; }

        public string PolicyName { get; set; }

        public string CarLicensePlate { get; set; }

        public string CarModel { get; set; }

        public bool ActiveVehicleInspection { get; set; }
    }
}
