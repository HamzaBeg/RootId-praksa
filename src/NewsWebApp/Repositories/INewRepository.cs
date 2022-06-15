using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NewsWebApp.Models;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Repositories
{
    public interface INewRepository
    {
        Task<List<NewsViewModel>> GetAllNews(CancellationToken cancellationToken);
        Task AddNews(int userId,string title, string description, string content, string prezime, CancellationToken cancellationToken);
        Task<User> FindNews(int Id, CancellationToken cancellationToken);
        Task UpdateNews(User user, CancellationToken cancellationToken);
        Task DeleteNews(User user, CancellationToken cancellationToken);
    }
}
