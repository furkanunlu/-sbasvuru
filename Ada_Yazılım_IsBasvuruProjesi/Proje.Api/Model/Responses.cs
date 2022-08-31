using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proje.Api.Model
{
    public class Responses
    {
        public string Ad { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
        public bool RezervasyonYapilabilir { get; set; }
        public ICollection<ResponseDetail> responseDetail { get; set; }
    }
}
