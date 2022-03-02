using FluentValidation;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.Business.ValidationRules.FluentValidator
{
   public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(p => p.OrdersId).Empty();
            RuleFor(p => p.OrdersClient).GreaterThanOrEqualTo(1);
         
        }
    }
}
