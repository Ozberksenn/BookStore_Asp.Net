using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _context; // BookStoreDbContext,  uygulama ile veritabanı arasındaki köprüdür.

        public readonly IMapper _mapper; // IMapper, AutoMapper adlı bir kütüphaneye aittir. Görevi: Bir sınıfı (model, entity vs.) başka bir sınıfa dönüştürmek.

        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            // bir tane veri dönmesini beklediğim içinn single or default kullandım.
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Kitap Türü Bulunamadı!");
            }
            return _mapper.Map<GenreDetailViewModel>(genre);
        }
    }

    public class GenreDetailViewModel
    {
        // dökümanda açıkla.
        // Kullanıcıya veya dış dünyaya (API, UI) sadece gerekli bilgileri göstermek için.
        // örneğin is active değerini göstermek istemiyoruz bu yüzden kullanıcıya sadece bu ikisini döneriz.
        public int Id { get; set; }
        public string Name { get; set; }

    }
}