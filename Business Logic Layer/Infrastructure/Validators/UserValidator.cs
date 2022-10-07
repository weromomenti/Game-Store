using Business_Logic_Layer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Infrastructure.Validators
{
    internal class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            EnsureInstanceNotNull(nameof(UserModel));
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.RoleId).NotEmpty();
        }
    }
}
