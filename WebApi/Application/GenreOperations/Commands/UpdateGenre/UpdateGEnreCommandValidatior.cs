

using FluentValidation;

namespace WebApi.Application.GenreOperations.UpdateGenre
{
    public class CreateGEnreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public CreateGEnreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).When(x => x.Model.Name != string.Empty);
        }
    }


}