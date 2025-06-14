using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.BookOperations;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

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
        // [HttpGet("linq")]
        // public Book GetFindBooks()
        // {
        // Linq Çalışması : 
        // Find && First Or Default
        //     var book = _context.Books.Where(x => x.Id == 1).FirstOrDefault();
        //     book = _context.Books.Find(1);
        //     return book ?? new Book();
        // Single Or Default
        // var book = _context.Books.SingleOrDefault(x => x.Title == "Herland");
        // return book ?? new Book();

        // ToList()
        // var book = _context.Books.ToList();
        // return book.FirstOrDefault() ?? new Book();

        // OrderBy
        // var books = _context.Books.OrderBy(x => x.Id).ToList();
        // return books
        // }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);

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
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.BookId = id;
                command.Model = updatedBook;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        // Delete   
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            try
            {
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Book deleted successfully");
        }


    }
}