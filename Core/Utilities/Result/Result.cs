using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        // eğer başarı durumunu ve mesajı görmek istersek bu contructoru çalıştırırız
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success) // sadece başarı durumu dönmek istersek bu contructoru döneriz.
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
