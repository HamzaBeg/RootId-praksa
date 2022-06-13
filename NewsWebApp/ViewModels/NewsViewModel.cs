using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NewsWebApp.Enumerations;
using NewsWebApp.Models;

namespace NewsWebApp.ViewModels
{
    public class NewsViewModel
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ImeUsera { get; set; }



        public class NewsViewModelProfile : Profile
        {
            public NewsViewModelProfile()
            {
                CreateMap<News, NewsViewModel>();
            }
        }
    }
}
