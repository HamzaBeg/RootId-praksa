using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NewsWebApp.Enumerations;
using NewsWebApp.Models;

namespace NewsWebApp.ViewModels
{
    public class LoginViewModel
    {

        
        public string Email { get; set; }
        public string Password { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Status { get; set; }
        public string Role { get; set; } 

        
        public class LoginViewModelProfile : Profile
        {
            public LoginViewModelProfile()
            {
                CreateMap<User, LoginViewModel>();
            }
        }
    }
}
