using AutoMapper;
using Library.Application.Features.Books.Commands.CreateBook;
using Library.Application.Features.Books.Commands.UpdateBookCommand;
using Library.Application.Features.Books.Queries;
using Library.Domain.Entities;
using static Library.Application.Features.Books.Queries.GetBookByIdQuery;
using static Library.Application.Features.Books.Queries.GetBooksListQuery;

namespace Library.Application.Features.Books.Mapping
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<CreateBookCommand, Book>().ReverseMap();
            CreateMap<UpdateBookCommand, Book>().ReverseMap();

            CreateMap<Book, CreateBookCommandDto>().ForCtorParam("MemberName", opt => opt.MapFrom(src => src.BorrowRecords.Where(x => x.ReturnedAt == null)
            .Select(x => $"{x.Member.FirstName} {x.Member.LastName}")
            .FirstOrDefault() ?? "Müsait"));

            CreateMap<Book, GetBooksListQueryDto>().ForCtorParam("MemberName", opt => opt.MapFrom(src => src.BorrowRecords.Where(x => x.ReturnedAt == null).Select(x => $"{x.Member.FirstName} {x.Member.LastName}").FirstOrDefault() ?? "Müsait"));
        }
    }
}