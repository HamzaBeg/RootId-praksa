using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewsWebApp.Buisness.Commands;
using NewsWebApp.Enumerations;
using NewsWebApp.Repositories;

namespace NewsWebApp.Buisness.Handlers
{
    public class EditUserCommandHandler : IRequestHandler<EditUser.CommandEdit,string>
    {
        private readonly IUserRepository _userRepository;

        public EditUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(EditUser.CommandEdit commandEdit, CancellationToken cancellationToken)
        {
            string message1 = "You have successfully updated user!";
            string message2 = "User not found!";
           
            var user = await _userRepository.FindUser(commandEdit.Id,cancellationToken);
            if (user == null)
            {
                return message2;
            }
            else
            {
                user.Email = commandEdit.Email;
                user.Ime = commandEdit.Ime;
                user.Prezime = commandEdit.Prezime;
                user.Status = commandEdit.Status;
                user.Role = commandEdit.Role;
                if (commandEdit.Status == Status.Active)
                {
                    commandEdit.IsActivate = true;
                    user.IsActivate = commandEdit.IsActivate;
                }
                else
                {
                    commandEdit.IsActivate = false;
                    user.IsActivate = commandEdit.IsActivate;
                }

                await _userRepository.UpdateUser(user,cancellationToken);
                return message1;
            }
        }
    }
}
