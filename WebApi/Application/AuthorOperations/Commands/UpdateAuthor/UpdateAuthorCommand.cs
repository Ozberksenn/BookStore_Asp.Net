

using WebApi.DBOperations;

namespace WebApi.ApplicationAuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId { get; set; }
        private readonly BookStoreDbContext _context;
        public UpdateAuthorViewModel Model { get; set; }
        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar bulunamadı");
            author.Name = Model.Name;
            author.LastName = Model.LastName;
            author.BirthDate = Model.BirthDate;
            _context.SaveChanges();
        }
    }

    public class UpdateAuthorViewModel
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}