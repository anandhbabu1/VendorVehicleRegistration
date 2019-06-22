using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace VendorVehicleRegistration
{
    public partial class frmVendorinfo : Form
    {
        string strdbconnect;

        public frmVendorinfo()
        {
            InitializeComponent();
        }

        private void frmVendorinfo_Load(object sender, EventArgs e)
        {

            string strdbPath = Application.StartupPath + "\\Vendor_Vehicle_Reg.accdb";
             strdbconnect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strdbPath + "; Persist Security Info = False; ";
            sLoadVendorInfo();dfgdfg
        }

        private void sLoadVendorInfo()
        {


            try
            {
                DataTable dtVendor= new DataTable();
                string strSQL = "SELECT * FROM vendor_info";
                OleDbConnection oleConn = new OleDbConnection(strdbconnect);
                OleDbDataAdapter oleAda = new OleDbDataAdapter(strSQL, oleConn);
                oleAda.Fill(dtVendor);

                dgVendor.DataSource = dtVendor;



            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string strAddSQL, strValues;
                //DataTable dtAdd = new DataTable();
                //DataRow dr;

                //    dr = dtAdd.NewRow();
                //dr["Vendor_Name"] = txtVendorName.Text;
                //dr["Address1"] = txtAdd1.Text;
                //dr["Address2"] = txtAdd2.Text;
                //                dr["City"] = txtCity.Text;
                //    dr["State"] = txtState.Text;
                //    dr["Postcode"] = txtPostCode.Text;
                //    dr["Phone"] = txtPhone.Text;
                //    dr["email"] = txtEmail.Text;

                //dtAdd.Rows.Add(dr);

                strAddSQL = "INSERT INTO  VENDOR_INFO (VENDOR_ID, Vendor_Name,ADDRESS1, ADDRESS2, CITY, STATE, POSTCODE, PHONE, EMAIL) VALUES (";

                strValues = "1";
                strValues = strValues + ",'" + txtVendorName.Text;
                strValues = strValues + "','" + txtAdd1.Text;
                strValues = strValues + "','" + txtAdd2.Text;
                strValues = strValues + "','" + txtCity.Text;
                strValues = strValues + "','" + txtState.Text;
                strValues = strValues + "','" + txtPostCode.Text;
                strValues = strValues + "','" + txtPhone.Text;
                strValues = strValues + "','" + txtEmail.Text + "')";

                strAddSQL = strAddSQL + strValues;


                OleDbConnection oleConn = new OleDbConnection(strdbconnect);
                oleConn.Open();

                OleDbCommand oleCmd = new OleDbCommand(strAddSQL, oleConn);

                oleCmd.ExecuteNonQuery();

                MessageBox.Show("Vendor Added Successfully", "Vendor Vehicle Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sLoadVendorInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            sClearControls();
        }

        private void sClearControls()
        {
            txtVendorName.Text = "";
            txtPhone.Text = "";
            txtAdd1.Text = "";
            txtAdd2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtPostCode.Text = "";
            txtEmail.Text = "";
            sLoadVendorInfo();


        }
    }
}
