using FluentValidation;
using ProductClientHub_Communication.Request;

namespace ProductClientHub_API.UseCase.Clients.Update
{
    public class UpdateClientValidator : AbstractValidator<RequestClientJson>
    {
        public UpdateClientValidator()
        {
            RuleFor(client => client.Name).NotEmpty().WithMessage("O nome náo pode ser vazio.");
            RuleFor(client => client.Email).EmailAddress().WithMessage("O email náo é valido.");
        }
    }
}
