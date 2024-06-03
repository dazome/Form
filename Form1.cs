using System.Data;

namespace Azhans_zoha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_click(object sender, EventArgs e)
        {
            ClsPerson f = new ClsPerson();
            f.FirstN_sg = textFName.Text;
            f.Lastn_sg = textLName.Text;
            f.idNumber_sg = textID.Text;

            if (rdBtnFemale.Checked == true)
                f.Gender_sg = "Female";
            else if (rdBtnMale.Checked == true)
                f.Gender_sg = "Male";

            if (rdBtnMarried.Checked == true)
                f.MaritalS_sg = "Married";
            else if (rdBtnSingle.Checked == true)
                f.MaritalS_sg = "Single";

            f.Birth_sg = textYear.Text + "/" + textMonth.Text + "/" + textDay.Text;

            f.SaveData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            ClsPerson f = new ClsPerson();
            f.idNumber_sg = textID2.Text;
            DataTable dt = f.SearchPersonById();

            if (dt.Rows.Count == 0)
                MessageBox.Show("Id number not found");
            else
            {
                text2FName.Text = dt.Rows[0]["First_Name"].ToString();
                text2LName.Text = dt.Rows[0]["Last_Name"].ToString();

                if (dt.Rows[0]["Gender"].ToString() == "Female")
                    rdBtn2Female.Checked = true;
                else if (dt.Rows[0]["Gender"].ToString() == "Male")
                    rdBtn2Male.Checked = true;

                if (dt.Rows[0]["Marital_Status"].ToString() == "Single")
                    rdBtn2single.Checked = true;
                else if (dt.Rows[0]["Marital_Status"].ToString() == "Married")
                    rdBtn2Married.Checked = true;

                String[] tt = dt.Rows[0]["Birth_Date"].ToString().Split('/');
                text2Year.Text = tt[0];
                text2Month.Text = tt[1];
                text2Day.Text = tt[2];


            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClsPerson f = new ClsPerson();
            f.FirstN_sg = text2FName.Text;
            f.Lastn_sg = text2LName.Text;
            if (rdBtn2Female.Checked == true)
                f.Gender_sg = "Female";
            else if (rdBtn2Male.Checked == true) ;
            f.Gender_sg = "Male";

            if (rdBtn2Married.Checked == true)
                f.MaritalS_sg = "Married";
            else if (rdBtn2single.Checked == true) ;
            f.MaritalS_sg = "Single";

            f.Birth_sg = text2Year.Text + "/" + text2Month.Text + "/" + text2Day.Text;

            f.idNumber_sg = textID2.Text;

            f.EditPerson();




        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClsPerson f = new ClsPerson();

            f.idNumber_sg = textID2.Text;

            f.DeletePerson();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClsPerson f = new ClsPerson();
            f.FirstN_sg = text3FName.Text;
            f.Lastn_sg = text3LName.Text;

            DataSet ds = f.SearchByName();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables["tblCatch"];



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;

            textID3.Text = dataGridView1.Rows[i].Cells["ID_Number"].Value.ToString();

            text4FName.Text = dataGridView1.Rows[i].Cells["First_Name"].Value.ToString();

            text4LName.Text = dataGridView1.Rows[i].Cells["Last_Name"].Value.ToString();

            if (dataGridView1.Rows[i].Cells["Gender"].Value.ToString()=="Female")
                rdBtn3Female.Checked=true;
            else if (dataGridView1.Rows[i].Cells["Gender"].Value.ToString() == "Male")
                rdBtn3Male.Checked=true;

            if (dataGridView1.Rows[i].Cells["Marital_Status"].Value.ToString() == "Single")
                rdBtn3Single.Checked = true;
            if (dataGridView1.Rows[i].Cells["Marital_Status"].Value.ToString() == "Married")
                rdBtn3Married.Checked = true;

            String[] tt = dataGridView1.Rows[i].Cells["Birth_Date"].Value.ToString().Split('/');
            text3Year.Text = tt[0];
            text3Month.Text = tt[1];
            text3Day.Text = tt[2];

        }
    }
}