using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Context;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Repositories.DefaultRepositories
{
    public class NewRepository : INewRepository
    {
        private readonly DbCoreContext _dbCoreContext;
        private readonly IMapper _mapper;

        public NewRepository(DbCoreContext dbCoreContext,IMapper mapper)
        {
            _dbCoreContext = dbCoreContext;
            _mapper = mapper;
        }
        public Task AddNews(int userId,string email, string password, string ime, string prezime, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNews(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindNews(int Id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<NewsViewModel>> GetAllNews(CancellationToken cancellationToken)
        {
            var news = await _dbCoreContext.News
                .ProjectTo<NewsViewModel>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return news;
        }

        public Task UpdateNews(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
