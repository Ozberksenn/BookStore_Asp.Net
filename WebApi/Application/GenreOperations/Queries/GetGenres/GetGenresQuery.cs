using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
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

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
        }
    }

    public class GenresViewModel
    {
        // Kullanıcıya veya dış dünyaya (API, UI) sadece gerekli bilgileri göstermek için.
        // örneğin is active değerini göstermek istemiyoruz bu yüzden kullanıcıya sadece bu ikisini döneriz.
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}