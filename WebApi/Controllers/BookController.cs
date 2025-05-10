using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.BookOperations;
using WebApi.BookOperations.CreateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

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
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);

        }
        [HttpGet("linq")]
        public Book GetFindBooks()
        {
            // Linq Çalışması : 

            // Find && First Or Default
            var book = _context.Books.Where(x => x.Id == 1).FirstOrDefault();
            book = _context.Books.Find(1);
            return book ?? new Book();

            // Single Or Default
            // var book = _context.Books.SingleOrDefault(x => x.Title == "Herland");
            // return book ?? new Book();

            // ToList()
            // var book = _context.Books.ToList();
            // return book.FirstOrDefault() ?? new Book();

            // OrderBy
            // var books = _context.Books.OrderBy(x => x.Id).ToList();
            // return books

        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = _context.Books.Where(x => x.Id == id).SingleOrDefault();
            return book ?? new Book();
        }

        // Post : 
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Book added successfully");


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