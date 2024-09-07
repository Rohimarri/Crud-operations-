using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
namespace Table
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                BindDepartments();
            }
        }

        protected void BindGrid()
        {
            string connectionString = "Data Source=ROHII\\ROHITHA;Initial Catalog=marchDB;User ID =sa;Password=rohitha"; // Replace with your connection string
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                    }
                }
            }
        }

        protected void BindDepartments()
        {
            string connectionString = "Data Source=ROHII\\ROHITHA;Initial Catalog=marchDB;User ID =sa;Password=rohitha"; // Replace with your connection string
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT DeptID, DeptName FROM Departments", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        ddlDepartment.DataSource = dt;
                        ddlDepartment.DataTextField = "DeptName";
                        ddlDepartment.DataValueField = "DeptID";
                        ddlDepartment.DataBind();
                    }
                }
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=ROHII\\ROHITHA;Initial Catalog=marchDB;User ID =sa;Password=rohitha";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddUpdateEmployee", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpID", 0);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@refDeptID", ddlDepartment.SelectedValue);
                   
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("Webform1.aspx");
                }
            }
            // Refresh the GridView
            BindGrid();
            ClearFields();
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Webform1.aspx");
        }

        private void ClearFields()
        {

            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlDepartment.SelectedIndex = 0;
        }
    }
}
// Save logic here
        

  
        
    



                


                
        
    



           
    

  
    

