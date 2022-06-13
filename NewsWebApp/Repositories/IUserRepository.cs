using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NewsWebApp.Models;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Repositories
{
    public interface IUserRepository
    {
        Task<List<LoginViewModel>> GetAllUsers(CancellationToken cancellationToken);
        Task AddUser(string email, string password, string ime, string prezime, CancellationToken cancellationToken);
        Task<User> FindUser(int Id, CancellationToken cancellationToken);
        Task UpdateUser(User user, CancellationToken cancellationToken);
        Task DeleteUser(User user, CancellationToken cancellationToken);
    }
}
