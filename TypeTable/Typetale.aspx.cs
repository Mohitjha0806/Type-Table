using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

using System.Web.UI.WebControls;
using System.Drawing;

namespace TypeTable
{
    public partial class Typetale : System.Web.UI.Page
    {
        private Color red;

        protected void Page_Load(object sender, EventArgs e)
        {


        }


        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {



            DataTable employeeTable = ViewState["EmployeeID"] as DataTable;

            if (employeeTable == null)
            {
                employeeTable = new DataTable();
                employeeTable.Columns.Add("EmployeeID", typeof(int));
                employeeTable.Columns.Add("FirstName", typeof(string));
                employeeTable.Columns.Add("LastName", typeof(string));
                employeeTable.Columns.Add("Email", typeof(string));
                employeeTable.Columns.Add("Phone", typeof(string));


                DataRow Dr = employeeTable.NewRow();
                Dr["EmployeeID"] = txtEmployeeID.Text;
                Dr["FirstName"] = txtFirstName.Text;
                Dr["LastName"] = txtLastName.Text;
                Dr["Email"] = txtEmail.Text;
                Dr["Phone"] = txtPhone.Text;
                employeeTable.Rows.Add(Dr);

            }
            else
            {


                DataRow Dr = employeeTable.NewRow();
                Dr["EmployeeID"] = txtEmployeeID.Text;
                Dr["FirstName"] = txtFirstName.Text;
                Dr["LastName"] = txtLastName.Text;
                Dr["Email"] = txtEmail.Text;
                Dr["Phone"] = txtPhone.Text;
                employeeTable.Rows.Add(Dr);


            }

            ViewState["EmployeeID"] = employeeTable;
            GridView1.DataSource = employeeTable;
            GridView1.DataBind();

            txtEmployeeID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {




            DataTable dtType_tblDemand = new DataTable();
            DataRow RowType;
            dtType_tblDemand.Columns.Add(new DataColumn("glblID", typeof(string)));
            dtType_tblDemand.Columns.Add(new DataColumn("glblFirstName", typeof(string)));
            dtType_tblDemand.Columns.Add(new DataColumn("glblLastName", typeof(string)));
            dtType_tblDemand.Columns.Add(new DataColumn("glblEmail", typeof(string)));
            dtType_tblDemand.Columns.Add(new DataColumn("glblPhone", typeof(string)));
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label glblID = (Label)row.FindControl("glblID");
                Label glblFirstName = (Label)row.FindControl("glblFirstName");
                Label glblLastName = (Label)row.FindControl("glblLastName");
                Label glblEmail = (Label)row.FindControl("glblEmail");
                Label glblPhone = (Label)row.FindControl("glblPhone");
                RowType = dtType_tblDemand.NewRow();
                RowType[0] = glblID.Text;
                RowType[1] = glblFirstName.Text;
                RowType[2] = glblLastName.Text;
                RowType[3] = glblEmail.Text;
                RowType[4] = glblPhone.Text;
                dtType_tblDemand.Rows.Add(RowType);
            }
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("AddEmployees", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = command.Parameters.AddWithValue("@tblemp", dtType_tblDemand);
                    parameter.SqlDbType = SqlDbType.Structured;

                    conn.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                        ErrorMsg.Text = "Data add Successfully";
                        ErrorMsg.ForeColor = Color.Green;
                        ErrorMsg.Font.Bold = true;
                    }
                    catch (Exception)
                    {
                        ErrorMsg.Text = "Error";
                        ErrorMsg.ForeColor = Color.Red; 
                    }
                    conn.Close();

                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }

        }
    }
}