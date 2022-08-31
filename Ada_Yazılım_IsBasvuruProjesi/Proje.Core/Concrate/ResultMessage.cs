using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Core.Concrate
{
    public class ResultMessage<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public bool isTrue { get; set; }
    }
}
