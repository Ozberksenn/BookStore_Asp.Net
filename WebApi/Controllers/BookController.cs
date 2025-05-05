using Microsoft.AspNetCore.Mvc;
using WebApi;

namespace WepApi.AddController
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>(){

            new Book {
                Id = 1,
                Title = "Learn Startup",
                GenreId = 1,
                PageCount = 200,
                publishDate = new DateTime(2001,06,12),
            },
            new Book {
                Id = 2,
                Title = "Herland",
                GenreId = 2,
                PageCount = 220,
                publishDate = new DateTime(2010,05,23),
            },
             new Book {
                Id = 3,
                Title = "Dune",
                GenreId = 2,
                PageCount = 540,
                publishDate = new DateTime(2002,05,23),
            }
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList();
            return bookList;
        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(x => x.Id == id).SingleOrDefault();
            return book ?? new Book();
        }

        // Post : 
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
            if (book is not null)
            {
                return BadRequest("Book already exists");
            }
            else
            {
                BookList.Add(newBook);
                return Ok("Book added successfully");
            }
        }

        // Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return BadRequest("Book not found");
            }
            else
            {
                book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
                book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
                book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
                book.publishDate = updatedBook.publishDate != default ? updatedBook.publishDate : book.publishDate;
                return Ok("Book updated successfully");
            }
        }

        // Delete   
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookList.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return BadRequest("Book not found");
            }
            else
            {
                BookList.Remove(book);
                return Ok("Book deleted successfully");
            }
        }

    }
}