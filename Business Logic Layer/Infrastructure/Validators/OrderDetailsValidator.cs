using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Infrastructure.Validators
{
    internal class OrderDetailsValidator : AbstractValidator<OrderDetailsModel>
    {
        public OrderDetailsValidator()
        {
            EnsureInstanceNotNull(nameof(OrderDetailsValidator));
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1);
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
        }
    }
}
