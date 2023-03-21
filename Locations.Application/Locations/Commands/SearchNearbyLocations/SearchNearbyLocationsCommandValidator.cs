using FluentValidation;

namespace Locations.Application.Locations.Commands.SearchNearbyLocations
{
    public class SearchNearbyLocationsCommandValidator 
        : AbstractValidator<SearchNearbyLocationsCommand>
    {
        public SearchNearbyLocationsCommandValidator()
        {
            RuleFor(x => x.Latitude)
                .GreaterThanOrEqualTo(-90)
                .LessThanOrEqualTo(90);

            RuleFor(x => x.Longitude)
                .GreaterThanOrEqualTo(-180)
                .LessThanOrEqualTo(180);

            RuleFor(x => x.Category).NotNull();
        }
    }
}

