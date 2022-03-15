using CountriesOfTheWorld.Core.Models;
using FluentValidation;

namespace CountriesOfTheWorld.Data.Validators.Country;

public class CityModelValidator : AbstractValidator<CountryModel>
{
    public CityModelValidator()
    {
        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty()
            .Length(1, 30);
    }
}