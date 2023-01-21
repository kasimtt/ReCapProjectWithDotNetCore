using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator:AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentTime).Must(BeOver0);   // kiralama tarihi ile bugün arasında en az bir gün olmasını istiyorum
            RuleFor(r => r.ReturnTime).Must(BeOver0);
        }

       

        private bool BeOver0(DateTime arg)
        {
            DateTime today = DateTime.Now;
            TimeSpan dateDifference = today - arg;
            if(dateDifference.Minutes >=0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
