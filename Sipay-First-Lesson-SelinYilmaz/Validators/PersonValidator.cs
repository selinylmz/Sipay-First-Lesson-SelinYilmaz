using FluentValidation;
using FluentValidation.Validators;
using Sipay_First_Lesson_SelinYilmaz.Model;
using System;

namespace Sipay_First_Lesson_SelinYilmaz.Validators
{
    public class PersonValidator:AbstractValidator<Person>
    {
        public PersonValidator()
        {
            // Here's FluentValidation
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Staff person name is required.")
                .Length(5, 100).WithMessage("Staff person name must be between 5 and 100 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Staff person lastname is required.")
                .Length(5, 100).WithMessage("Staff person lastname must be between 5 and 100 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Staff person phone number is required.")
                .Matches(@"^\d+$").WithMessage("Invalid staff person phone number. It should contain only numbers.");

            RuleFor(x => x.AccessLevel)
                .InclusiveBetween(1, 5).WithMessage("Staff person access level to system must be between 1 and 5.");

            RuleFor(x => x.Salary)
               .Must((person, salary) => BeValidSalary(person.AccessLevel, salary))
               .WithMessage("Salary is not valid for the current access level.")
               .InclusiveBetween(5000, 50000).WithMessage("Staff person salary must be between 5000 and 50000.");

        }

        //AccessLevel değerlerine göre validasyon
        private bool BeValidSalary(int accessLevel, decimal salary)
        {
            switch (accessLevel)
            {
                case 1:
                    return salary <= 10000;
                case 2:
                    return salary <= 20000;
                case 3:
                    return salary <= 30000;
                case 4:
                    return salary <= 40000;
                default:
                    return false;
            }
        }
    }

}
