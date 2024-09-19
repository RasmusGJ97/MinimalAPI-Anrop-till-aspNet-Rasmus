using FluentValidation;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Models.DTOs;

namespace MinimalAPI_Anrop_till_aspNet_Rasmus.Validations
{
    public class BookCreateValidation : AbstractValidator<BookCreateDTO>
    {
        public BookCreateValidation()
        {
            RuleFor(book => book.Title).NotEmpty();
            RuleFor(book => book.Author).NotEmpty();
            RuleFor(book => book.Genre).NotEmpty();
            RuleFor(book => book.Publiced).NotEmpty();
        }
    }
}
