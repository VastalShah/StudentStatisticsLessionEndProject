using StudentStatistics.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentStatistics
{
    public class Data
    {
        string connectionString = "Server=HSC-35DNZF2\\SQLEXPRESS; Database=StudentDB; Integrated Security=true";

        public List<StudentModel> GetAllStudents()
        {
            List<StudentModel> students = new List<StudentModel>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from [Student_Details]", connection);
                cmd.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    StudentModel student = new StudentModel();
                    student.ID = Convert.ToInt32(rdr["ID"]);
                    student.Name = rdr["Name"].ToString();
                    student.Age = Convert.ToInt32(rdr["Age"]);
                    student.DBMS_Marks = Convert.ToInt32(rdr["DBMS"]);
                    student.Data_Structures_Marks = Convert.ToInt32(rdr["Data_Structures"]);
                    students.Add(student);
                }
                connection.Close();
            }
            return students;
        }


        public List<SubjectModel> GetAllSubjects()
        {
            List<SubjectModel> subjects = new List<SubjectModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from [Subject]", connection);
                cmd.CommandType = System.Data.CommandType.Text;
                connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SubjectModel subject = new SubjectModel();
                    subject.Name = rdr["subject_name"].ToString();
                    subject.Code = rdr["subject_code"].ToString();
                    subjects.Add(subject);
                }
                connection.Close();
            }
            return subjects;
        }
    }
}
