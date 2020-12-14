using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DokFinanciar.Models
{
    public class Fature
    {
        public int id_fature { get; set; }
        public virtual FatureTip id_fatureTip { get; set; }
        public string nga { get; set; }
        public string ku { get; set; }

    }
}