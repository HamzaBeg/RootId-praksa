using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewsWebApp.Buisness.Queries;
using NewsWebApp.Models;
using NewsWebApp.Repositories;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Buisness.Handlers
{
    

    public class LoginQuerieHandler : IRequestHandler<Login.Query, LoginViewModel>
    {
        private readonly IAuthenticatiRepository _authentRepository;

        public LoginQuerieHandler(IAuthenticatiRepository authentRepository)
        {
            _authentRepository = authentRepository;
        }
        public async Task<LoginViewModel> Handle(Login.Query query,
            CancellationToken cancellationToken)
        {
            var loginUser = await
                _authentRepository.Login( query.Email,query.Password,cancellationToken);

            return loginUser;
        }
    }
}
