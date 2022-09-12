using Business_Logic_Layer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Infrastructure.Validators
{
    internal class CommentValidator : AbstractValidator<CommentModel>
    {
        public CommentValidator()
        {
            EnsureInstanceNotNull(nameof(CommentModel));
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.GameId).NotEmpty();
            RuleFor(x => x.Text).NotEmpty();
            RuleFor(x => x.Created).LessThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.Likes).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Dislikes).GreaterThanOrEqualTo(0);
        }
    }
}
