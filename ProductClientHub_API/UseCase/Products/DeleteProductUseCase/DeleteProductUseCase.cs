using ProductClientHub_API.Infraestructure;
using ProductClientHub_Exceptions.ExceptionsBase;

namespace ProductClientHub_API.UseCase.Products.DeleteProductUseCase;

public class DeleteProductUseCase
{
    public void Execute(Guid Id)
    {
        var dbContext = new ProductClientHubDbContext();

        var entity = dbContext.Products.FirstOrDefault(product => product.Id.Equals(Id)) ?? throw new NotFoundException("O produto não é registrado ou o ID está incorreto!");

        dbContext.Products.Remove(entity);
        dbContext.SaveChanges();
    }
}
