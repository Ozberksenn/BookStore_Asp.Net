using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // program cs ilk ayağı kalktığında service provider sayesinde çalışacak.
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    }
                );
                context.Books.AddRange(
                       new Book
                       {
                           Title = "Learn Startup",
                           GenreId = 1,
                           PageCount = 200,
                           publishDate = new DateTime(2001, 06, 12),
                       },
                       new Book
                       {
                           Title = "Herland",
                           GenreId = 2,
                           PageCount = 220,
                           publishDate = new DateTime(2010, 05, 23),
                       },
                       new Book
                       {
                           Title = "Dune",
                           GenreId = 2,
                           PageCount = 540,
                           publishDate = new DateTime(2002, 05, 23),
                       }
                   );
                context.SaveChanges();
                // veritabanına veri ekle


            }
        }
    }
}