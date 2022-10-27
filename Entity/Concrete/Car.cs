using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {   //Arabanın özellikleri burada yer almaktadır..
        //: Id, BrandId, ColorId, ModelYear, DailyPrice, Description
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string CarName { get; set; }
        public int ColorId { get; set; }
        public short ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
