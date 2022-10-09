using Business_Logic_Layer.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Infrastructure.Validators
{
    public class OrderValidator : AbstractValidator<OrderModel>
    {
        public OrderValidator()
        {
            EnsureInstanceNotNull(nameof(OrderModel));
            RuleFor(x => x.OrderDate).LessThanOrEqualTo(DateTime.Now);
        }
    }
}
