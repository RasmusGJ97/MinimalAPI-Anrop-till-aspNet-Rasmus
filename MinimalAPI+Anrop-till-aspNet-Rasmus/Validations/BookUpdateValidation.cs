using FluentValidation;
using MinimalAPI_Anrop_till_aspNet_Rasmus.Models.DTOs;

namespace MinimalAPI_Anrop_till_aspNet_Rasmus.Validations
{
    public class BookUpdateValidation : AbstractValidator<BookUpdateDTO>
    {
        public BookUpdateValidation()
        {
            RuleFor(book => book.ID).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(book => book.Title).NotEmpty();
            RuleFor(book => book.Author).NotEmpty();
            RuleFor(book => book.Genre).NotEmpty();
            RuleFor(book => book.Publiced).NotEmpty();
        }
    }
}
