using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public interface IResult
    {
        //mesaj ve durumu dönmesini istiyoruz
        bool Success { get; }
        string Message { get; }
    }
}
