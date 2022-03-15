using CountriesOfTheWorld.Core.Models;
using FluentValidation;

namespace CountriesOfTheWorld.Data.Validators.Country;

public class CountryModelValidator : AbstractValidator<CountryModel>
{
    public CountryModelValidator()
    {
        RuleFor(c => c.Name)
            .IsInEnum()
            .NotEmpty()
            .NotNull()
            .Length(1, 30);

        RuleFor(c => c.Area)
            .NotEmpty()
            .NotNull()
            .LessThan(1_000_000_000)
            .GreaterThan(0);
    }
}