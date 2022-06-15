using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewsWebApp.Buisness.Commands;
using NewsWebApp.Models;
using NewsWebApp.Repositories;

namespace NewsWebApp.Buisness.Handlers
{
    public class RegistrationCommandHandler : IRequestHandler<Registration.CommandRegister, string>
    {
        private readonly IAuthenticatiRepository _authenticatiRepository;

        public RegistrationCommandHandler(IAuthenticatiRepository authenticatiRepository)
        {
            _authenticatiRepository = authenticatiRepository;
        }

        
        public async Task<string> Handle(Registration.CommandRegister command, CancellationToken cancellationToken)
        {
            string message1 = "You have successfully registered!";
            string message2 = "User already exist!";
            if (await _authenticatiRepository.UserExists(command.Email,cancellationToken) == true)
            { 
                return message2;
            }
            await _authenticatiRepository.Registration(command.Email, command.Password, command.Ime,
                command.Prezime, cancellationToken);
            return message1;

        }
    }
}
