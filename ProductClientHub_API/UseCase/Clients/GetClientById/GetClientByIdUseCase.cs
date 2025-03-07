using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProductClientHub_API.Infraestructure;
using ProductClientHub_Communication.Response;
using ProductClientHub_Exceptions.ExceptionsBase;

namespace ProductClientHub_API.UseCase.Clients.GetClientById;

public class GetClientByIdUseCase
{
    public ResponseClientJson Execute(Guid Id)
    {
        var dbContext = new ProductClientHubDbContext();

        var entity = dbContext
            .Clients
            .Include(client => client.Products)
            .FirstOrDefault(client => client.Id.Equals(Id));

        if (entity is null)
            throw new NotFoundException("O cliente não foi encontrado, verifique o ID novamente!");

        return new ResponseClientJson
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email,
            Products = entity.Products.Select(products => new ResponseShortProductJson
            {
                Id = products.Id,
                Name = products.Name
            }).ToList()
        };

    }
}
