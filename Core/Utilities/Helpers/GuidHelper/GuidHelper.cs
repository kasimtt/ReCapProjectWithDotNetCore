using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.GuidHelper
{
    public class GuidHelper
    {
        //dosyalarımıza benzersiz isimler oluşturması için bu methodu kullanırız.
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
