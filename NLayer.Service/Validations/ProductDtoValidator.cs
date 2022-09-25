using FluentValidation;
using NLayer.Core.Dtos;

namespace NLayer.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.Price).InclusiveBetween(1, decimal.MaxValue)
                .WithMessage("{PropertyName} must be greater 0");
            RuleFor(p => p.Stock).InclusiveBetween(1, int.MaxValue)
                .WithMessage("{PropertyName} must be greater 0");
            RuleFor(p => p.CategoryId).InclusiveBetween(1, int.MaxValue)
                .WithMessage("Choose a category");
        }
    }
}
