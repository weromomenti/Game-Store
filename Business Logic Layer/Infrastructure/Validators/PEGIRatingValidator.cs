using Business_Logic_Layer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Infrastructure.Validators
{
    internal class PEGIRatingValidator : AbstractValidator<PEGIRatingModel>
    {
        public PEGIRatingValidator()
        {
            EnsureInstanceNotNull(nameof(PEGIRatingModel));
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.RatingName).NotEmpty();
        }
    }
}
