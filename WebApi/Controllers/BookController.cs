using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.DBOperations;

namespace WepApi.AddController
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        // readonly sadece constructor içerisinde set edilebilirler.

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = _context.Books.OrderBy(x => x.Id).ToList();
            return bookList;
        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = _context.Books.Where(x => x.Id == id).SingleOrDefault();
            return book ?? new Book();
        }

        // Post : 
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);
            if (book is not null)
            {
                return BadRequest("Book already exists");
            }
            else
            {
                _context.Books.Add(newBook);
                _context.SaveChanges();
                return Ok("Book added successfully");
            }
        }

        // Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
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
                _context.SaveChanges();
                return Ok("Book updated successfully");
            }
        }

        // Delete   
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is null)
            {
                return BadRequest("Book not found");
            }
            else
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Ok("Book deleted successfully");
            }
        }

    }
}