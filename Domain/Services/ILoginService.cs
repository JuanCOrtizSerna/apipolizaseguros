using Common.Models;

namespace Domain.Services
{
    public interface ILoginService
    {
        string Authenticate(LoginDTO dto);
    }
}
