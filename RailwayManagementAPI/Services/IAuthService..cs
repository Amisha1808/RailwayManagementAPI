using RailwayManagementAPI.Models;

namespace RailwayManagementAPI.Services
{
    public interface IAuthService
    {
        Task<User> RegisterUser(string username, string password);
        Task<string> Login(string username, string password);
    }
}