using ProductClientHub_API.Entities;
using ProductClientHub_API.Infraestructure;
using ProductClientHub_Communication.Request;
using ProductClientHub_Communication.Response;
using ProductClientHub_Exceptions.ExceptionsBase;

namespace ProductClientHub_API.UseCase.Products.RegisterProductUseCase;

public class RegisterProductUseCase
{
    public ResponseShortProductJson Execute(Guid clientId, RequestProductJson request)
    {
        var dbContext = new ProductClientHubDbContext();
        
        Validate(dbContext, clientId, request);

        var entity = new Product
        { 
            Name = request.Name,
            Price = request.Price,
            Brand = request.Brand,
            ClientId = clientId
            
        };

        dbContext.Products.Add(entity);
        dbContext.SaveChanges();

        return new ResponseShortProductJson
        {
            Name = entity.Name,
            Id = entity.Id
        };
    }

    private void Validate(ProductClientHubDbContext dbContext, Guid clientId , RequestProductJson request)
    {

        var clientIsReal = dbContext.Clients.Any(client => client.Id.Equals(clientId));
        if (!clientIsReal)
            throw new NotFoundException("O cliente não é registrado!");

        var validator = new RegisterProductValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}
