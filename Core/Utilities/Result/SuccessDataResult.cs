using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class SuccessDataResult<T>: DataResult<T>
    {
        public SuccessDataResult(T data , string message):base(data,true,message) // veri ve mesaj döner
        {

        }

        public SuccessDataResult(T data):base(data,true) // veri döner
        {

        }


        public SuccessDataResult():base(default,true) // veri de mesaj da dönmez
        {

        }

        public SuccessDataResult(string message):base(default,true,message) // mesaj döner
        {

        }
    }
}
