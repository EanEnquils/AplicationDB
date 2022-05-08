using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicationDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void wykonajToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                   using(DataTable DB = new DataTable("Resultat"))
                    {
                        using (SqlCommand cmd = new SqlCommand(txtZapytaj.Text, db))
                        {
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                            sqlDataAdapter.Fill(DB);
                            dataGridView1.DataSource = DB;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void polaczeniaTestoweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();
                    MessageBox.Show("Jest Podlaczenia", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
