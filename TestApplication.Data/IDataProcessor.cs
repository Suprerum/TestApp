using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TestApplication.Data
{
    public interface IDataProcessor
    {
        void  Create(IDatable datable);
        void Delete();
        void Update();
    }
}
