using System;
using System.Collections.Generic;
using System.Text;
using CommanLayer.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;
namespace DataLayer
{
    public class EmployeeDataAccess
    {
        private DbConnection db = new DbConnection();
        public List<Employees> GetEmployees()
        {
            string query = "select * from Employees";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = db.cnn;
            if(db.cnn.State==System.Data.ConnectionState.Closed)
            {
                db.cnn.Open();
            }
            SqlDataReader reader = command.ExecuteReader();
            List<Employees> employees = new List<Employees>();
            while(reader.Read())
            {
                Employees emp = new Employees();
                emp.Id = (int)reader["Id"];
                emp.Name = reader["Name"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.Gender = reader["Gender"].ToString();
                emp.Mobile = reader["Mobile"].ToString();
                employees.Add(emp);
            }
            db.cnn.Close();
            return employees;

        }
        public Employees GetEmployeesByID(int id)
        { 
            string query = "select * from Employees where Id="+id+"";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = db.cnn;
            if (db.cnn.State == System.Data.ConnectionState.Closed)
            {
                db.cnn.Open();
            }
            SqlDataReader reader = command.ExecuteReader();
            List<Employees> employees = new List<Employees>();
            reader.Read();
            
                Employees emp = new Employees();
                emp.Id = (int)reader["Id"];
                emp.Name = reader["Name"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.Gender = reader["Gender"].ToString();
                emp.Mobile = reader["Mobile"].ToString();
                
            db.cnn.Close();
            return emp;

        }

        public bool CreateEmployees(Employees employees)
        {
            string query="insert into Employees values('"+employees.Id+"','"+employees.Name+"','"+employees.Email+"','"+employees.Gender+"','"+employees.Mobile+"')";
            SqlCommand cmd = new SqlCommand(query, db.cnn);
            if (db.cnn.State == System.Data.ConnectionState.Closed)
            {
                db.cnn.Open();
            }
            int i =cmd.ExecuteNonQuery();
            db.cnn.Close();
            return Convert.ToBoolean(i);
        }
        public bool DeleteEmployees(int id)
        {
            string query="delete from Employees where Id="+id+"";
            SqlCommand cmd = new SqlCommand(query, db.cnn);
            if (db.cnn.State == System.Data.ConnectionState.Closed)
            {
                db.cnn.Open();
            }
            int i = cmd.ExecuteNonQuery();
            db.cnn.Close();
            return Convert.ToBoolean(i);
        }
        public bool UpdateEmployees(Employees employees)
        {
            string query = "update Employees set Id="+employees.Id+"" +
                ",Name="+employees.Name+",Email="+employees.Email+",Gender="+employees.Gender+",Mobile="+employees.Mobile+"";
            SqlCommand cmd = new SqlCommand(query, db.cnn);
            if (db.cnn.State == System.Data.ConnectionState.Closed)
            {
                db.cnn.Open();
            }
            int i = cmd.ExecuteNonQuery();
            db.cnn.Close();
            return Convert.ToBoolean(i);
        }
    }
}
