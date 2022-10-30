using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult( string message) : base(true, message) // işlemin doğruluğunu burada işliyoruz
        {
        }

        public SuccessResult():base(true) //mesaj istenmediği durumunda kullanılır
        {

        }
    }
}
