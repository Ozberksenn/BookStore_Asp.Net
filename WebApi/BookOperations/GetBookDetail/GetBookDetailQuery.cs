using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.Common;
using WebApi.DBOperations;
namespace WebApi.BookOperations.GetBookDetail
{
    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidOperationException("Book not founded.");
            BookDetailViewModel vm = new BookDetailViewModel();
            vm.Title = book.Title;
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.publishDate.Date.ToString("dd/MM/yyyy");
            return vm;
        }
    }

    public class BookDetailViewModel
    {
        public string Genre { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }

}