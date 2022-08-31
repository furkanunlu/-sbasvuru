using Proje.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Model
{
    public class Base :IData
    {
        public int Id { get; set; }
        public bool isDelete { get; set; }
    }
}
