using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DokFinanciar.Models
{
    public class Transaksione
    {
        public virtual Produkt id_produkt {get; set;}
        public virtual Fature id_fature { get; set; }
    }
}