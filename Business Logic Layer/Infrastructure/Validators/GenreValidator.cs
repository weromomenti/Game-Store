using Business_Logic_Layer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Infrastructure.Validators
{
    internal class GenreValidator : AbstractValidator<GenreModel>
    {
        public GenreValidator()
        {
            EnsureInstanceNotNull(nameof(GenreModel));
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.GenreName).NotEmpty();
        }
    }
}
