
using AutoMapper;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.GenreOperations.Queries;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.BookOperations;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            // ilk obje ikincisine maplenebilir.
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenresViewModel>(); // dökümanda açıkla. Genre yi GenreViewModel e dönüştürdük.
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<Author, AuthorsViewModel>();

        }
    }
}