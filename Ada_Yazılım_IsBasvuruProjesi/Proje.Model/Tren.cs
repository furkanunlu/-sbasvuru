using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proje.Model
{
    public class Tren : Base
    {
        public string Ad { get; set; }
        
        public virtual ICollection<Vagonlar> Vagonlars { get; set; }

        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
