using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NewsWebApp.Buisness.Queries;
using NewsWebApp.Repositories;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Buisness.Handlers
{
    public class GetAllUsersQuerieHandler : IRequestHandler<GetAllUsers.Query, List<LoginViewModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQuerieHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<LoginViewModel>> Handle(GetAllUsers.Query query,
            CancellationToken cancellationToken)
        {
            var users = await
                _userRepository.GetAllUsers(cancellationToken);

            return users;
        }

    }
}
