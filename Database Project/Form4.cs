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
    public partial class Form4 : Form
    {
        Registration registration = new Registration();
        public Form4()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {

                MessageBox.Show("Please enter the SID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
              
                string input = textBox5.Text;

                int sid = Convert.ToInt32(input);

             
            }
            catch (FormatException)
            {

                MessageBox.Show("Please enter a valid integer value for SID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ;
            }
            var student =  registration.FetchStudent(textBox5.Text);

            textBox1.Text = student.FullName;
            textBox2.Text = student.PhoneNo;
            textBox3.Text = student.Email;
            textBox4.Text = student.StuAddress;
            comboBox1.Text = student.Semester;
            textBox6.Text = student.GPA.ToString();
        

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(comboBox1.Text))
            {

                MessageBox.Show("Please Fill the Information Completely", "Error",MessageBoxButtons.OK , MessageBoxIcon.Information);

                return;

            }

            Student student = new Student();

            student.SID = int.Parse(textBox5.Text);
            student.FullName = textBox1.Text;
            student.GPA = decimal.Parse(textBox6.Text);
            student.Semester = comboBox1.Text;

            Address address = new Address();
            address.StuAddress = textBox4.Text;

            Contact contact = new Contact();
            contact.PhoneNo = textBox2.Text;
            contact.Email = textBox3.Text;


            registration.UpdateStudent(student,contact,address);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
