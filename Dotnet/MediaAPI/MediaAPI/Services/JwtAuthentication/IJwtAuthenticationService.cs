using System.Threading.Tasks;

namespace MediaAPI
{
    public interface IJwtAuthenticationService
    {
        Task<string> AuthenticateAsync(string userName, string password);
    }
}
