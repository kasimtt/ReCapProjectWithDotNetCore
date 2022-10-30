using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data,  string message) : base(data, false, message) // datayı ve messaji tutar
        {
        }

        public ErrorDataResult(T data ):base(data,false) // sadece datayı tutar
        {

        }
        public ErrorDataResult(string message):base(default,false,message) // sadece mesaj döner
        {

        }
        public ErrorDataResult():base(default,false) // bir sey tutmaz
        {

        }

    }
}
