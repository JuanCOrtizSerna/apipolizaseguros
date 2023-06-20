using Common.Models;
using MongoDB.Bson;

namespace ApiPolizaSeguros.Tests.Data
{
    public class InsurancePolicyDataBuilder
    {
        public InsurancePolicyDTO Default() {

            return new InsurancePolicyDTO{
                Id = ObjectId.GenerateNewId().ToString(),
                ActiveVehicleInspection = true,
                CarLicensePlate = "ERT987",
                CarModel = "Mazda",
                ClientAddress = "call 28 # 89-20",
                ClientCity = "Medellin",
                ClientDateBirth= DateTime.Now,
                ClientIdentification = "3654654654",
                ClientName = "Jaun ca",
                MaximumPolicyValue= 2000000,
                PolicyCoverage = "Robo, daño por choque, perdida",
                PolicyExpirationDate = DateTime.Now,
                PolicyCreationDate= DateTime.Now,
                PolicyName = "Poliza numero 1",
                PolicyNumber = new Guid().ToString(),
            };
        }
    }
}
