using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DokFinanciar.Controllers
{
    public class DokumentacioniController : ApiController
    {
        
        public string Post(DokFinanciar.Models.Transaksione t)
        {
            try
            {
                string query = @"exec sp_fature
                      
                        '" + t.id_fature.id_fatureTip.fatureTip + @"',
                        '" + t.id_fature.nga + @"',
                        '" + t.id_fature.ku + @"',
                        '" + t.id_produkt.emertimi + @"',
                        '" + t.id_produkt.sasia + @"',
                        '" + t.id_produkt.cmimi + @"'
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DokumentacionFinanciar"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "U ndryshua ne magazine";
            }
            catch (Exception)
            {
                return "Deshtoi";
            }

        }
    }
}
