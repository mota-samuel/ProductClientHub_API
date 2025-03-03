using FluentValidation;
using ProductClientHub_Communication.Request;

namespace ProductClientHub_API.ÙseCase.Clients.Register
{
    public class RegisterClientValidator : AbstractValidator<RequestClientJson>
    {
        public RegisterClientValidator()
        {
            RuleFor(client => client.Name).NotEmpty().WithMessage("O nome náo pode ser vazio.");
            RuleFor(client => client.Email).EmailAddress().WithMessage("O email náo é valido.");
        }
    }
}
