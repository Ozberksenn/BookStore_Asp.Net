using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries
{
    public class GetGenresQuery
    {
        public readonly BookStoreDbContext _context; // BookStoreDbContext,  uygulama ile veritabanı arasındaki köprüdür.

        public readonly IMapper _mapper; // IMapper, AutoMapper adlı bir kütüphaneye aittir. Görevi: Bir sınıfı (model, entity vs.) başka bir sınıfa dönüştürmek.

        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}