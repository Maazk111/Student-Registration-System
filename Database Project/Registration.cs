using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Database_Project
{

    public class Registration
    {
        SqlConnection xConnect;

        public Registration()
        {

            xConnect = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=university;Trusted_Connection=True;");
            Console.WriteLine("Connection Sucessful");

        }

        public void UpdateStudent(Student student, Contact contact, Address address) {


            xConnect.Open();
            string updateStu = "UPDATE Student SET FullName = '" + student.FullName + "' , Semester = '" + student.Semester + "' , GPA = '" + student.GPA + "' WHERE SID = " + student.SID + "  ";

            string updateCon = "UPDATE Contact SET  PhoneNo = '" + contact.PhoneNo + "' , Email = '" + contact.Email + "' WHERE SID =" + student.SID + "  ";

            string updateAdd = "UPDATE Address SET  Address = '" + address.StuAddress + "' WHERE SID = " + student.SID + " ";


            SqlCommand updateCommandStu = new SqlCommand(updateStu, xConnect);

            updateCommandStu.ExecuteNonQuery();


            SqlCommand updateCommandCon = new SqlCommand(updateCon, xConnect);

            updateCommandCon.ExecuteNonQuery();


            SqlCommand updateCommandAdd = new SqlCommand(updateAdd, xConnect);

            updateCommandAdd.ExecuteNonQuery();

            MessageBox.Show("Data Updated Successfully");
            xConnect.Close();
        }
        public DataTable FetchStudents()
        {

            xConnect.Open();
            string selectQuery = "SELECT s.SID, s.FullName, s.Semester, s.GPA, c.PhoneNo, c.Email, a.Address FROM Student s INNER JOIN Contact c ON s.SID = c.SID INNER JOIN Address a ON s.SID = a.SID ";

            DataTable dt = new DataTable(); // Create Table in Form 

            new SqlDataAdapter(selectQuery, xConnect).Fill(dt); // Fill the data Retrive from database into Table

            xConnect.Close();

            return dt;   


        }
        public StudentModel FetchStudent(string SID)
        {
            xConnect.Open();
            string search = "SELECT s.SID, s.FullName, s.Semester, s.GPA, c.PhoneNo, c.Email, a.Address FROM Student s INNER JOIN Contact c ON s.SID = c.SID INNER JOIN Address a ON s.SID = a.SID WHERE S.SID =" +SID+ " ";


            SqlCommand SearchQuery = new SqlCommand(search, xConnect);

            var reader =  SearchQuery.ExecuteReader();


            if (reader.Read())
            {

                StudentModel student = new StudentModel();  // To get the data from the Student

                student.SID = int.Parse(reader["SID"].ToString());
                student.FullName = reader["FullName"].ToString();
                student.Semester = reader["Semester"].ToString();
                student.GPA = decimal.Parse(reader["GPA"].ToString());
                student.PhoneNo = reader["PhoneNo"].ToString();
                student.Email = reader["Email"].ToString();
                student.StuAddress = reader["Address"].ToString();

                xConnect.Close();
                return student;
                
            }

            xConnect.Close();

            return null;

        }
        public void RegisterStudent(Student student , Contact contact , Address address)
        {

            string insertStu = "INSERT INTO Student (SID, FullName, Semester, GPA) VALUES (" + student.SID + " , '" + student.FullName + "' , '" + student.Semester + "' , '" + student.GPA + "')";

            string insertCon = "INSERT INTO Contact (SID, PhoneNo, Email) VALUES (" + student.SID + " , '" + contact.PhoneNo + "' , '" + contact.Email + "'  )";

            string insertAdd = "INSERT INTO Address (SID, Address) VALUES (" + student.SID + " , '" + address.StuAddress + "' )";

            xConnect.Open();

            SqlCommand insertCommandStu = new SqlCommand(insertStu, xConnect);

            insertCommandStu.ExecuteNonQuery();


            SqlCommand insertCommandCon = new SqlCommand(insertCon, xConnect);

            insertCommandCon.ExecuteNonQuery();


            SqlCommand insertCommandAdd = new SqlCommand(insertAdd, xConnect);

            insertCommandAdd.ExecuteNonQuery();

            xConnect.Close();

            MessageBox.Show("Data Inserted Successfully");

        }

        public DataTable DeleteStudent(string SID)
        {
            xConnect.Open();
            string search = "DELETE FROM Student WHERE SID =" + SID + " ";
            SqlCommand deleteCommandCon = new SqlCommand(search, xConnect);

            deleteCommandCon.ExecuteNonQuery();

            xConnect.Close();
            MessageBox.Show("Record Deleted Successfully", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var updatedGridView = FetchStudents();

            return updatedGridView;
        }
    }

  


}
