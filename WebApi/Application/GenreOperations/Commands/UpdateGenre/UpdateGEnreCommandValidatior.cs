

using FluentValidation;

namespace WebApi.Application.GenreOperations.UpdateGenre
{
    public class UpdateGnreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGnreCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(4).When(x => x.Model.Name != string.Empty);
        }
    }


}