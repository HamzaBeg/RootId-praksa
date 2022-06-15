using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using NewsWebApp.Context;
using NewsWebApp.Enumerations;
using NewsWebApp.Models;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Repositories.DefaultRepositories
{
    public class AuthenticatiRepository : IAuthenticatiRepository
    {
        private readonly DbCoreContext _coreDbContext;
        private readonly IMapper _mapper;

        public AuthenticatiRepository(IMapper mapper, DbCoreContext coreDbContext)
        {
            _coreDbContext = coreDbContext;
            _mapper = mapper;
        }
        
        public async Task<LoginViewModel> Login(string email, string password, CancellationToken cancellationToken)
        {
            var listUser = await _coreDbContext.User.Where(x => x.IsActivate == true).ToListAsync(cancellationToken);
          

            var loginUser = await _coreDbContext.User
                 .FirstOrDefaultAsync(x => x.Email == email && x.Password == password, cancellationToken);

            
            if (loginUser != null)
            {
                loginUser.IsActivate = true;
                loginUser.Status = Status.Active;
               
                _coreDbContext.Update(loginUser);
                await _coreDbContext.SaveChangesAsync(cancellationToken);

                if (loginUser.Role == Role.Admin && loginUser.IsActivate == true)
                {
                    return new LoginViewModel()
                    {
                        Email = loginUser.Email,
                        Password = loginUser.Password,
                        Ime = loginUser.Ime,
                        Prezime = loginUser.Prezime,
                        Status = Status.Active.ToString(),
                        Role = Role.Admin.ToString()
                    };
                }

                if (loginUser.Role == Role.User && loginUser.IsActivate == true)
                {
                    return new LoginViewModel()
                    {
                        Email = loginUser.Email,
                        Password = loginUser.Password,
                        Ime = loginUser.Ime,
                        Prezime = loginUser.Prezime,
                        Status = Status.Active.ToString(),
                        Role = Role.User.ToString()
                    };
                }

                if (loginUser.Role == Role.Guest && loginUser.IsActivate == true)
                {
                    return new LoginViewModel()
                    {
                        Email = loginUser.Email,
                        Password = loginUser.Password,
                        Ime = loginUser.Ime,
                        Prezime = loginUser.Prezime,
                        Status = Status.Active.ToString(),
                        Role = Role.Guest.ToString()
                    };

                }
            }
            return null;
        }

        public async Task Registration(string email, string password, string ime, string prezime, CancellationToken cancellationToken)
        {
            User user = new User();
            user.Email = email;
            user.Password = password;
            user.Ime = ime;
            user.Prezime = prezime;

            await _coreDbContext.User.AddAsync(user, cancellationToken);
            await _coreDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> UserExists(string email, CancellationToken cancellationToken)
        {
            if (await _coreDbContext.User.AnyAsync(x => x.Email.ToLower() == email.ToLower(), cancellationToken))
                return true;
            return false;
        }

        public Task<User> LoginAsGuest(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Logout(int Id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
