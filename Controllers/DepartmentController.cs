using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dev_krina.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                select DepartmentId,DepartmentName from
                dbo.Department
                ";
            DataTable table = new DataTable();

            // using (var con = new SqlConnection(ConfigurationManager.
            //   ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var con = new SqlConnection("hx67tx2ygu.database.windows.net; Initial Catalog = Dev_KRINA; User ID = gep_sql_admin; Password = Password@123")) 
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}
