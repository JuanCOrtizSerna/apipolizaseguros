using ApiPolizaSeguros.Tests.Data;
using ApiPolizaSeguros.Tests.Fixtures;
using Common.Resources;
using Domain.Services;
using FluentAssertions;
using Xunit;

namespace ApiPolizaSeguros.Tests.Test
{
    public class InsurancePolicyTest : BaseTest<InsurancePolicyFixture>
    {
        /// <summary>
        /// Prueba donde validamos la no vigencia de una poliza de seguros
        /// </summary>
        [Fact]
        public void WhenValidatePolicy_MustBeReturnExceptionError()
        {
            // Arrange
            IInsurancePolicyService service = Fixture.CreateStandardFixture();
            var dto = new InsurancePolicyDataBuilder().Default();

            // Act
            Action act = () => service.ValidateInsurancePolicy(dto);

            // Assert
            act.Should().Throw<Exception>().WithMessage(GlobalResource.InvalidPolicy);
        }

        /// <summary>
        /// Prueba donde validamos la vigencia de una poliza de seguros
        /// </summary>
        [Fact]
        public void WhenValidatePolicy_ShouldNotReturnExceptionError()
        {
            // Arrange
            IInsurancePolicyService service = Fixture.CreateStandardFixture();
            var dto = new InsurancePolicyDataBuilder().Default();
            dto.PolicyExpirationDate = dto.PolicyExpirationDate.AddDays(10);

            // Act
            Action act = () => service.ValidateInsurancePolicy(dto);

            // Assert
            act.Should().NotThrow<Exception>();
        }

        /// <summary>
        /// Prueba donde validamos que no exista una poliza en la base de datos
        /// </summary>
        [Fact]
        public void WhenFindPolicy_ResponseShouldBeNull()
        {
            // Arrange
            IInsurancePolicyService service = Fixture.CreateStandardFixture();
            var dto = new InsurancePolicyDataBuilder().Default();

            // Act
            var response = service.FindById(dto.Id);

            // Assert
            response.Should().BeNull();
        }

        /// <summary>
        /// Prueba donde validamos la existencia de una poliza especifica en la base de datos
        /// </summary>
        [Fact]
        public void WhenFindPolicy_ResponseNoShouldBeNull()
        {
            // Arrange
            IInsurancePolicyService service = Fixture.CreateStandardFixture();
            var dto = new InsurancePolicyDataBuilder().Default();
            dto.PolicyExpirationDate = dto.PolicyExpirationDate.AddDays(10);
            service.Create(dto);

            // Act
            var response = service.FindById(dto.Id);

            // Assert
            response.Should().NotBeNull();
        }

    }
}
