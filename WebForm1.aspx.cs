using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Table
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionString="Data Source=ROHII\\ROHITHA;Initial Catalog=marchDB;User ID =sa;Password=rohitha";
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter Dr = new SqlDataAdapter("Select * from Employees", con);
                DataTable dt = new DataTable();
                Dr.Fill(dt);
                gvEmployees.DataSource = dt;
                gvEmployees.DataBind();
                con.Close();

            }
        }
            
        protected void lnkEdit_Click(object sender,EventArgs e)
        {
            
        }
     }
       

   }
