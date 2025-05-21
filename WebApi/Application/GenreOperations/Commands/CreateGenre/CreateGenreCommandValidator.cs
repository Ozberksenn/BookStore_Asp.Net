
using FluentValidation;

namespace WebApi.Application.GenreOperations.CreateGenre
{
    public class CreateGEnreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGEnreCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(4);
        }
    }


}