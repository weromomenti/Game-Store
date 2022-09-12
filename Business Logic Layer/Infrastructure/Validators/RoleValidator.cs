using Business_Logic_Layer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Infrastructure.Validators
{
    internal class RoleValidator : AbstractValidator<RoleModel>
    {
        public RoleValidator()
        {
            EnsureInstanceNotNull(nameof(RoleModel));
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.RoleName).NotEmpty();
        }
    }
}
