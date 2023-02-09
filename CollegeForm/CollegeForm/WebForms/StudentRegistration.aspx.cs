using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CollegeForm.WebForms
{
    public partial class StudentRegistrationReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CourseFeeGenerator(sender, e);
            }
        }

        protected void CourseFeeGenerator(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "")
            {
                TextBox5.Text = "Select course";
            }
            else
            {
                TextBox5.Text = DropDownList1.SelectedValue;
            }
        }

        static string connectionString = ConfigurationManager.ConnectionStrings["CollegeStudentFormConnectionString"].ConnectionString;
        SqlConnection objConnection = new SqlConnection(connectionString);

        protected void RegisterStudent(object sender, EventArgs e)
        {
            SqlCommand objCommand = new SqlCommand("CollegeFormData", objConnection);
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Bill_Date", DateTime.Now.ToString("dd/MM/yyyy"));
            objCommand.Parameters.AddWithValue("@Name", TextBox1.Text);
            objCommand.Parameters.AddWithValue("@Gender", RadioButtonList1.SelectedValue);
            objCommand.Parameters.AddWithValue("@Date_Of_Birth", Calendar1.SelectedDate);
            objCommand.Parameters.AddWithValue("@Address", TextBox2.Text);
            objCommand.Parameters.AddWithValue("@Email", TextBox3.Text);
            objCommand.Parameters.AddWithValue("@PhoneNumber", TextBox4.Text);
            objCommand.Parameters.AddWithValue("@Course", DropDownList1.SelectedItem.Text);
            objCommand.Parameters.AddWithValue("@Course_Fee", TextBox5.Text);
            objConnection.Open();
            var dataReader = objCommand.ExecuteReader();
            if (dataReader != null)
            {
                Session["data"] = dataReader;
                Label9.Text = "Registration successful.";
                Label9.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("Receipt.aspx");
            }
            else
            {
                Label9.Text = "Something went wrong. Try Again.";
                Label9.ForeColor = System.Drawing.Color.Red;
            }
            objConnection.Close();
        }
    }
}