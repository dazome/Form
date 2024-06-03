using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Azhans_zoha
{
    internal class ClsPerson
    {
        String FirstN = "", LastN = "", IdNumber = "", Gender = "", MaritalS = "", Birth = "";

        public String FirstN_sg
        {
            set { FirstN = value; }
            get { return FirstN; }
        }
        public String Lastn_sg
        {
            set { LastN = value; }
            get { return LastN; }
        }

        public String idNumber_sg
        {
            set { IdNumber = value; }
            get { return IdNumber; }
        }

        public String Gender_sg
        {
            set { Gender = value; }
            get { return Gender; }
        }

        public String MaritalS_sg
        {
            set { MaritalS = value; }
            get { return MaritalS; }
        }

        public String Birth_sg
        {
            set { Birth = value; }
            get { return Birth; }
        }

        public void SaveData()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Negar\\source\\repos\\Azhans_zoha\\Azhans_zoha\\bin\\Debug\\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Person", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@first", FirstN);
            cmd.Parameters.AddWithValue("@last", LastN);
            cmd.Parameters.AddWithValue("@idNumber", IdNumber);
            cmd.Parameters.AddWithValue("@gender", Gender);
            cmd.Parameters.AddWithValue("@marital", MaritalS);
            cmd.Parameters.AddWithValue("@birth", Birth);

            try
            {

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("you have registered succesfully");
            }
            catch(SqlException err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public void EditPerson()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Negar\\source\\repos\\Azhans_zoha\\Azhans_zoha\\bin\\Debug\\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("editPerson",con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@First_Name", FirstN);
            cmd.Parameters.AddWithValue("@Last_Name", LastN);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Marital_Status", MaritalS);
            cmd.Parameters.AddWithValue("@Birth_Date", Birth);
            cmd.Parameters.AddWithValue("@ID_Number", IdNumber);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Your data has been edited successfully");

            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }




        }


        public void DeletePerson()
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Negar\\source\\repos\\Azhans_zoha\\Azhans_zoha\\bin\\Debug\\Database1.mdf;Integrated Security=True");
            SqlCommand cmd= new SqlCommand("DeletePerson",conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID_Number",IdNumber);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Your data has been deleted successfully");


            }
            catch (SqlException err)
            {
                MessageBox.Show(err.Message);
            }

        }


        public DataTable SearchPersonById()
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Negar\\source\\repos\\Azhans_zoha\\Azhans_zoha\\bin\\Debug\\Database1.mdf;Integrated Security=True"); 
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SearchPersonByID",conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            dataAdapter.SelectCommand.Parameters.AddWithValue("@ID_Number", IdNumber);

            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            return dt;
                

        }

        public DataSet SearchByName()
        {
            SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Negar\\source\\repos\\Azhans_zoha\\Azhans_zoha\\bin\\Debug\\Database1.mdf;Integrated Security=True");
            SqlDataAdapter da= new SqlDataAdapter("SearchByName",conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@First_Name", FirstN);
            da.SelectCommand.Parameters.AddWithValue("@Last_Name", LastN);

            DataSet ds = new DataSet();
            da.Fill(ds,"tblCatch");

            return ds;
        }
    }
}
