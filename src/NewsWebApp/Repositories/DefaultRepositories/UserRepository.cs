using AutoMapper;
using NewsWebApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Models;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbCoreContext _coreDbContext;
        private readonly IMapper _mapper;

        public UserRepository(IMapper mapper, DbCoreContext coreDbContext, IAuthenticatiRepository authenticatiRepository)
        {
            _coreDbContext = coreDbContext;
            _mapper = mapper;
        }

        public async Task<List<LoginViewModel>> GetAllUsers(CancellationToken cancellationToken)
        {

            var users = await _coreDbContext.User.ProjectTo<LoginViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return users;
        }
        public async Task AddUser(string email, string password, string ime, string prezime, CancellationToken cancellationToken)
        {
            User user = new User();
            user.Email = email;
            user.Password = password;
            user.Ime = ime;
            user.Prezime = prezime;

            await _coreDbContext.User.AddAsync(user, cancellationToken);
            await _coreDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<User> FindUser(int Id, CancellationToken cancellationToken)
        {
            var user = await _coreDbContext.User.FirstOrDefaultAsync(x=>x.UserId == Id,cancellationToken);
           
            return user;
        }

        public async Task UpdateUser(User user, CancellationToken cancellationToken)
        {
            _coreDbContext.Update(user);
            await _coreDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteUser(User user, CancellationToken cancellationToken)
        {
            _coreDbContext.Remove(user);
            await _coreDbContext.SaveChangesAsync(cancellationToken);
              
        }

       
    }
}
