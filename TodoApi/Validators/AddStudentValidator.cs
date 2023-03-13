
using FluentValidation;
using TodoApi.Extensions;
using TodoApi.Models;

namespace TodoApi.Validators 
{

    public class AddStudentValidator : AbstractValidator<AddStudentInputModel>
    {
        public AddStudentValidator()
        {
            RuleFor(y => y.FullName)
                .NotEmpty()
                    .WithMessage("Full name must not be null or empty")
                .MaximumLength(50)
                    .WithMessage("Full name lenghy muest be less than 50")
                .MinimumLength(5)
                    .WithMessage("Full name lenght must be more than 5");
                
            RuleFor(x => x.BirthDate)
                .LessThan(DateTime.Now.Date)
                    .WithMessage("Birth date must be older than today");

             RuleFor(x => x.Document)
                .Must(x => x.IsValidDocument())
                    .WithMessage("Document is invalid");

        }
    }
}