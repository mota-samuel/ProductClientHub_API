using ProductClientHub_API.Infraestructure;
using ProductClientHub_Exceptions.ExceptionsBase;

namespace ProductClientHub_API.UseCase.Clients.Delete;

public class DeleteClientUseCase
{
    public void Execute(Guid Id)
    {
        var dbContext = new ProductClientHubDbContext();

        var entity = dbContext.Clients.FirstOrDefault(client => client.Id.Equals(Id)) ?? throw new NotFoundException("O cliente não é registrado ou o ID está incorreto!");

        dbContext.Clients.Remove(entity);
        dbContext.SaveChanges();
    }
}
