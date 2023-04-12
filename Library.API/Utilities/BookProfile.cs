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
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name))
                    .ForMember(dest => dest.IssueYear, opt => opt.MapFrom(c => c.IssueYear))
                    .ForMember(dest => dest.Rating, opt => opt.MapFrom(c => c.Rating))
                    .ForMember(dest => dest.Annotation, opt => opt.MapFrom(c => c.Annotation))
                    .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(c =>  String.Join(", ", c.Authors.Select(x => x.FirstName + " " + x.LastName).ToArray())));

            CreateMap<BookCreateUpdateModel, BookDto>()
                .ForMember(dest => dest.AuthorsIds, opt => opt.MapFrom(c => c.AuthorsIds))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(dest => dest.IssueYear, opt => opt.MapFrom(c => c.IssueYear))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(c => c.Rating))
                .ForMember(dest => dest.Annotation, opt => opt.MapFrom(c => c.Annotation))
                .ForMember(dest => dest.Cover, opt => opt.MapFrom(c => c.Cover))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(c => c.Description))
;

            CreateMap<AuthorModel, Author>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(c => c.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName));


        }
    }
}
