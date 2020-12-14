using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DokFinanciar.Models
{
    public class Gjendje
    {
        public virtual Magazine id_magazina { get; set; }
        public virtual Produkt id_produkt { get; set; }
    }
}