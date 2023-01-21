using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //Araba varlığımız icin gerekli kurallar bulunmaktadır.
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.CarName).MinimumLength(2);
            RuleFor(c => c.CarName).Must(startWithA);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
        }

        private bool startWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
