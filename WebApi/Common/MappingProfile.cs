
using AutoMapper;
using WebApi.BookOperations.CreateBook;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            // ilk obje ikincisine maplenebilir.
        }
    }
}