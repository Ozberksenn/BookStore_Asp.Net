using FluentValidation;

namespace WebApi.ApplicationAuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty();
            RuleFor(command => command.Model.LastName).NotEmpty();
            RuleFor(command => command.Model.BirthDate).LessThan(DateTime.Now.Date);
        }
    }
}