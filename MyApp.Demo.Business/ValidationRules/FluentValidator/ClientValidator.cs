using FluentValidation;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.Business.ValidationRules.FluentValidator
{
    public class ClientValidator:AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(p => p.ClientId).Empty();
            RuleFor(p => p.ClientName).Length(2, 50).NotEmpty();
            RuleFor(p => p.ClientAddress).Length(2, 50).NotEmpty();
         
        }
    }
}
