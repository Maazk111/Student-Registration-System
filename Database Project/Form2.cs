using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class Form2 : Form
    {
        Registration registration = new Registration();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();

            f3.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(); 

            f4.Show();
            
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
      
            DataTable dt = registration.FetchStudents();
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;

            if (textBox1.Text.Contains('-'))
            {
                bs.Filter = "PhoneNo" + " like '%" + textBox1.Text + "%'";

            }
            else
            {
                bs.Filter = "FullName" + " like '%" + textBox1.Text + "%'";
            }

            dataGridView1.DataSource = bs;

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string SID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            DialogResult DR = MessageBox.Show("Are you sure you want to delete this record?", SID, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DR == DialogResult.Yes)
            {
                DataTable dt = registration.DeleteStudent(SID);
                dataGridView1.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
