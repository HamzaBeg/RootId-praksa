using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NewsWebApp.Models;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Repositories
{
    public interface IAuthenticatiRepository
    {
        Task<LoginViewModel> Login(string email, string password, CancellationToken cancellationToken);
        Task Registration(string email,string password,string ime, string prezime, CancellationToken cancellationToken);
        Task<bool> UserExists(string email, CancellationToken cancellationToken);
        Task<User> LoginAsGuest(CancellationToken cancellationToken);
        Task Logout(int Id,CancellationToken cancellationToken);

    }
}