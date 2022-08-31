using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Proje.Model
{
    public class Vagonlar : Base
    {

        public string Ad { get; set; }
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }

        [ForeignKey("Tren")]
        public int TrenId { get; set; }
        public virtual Tren Tren { get; set; }
    }
}
