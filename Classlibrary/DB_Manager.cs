using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;


namespace Classlibrary
{
    public class DB_Manager
    {
 
        public static string readFrom_DataTable="Select * FROM GTD";
        public static string connectionString=
        @"Data Source=40.85.84.155 ;initial catalog=GTD;Persist Security Info=True;User ID=Student19;Password=YH-student@2019";
      //  Skapar anslutning till databas tabellen och skickar ni data till databasen
    public static void AddToDatabase(string title, DateTime Created, DateTime Deadline, string Category, string Priority){
        using (SqlConnection con =new SqlConnection(connectionString)){
        con.Open();
        
       // string addTask=  "INSERT into GTD (Task, Created, Deadline, Kategori, Prioritet) VALUES (Task);
        using (SqlCommand cmd = new SqlCommand()){
          Task t=new Task();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT into GTD (Task, Created, Deadline, Kategori, Prioritet) VALUES (@Task, @Created, @Deadline,@Kategori, @Prioritet)";
            cmd.Parameters.AddWithValue("@Task", t.Title);
            cmd.Parameters.AddWithValue("@Created", t.DateAdded);
            cmd.Parameters.AddWithValue("@Deadline", t.Deadline);
            cmd.Parameters.AddWithValue("@Kategori", t.Type);
            cmd.Parameters.AddWithValue("@Prioritet", t.TaskPriority);

        }
        
        }
        }
    //Läser in tabellen i databasen och fyller en lista
    public static void ReadFromDatabase(){
        using (SqlConnection con=new SqlConnection(connectionString)){
            con.Open();
            SqlCommand cmd = new SqlCommand(readFrom_DataTable,con);
            cmd.CommandType=CommandType.StoredProcedure;
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DA.Fill(dt);
        List<Object> listOfTasks = new List<Object>();
            if(dt.Rows.Count>0){
                foreach(DataRow drow in dt.Rows){
                    listOfTasks.Add(drow[0].ToString());
                }
            }
        }
    
        }
    }
    }
    
