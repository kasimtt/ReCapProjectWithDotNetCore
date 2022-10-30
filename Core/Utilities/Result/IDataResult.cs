using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    // T datamızı tipini verir
    public interface IDataResult<T>:IResult //IResulttan message ve success alındı
    {
        T Data { get; }
    }
}
