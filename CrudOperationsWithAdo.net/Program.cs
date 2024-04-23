using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsWithAdo.net
{
    class Program
    {
        static void create(SqlConnection connection)
        {
            string creatTableQuery = @"IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Employee')BEGIN Create table Employee(EmployeeId int primary key identity(1,1),Name varchar(50),Address varchar(20),Salary decimal(10,2),JoinDate Date,City varchar(20));END;";
            SqlCommand command = new SqlCommand(creatTableQuery, connection);
            connection.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("Successfully created the table");
            command.Dispose();
            connection.Close();
        }

        static void insert(SqlConnection connection)
        {
            string insertTableQuery = @"insert into Employee(Name,Address,Salary,JoinDate,City) values('Lallu','nagarbhavi',55000.00,'2009-04-08','bengalure'),('rahul','nagarbhavi',6000.00,'2009-03-08','bengalure'),('maggie','nagarbhavi',8000.00,'2009-02-08','bengalure');";
            SqlCommand command = new SqlCommand(insertTableQuery, connection);
            connection.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("Successfully into the table");
            command.Dispose();
            connection.Close();
        }

        static void display(SqlConnection connection)
        {
            string displayTableQuery = @"select * from Employee";
            SqlCommand command = new SqlCommand(displayTableQuery,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($" Id : {reader["EmployeeId"]},Name :{reader["Name"]},Address : {reader["Address"]},Salary : {reader["Salary"]},Joindate: {reader["JoinDate"]},City : {reader["City"]}");
            }
            command.ExecuteNonQuery();
            Console.WriteLine("Successfully display the table");
            reader.Close();
            command.Dispose();
            connection.Close();
        }

        static void displaySalaryAtleast25K(SqlConnection connection)
        {
            string displayTableQuery = @"select Name,Address,Salary from Employee as e where Salary > 25000";
            SqlCommand command = new SqlCommand(displayTableQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Name :{reader["Name"]},Address : {reader["Address"]},Salary : {reader["Salary"]}");
            }
            command.ExecuteNonQuery();
            Console.WriteLine("Successfully display the table");
            reader.Close();
            command.Dispose();
            connection.Close();
        }

        static void displayDateBtwJanToApr(SqlConnection connection)
        {
            string displayTableQuery = @"select Name,Address,Joindate from Employee where JoinDate Between '2009-01-01' and '2009-04-30'";
            SqlCommand command = new SqlCommand(displayTableQuery, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Name :{reader["Name"]},Address : {reader["Address"]},Joindate: {reader["JoinDate"]}");
            }
            command.ExecuteNonQuery();
            Console.WriteLine("Successfully display the table");
            reader.Close();
            command.Dispose();
            connection.Close();
        }

        static void update(SqlConnection connection)
        {
            string displayTableQuery = @"update Employee set city = 'Mumbai' where EmployeeId = 2";
            SqlCommand command = new SqlCommand(displayTableQuery, connection);
            connection.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("Successfully update the table");
            command.Dispose();
            connection.Close();
        }

        static void delete(SqlConnection connection)
        {
            string displayTableQuery = @"delete Employee where EmployeeId = 1";
            SqlCommand command = new SqlCommand(displayTableQuery, connection);
            connection.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("Successfully delete the table");
            command.Dispose();
            connection.Close();
        }

        static void Main()
        {
            try
            {
                const string connectionString = "server=CAPEDBOLDY\\SQLEXPRESS; Initial Catalog = PersonalDB; Integrated Security = SSPI";
                SqlConnection connection = new SqlConnection(connectionString);
                //display(connection);
                //displaySalaryAtleast25K(connection);
                displayDateBtwJanToApr(connection);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); } 
        }
    }
}
