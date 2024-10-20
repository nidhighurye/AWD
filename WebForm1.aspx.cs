using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication16
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Getdb()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from Emp", conn);
        
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds,"Emp");
            GridView1.DataSource = ds;
            GridView1.DataBind();
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Getdb();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn=new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from Emp",conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            conn.Close();

        }
    }
}