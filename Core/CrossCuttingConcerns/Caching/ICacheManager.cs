﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    internal interface ICacheManager
    {
        void Add(string key, object value, int duration);
        void Remove(string key);
        bool IsAdd(string key);
        T Get<T>(string key);
        object Get(string key);
        void RemoveByPattern(string pattern);   
    }
}
