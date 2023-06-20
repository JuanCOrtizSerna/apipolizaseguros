using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class InsurancePolicy
    {
        [Key]
        [BsonId]
        public ObjectId Id { get; set; }

        public string PolicyNumber { get; set; }

        public string ClientName { get; set; }

        public string ClientIdentification{ get; set; }

        public string ClientCity { get; set; }

        public string ClientAddress { get; set; }

        public DateTime ClientDateBirth { get; set; }

        public DateTime PolicyCreationDate { get; set; }

        public DateTime PoliceExpirationDate { get; set; }

        public string PolicyCoverage { get; set; }

        public float MaximumPolicyValue { get; set; }

        public string PolicyName { get; set; }

        public string CarLicensePlate { get; set; }

        public string  CarModel { get; set; }

        public bool ActiveVehicleInspection { get; set; }
    }
}
