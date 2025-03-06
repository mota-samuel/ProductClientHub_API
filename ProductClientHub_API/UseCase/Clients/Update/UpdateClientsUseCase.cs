using ProductClientHub_API.Entities;
using ProductClientHub_API.Infraestructure;
using ProductClientHub_API.UseCase.Clients.Update;
using ProductClientHub_Communication.Request;
using ProductClientHub_Communication.Response;
using ProductClientHub_Exceptions.ExceptionsBase;
using System.ComponentModel.DataAnnotations;

namespace ProductClientHub_API.UseCase.Clients.GetAll
{
    public class UpdateClientsUseCase
    {
        public void Execute(Guid clientId, RequestClientJson request)
        {
            Validate(request);

            var dbContext = new ProductClientHubDbContext();
            var entity = dbContext.Clients.FirstOrDefault(client => client.Id.Equals(clientId));

            if (entity is null)
                throw new NotFoundException("Cliente não registrado! Verifique o ID");

            entity.Name = request.Name;
            entity.Email = request.Email;

            dbContext.Clients.Update(entity);
            dbContext.SaveChanges();
           
        }

        private void Validate(RequestClientJson request)
        {
            var validator = new UpdateClientValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
