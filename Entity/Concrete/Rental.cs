using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rental:IEntity

    {
        public int RentalId { get; set; }
        public int CarId { get; set; }  // fk
        public int CustomerId { get; set; }// fk
        public DateTime RentTime { get; set; }
        public DateTime ReturnTime { get; set; }
        
        
    }
}
