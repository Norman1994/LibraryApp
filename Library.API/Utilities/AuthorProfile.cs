using AutoMapper;
using Library.API.Models;
using Library.BLL.Dto;
using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Utilities
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorViewModel>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                   .ForMember(dest => dest.FirstName, opt => opt.MapFrom(c => c.FirstName))
                   .ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName))
                   .ForMember(dest => dest.BookName, opt => opt.MapFrom(c => string.Join(", ", c.Books.Select(x => x.Name).ToArray())));

            CreateMap<AuthorModel, AuthorDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                   .ForMember(dest => dest.FirstName, opt => opt.MapFrom(c => c.FirstName))
                   .ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName));

            CreateMap<AuthorDto, Author>()
                   .ForMember(dest => dest.FirstName, opt => opt.MapFrom(c => c.FirstName))
                   .ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName));
        }
    }
}
