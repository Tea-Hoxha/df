using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace DokFinanciar.Controllers
{
    public class DyqanController : ApiController
    {
        //, DokFinanciar.Models.Fature f
        public HttpResponseMessage Get()
        {
            string query = @"exec sp_MagazinaInfo";
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
        [Route("api/Dyqan/TotaliMagazines")]
        [HttpGet]
        public HttpResponseMessage TotaliMagazines()
        {
            string query = @"exec sp_totaliMagazines";
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
        [Route("api/Dyqan/Hyrje")]
        [HttpPost]
        public string Hyrje(DokFinanciar.Models.Gjendje gj)
        {
            try
            {
                string query = @"exec sp_furnitorMagazine

                        '" + gj.id_produkt.emertimi + @"',
                        '" + gj.id_produkt.sasia + @"',
                        '" + gj.id_produkt.cmimi + @"'
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DokumentacionFinanciar"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "U shtua ne magazine me sukses";
            }
            catch (Exception)
            {
                return "Deshtoi";
            }

        }

        [Route("api/Dyqan/Dalje")]
        [HttpPost]
        public string Dalje(DokFinanciar.Models.Gjendje gj)
        {
            try
            {
                string query = @"exec sp_MagazineKlient

                        '" + gj.id_produkt.emertimi + @"',
                        '" + gj.id_produkt.sasia + @"',
                        '" + gj.id_produkt.cmimi + @"'
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DokumentacionFinanciar"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "U zbrit nga magazina me sukses";
            }
            catch (Exception)
            {
                return "Deshtoi";
            }
        }
       
    }
}

