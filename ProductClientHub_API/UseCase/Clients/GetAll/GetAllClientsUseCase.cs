using ProductClientHub_API.Entities;
using ProductClientHub_API.Infraestructure;
using ProductClientHub_Communication.Response;

namespace ProductClientHub_API.UseCase.Clients.GetAll
{
    public class GetAllClientsUseCase
    {
        public ResponseAllClientsJson Execute()
        {
            var dbContext = new ProductClientHubDbContext();

            var clientes = dbContext.Clients.ToList();

            return new ResponseAllClientsJson
            {
                Clients = clientes.Select(client => new ResponseShortClientJson
                {
                    Id = client.Id,
                    Name = client.Name
                }).ToList()
            };
        }
    }
}
