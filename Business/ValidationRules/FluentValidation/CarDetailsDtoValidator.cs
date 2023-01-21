using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarDetailsDtoValidator : AbstractValidator<CarDetailsDto>
    {
        public CarDetailsDtoValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.BrandName).MinimumLength(1);
            RuleFor(c => c.ColorName).MinimumLength(1);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(0);

        }
    }
}
