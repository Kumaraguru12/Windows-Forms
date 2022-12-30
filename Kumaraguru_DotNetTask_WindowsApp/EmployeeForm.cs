using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kumaraguru_DotNetTask_WindowsApp
{

    public partial class EmployeeForm : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog = employee_db; Integrated Security = True;");

        public EmployeeForm()
        {
            InitializeComponent();
        }
        void clearrec()
        {
            txtEmpCode.Clear();
            txtEmpName.Clear();
            txtReport.Clear();
            txtDept.Clear();
            txtContact.Clear();
            txtEmpCode.Focus();
        }
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtEmpCode.Text=="")
            {
                MessageBox.Show("Enter Employee Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmpCode.Focus();
                return;
            }
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec employee_sp '" + int.Parse(txtEmpCode.Text) + "','" + txtEmpName.Text + "','" + DateTime.Parse(dateTimePicker1.Text) + "','" + DateTime.Parse(dateTimePicker2.Text) + "','" + txtDept.Text + "','" + txtReport.Text + "','" + txtContact.Text + "','" + comboBoxResigned.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data inserted into SQL Database");
                clearrec();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtEmpCode.Text == "")
            {
                MessageBox.Show("Enter Employee Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmpCode.Focus();
                return;
            }
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec employee_updatesp '" + int.Parse(txtEmpCode.Text) + "','" + txtEmpName.Text + "','" + DateTime.Parse(dateTimePicker1.Text) + "','" + DateTime.Parse(dateTimePicker2.Text) + "','" + txtDept.Text + "','" + txtReport.Text + "','" + txtContact.Text + "','" + comboBoxResigned.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated to SQL Database");
                clearrec();


                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtEmpCode.Text == "")
            {
                MessageBox.Show("Enter Employee Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmpCode.Focus();
                return;
            }
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("exec employee_deletesp '" + int.Parse(txtEmpCode.Text) + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted From Sql Database");
                clearrec();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }


        private void EmployeeForm_Load(object sender, EventArgs e)
        {
                     
        }

       

        private void txtEmpCode_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtEmpCode.Text, "[^0-9]"))
            {
                MessageBox.Show("Invalid Entry [ Only Numeric Inputs ]", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmpCode.Text = txtEmpCode.Text.Remove(txtEmpCode.Text.Length - 1);
            }
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtContact.Text, "[^0-9]"))
            {
                MessageBox.Show("Invalid Entry [ Only Numeric Inputs ]", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContact.Text = txtContact.Text.Remove(txtContact.Text.Length - 1);
            }
        }

        private void EmployeeForm_Shown(object sender, EventArgs e)
        {
            txtEmpCode.Focus();
        }
    }
}
