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
using System.Configuration;
namespace VendorVehicleRegistration
{
    
    public partial class frmLogin : Form
    {

        public string  StrConnection;


        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            sValidateLogin();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           // string strHeading = ConfigurationManager.AppSettings.GetValues("heading");
        }


        private void sValidateLogin()
        {

            string strdbPath = Application.StartupPath + "\\Vendor_Vehicle_Reg.accdb";
            StrConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strdbPath + "; Persist Security Info = False; ";
            OleDbConnection oleConn = new OleDbConnection(StrConnection);
            try
            {

                if (txtUserId.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("User id required to connect", "Vendor Vehicle Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                if (txtPassword.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("Password required to connect", "Vendor Vehicle Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // oleConn.Open();

                DataTable dtUser = new DataTable();
                string strSQL = "SELECT User_id FROM user_info WHERE USER_ID='" + txtUserId.Text.Trim() + "' AND PASSWORD='" + txtPassword.Text.Trim() + "'";
                OleDbDataAdapter oleAda = new OleDbDataAdapter(strSQL, oleConn);
                oleAda.Fill(dtUser);
                int rcount = dtUser.Rows.Count;
                if (rcount > 0)
                {
                    frmMain frm = new frmMain();
                    frm.Show();

                }

                else
                {

                    MessageBox.Show("User ID or Password does not match", "Vendor Vehicle Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                sValidateLogin();
            }

            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter);
        }
    }
}
