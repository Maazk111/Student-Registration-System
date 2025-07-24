using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Se-221053" && textBox2.Text == "admin" )
            {
                Form2 obj = new Form2();
                obj.Show(); // To open the Form 2
                this.Hide(); // To close the Previous Form
            }
            else
            {
                MessageBox.Show("Username/Password is Incorect", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        
        }

        private void Email_Click(object sender, EventArgs e)
        {

        }

        private void Password_Click(object sender, EventArgs e)
        {

        }
    }
}
