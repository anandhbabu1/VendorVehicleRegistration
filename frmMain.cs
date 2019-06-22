using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendorVehicleRegistration
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void dataEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataEntry frmDE = new frmDataEntry();
            frmDE.MdiParent = this;
            frmDE.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmReports frmRpt = new frmReports();
            frmRpt.MdiParent = this;
            frmRpt.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            menuStrip1.BackColor = Color.LightBlue;

            menuStrip1.ForeColor = Color.Black;
            
            menuStrip1.Font = new Font("Calibri", 10);


           
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
       
        }

        private void vendorInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendorinfo frmVI = new frmVendorinfo();
            frmVI.MdiParent = this;
            frmVI.Show();
        }
    }
}
