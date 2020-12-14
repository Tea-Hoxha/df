using DokFinanciar.Models;
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
    public class KlientController : ApiController
    {

       
        [HttpGet]
        public HttpResponseMessage Get()
        {
            string query = @" exec sp_getKlient";
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
 
        public string Post(DokFinanciar.Models.Klient k)
        {
            try
            {
                string query = @"exec sp_postKlient
                    
                        '" + k.id_klient + @"',
                        '" + k.emri + @"',
                        '" + k.nipt + @"',
                        '" + k.qyteti + @"'
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
        public string Put(DokFinanciar.Models.Klient k)
        {
            try
            {
                string query = @"exec sp_updateKlient
                        '" + k.id_klient + @"',
                        '" + k.emri + @"',
                        '" + k.nipt + @"',
                        '" + k.qyteti + @"'
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
                string query = @"exec sp_deleteKlient '" + id + @"'";

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
