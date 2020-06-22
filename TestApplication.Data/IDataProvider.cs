using System;
using System.Collections.Generic;
using System.Text;

namespace TestApplication.Data
{
    public interface IDataProvider<T>
    {
        IEnumerable<T> Get();
    }
}
