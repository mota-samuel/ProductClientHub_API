using FluentValidation;
using ProductClientHub_Communication.Request;

namespace ProductClientHub_API.UseCase.Products.RegisterProductUseCase
{
    public class RegisterProductValidator : AbstractValidator<RequestProductJson>
    {
        public RegisterProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Nome do produto inválido!");
            RuleFor(product => product.Brand).NotEmpty().WithMessage("Nome da marca inválida!");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Não é permitido regisrar esse preco");
        }
    }
}
