using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DataDisplayForm2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInstant_Click(object sender, EventArgs e)
        {


        }

        private void btnTestAlarm_Click(object sender, EventArgs e)
        {

            if (testAlarm != null && !testAlarm.IsDisposed)
                testAlarm.Show();
            else
                (testAlarm = new TestAlarm()).Show();
        }

        private void btnRefreshDB_Click(object sender, EventArgs e)
        {

        }
    }
}
