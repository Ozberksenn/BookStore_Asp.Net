using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

// context kavramı : DbContext, Entity Framework’te veritabanı ile uygulaman arasında köprü görevi görür.
// C#’ta bir Book sınıfı tanımlarsın, EF bu Book nesnelerini alır ve veritabanındaki tablolarla eşleştirir.
// DbContext sayesinde şunları yapabilirsin: Veri çekme , veri ekleme , veri güncelleme , veri silme , LİNQ ile sorgu yazma.

namespace WebApi.DBOperations
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}