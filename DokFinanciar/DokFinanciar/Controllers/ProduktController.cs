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
    public class ProduktController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"exec sp_getProdukt";
            DataTable table = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DokumentacionFinanciar"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(DokFinanciar.Models.Produkt p)
        {
            try
            {
                string query = @"exec sp_postProdukt
                    
                        '" + p.id_produkt + @"',
                        '" + p.emertimi + @"',
                        '" + p.sasia + @"',
                        '" + p.cmimi + @"'
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DokumentacionFinanciar"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "U shtua me sukses";
            }
            catch (Exception)
            {
                return "Deshtoi";
            }
        }
        public string Put(DokFinanciar.Models.Produkt p)
        {
            try
            {
                string query = @"exec sp_updateProdukt
                        '" + p.id_produkt + @"',
                        '" + p.emertimi + @"',
                        '" + p.sasia + @"',
                        '" + p.cmimi + @"'
                            ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DokumentacionFinanciar"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "U ndryshua me sukses";
            }
            catch (Exception)
            {
                return "Deshtoi";
            }
        }
        public string Delete(string id)
        {
            try
            {
                string query = @"exec sp_deleteProdukt'" + id + @"'";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DokumentacionFinanciar"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "U fshi me sukses";
            }
            catch (Exception)
            {
                return "Deshtoi";
            }
        }
    }
}
