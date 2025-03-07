using ProductClientHub_API.Entities;
using ProductClientHub_API.Infraestructure;
using ProductClientHub_Communication.Request;
using ProductClientHub_Communication.Response;
using ProductClientHub_Exceptions.ExceptionsBase;

namespace ProductClientHub_API.ÙseCase.Clients.Register;

public class RegisterClientUseCase
{
    public ResponseShortClientJson Execute(RequestClientJson request)
    {
        Validate(request);

        var dbContext = new ProductClientHubDbContext();
        var entity = new Client
        {
            Name = request.Name,
            Email = request.Email
        };

        dbContext.Clients.Add(entity);
        dbContext.SaveChanges();

        return new ResponseShortClientJson
        {
            Name = entity.Name,
            Id = entity.Id
        };
    }

    private void Validate(RequestClientJson request)
    {

        var validator = new RegisterClientValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}
