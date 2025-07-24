using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {

                MessageBox.Show("Please Fill the Information Completely", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;

            }

            Registration registration = new Registration();

            Student student = new Student();

            student.SID = new Random().Next(200,100000);
            student.FullName = textBox1.Text;
            student.GPA = decimal.Parse(textBox6.Text);
            student.Semester = comboBox1.Text;

            Address address = new Address();
            address.StuAddress = textBox4.Text;

            Contact contact = new Contact();
            contact.PhoneNo = textBox2.Text;
            contact.Email = textBox3.Text;

            registration.RegisterStudent( student,  contact,  address);

            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox6.Text = comboBox1.Text = null;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
