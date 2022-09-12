using Business_Logic_Layer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Infrastructure.Validators
{
    internal class GameValidator : AbstractValidator<GameModel>
    {
        public GameValidator()
        {
            EnsureInstanceNotNull(nameof(GameModel));
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0m);
        }
    }
}
