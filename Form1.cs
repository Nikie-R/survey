using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace survey
{
    public partial class Form1 : Form
    {
        private const bool V = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Showing the form panel and hiding the first buttons
            pnlSform.Visible = true;
            btnFillSurvey.Visible = false;
            btnViewResults.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //hiding the panel and showing the first buttons
            pnlSform.Visible = false;
            btnFillSurvey.Visible = true;
            btnViewResults.Visible = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //declaration of varibales to be used
            string surname, first_name, contact_number;
            string age;
            bool pizza, pasta, pap_and_wors, chicken_stir_fry, beef_stir_fry, other = false;
            string eatOut, movie, tv, radio;

            //checking for empty fields
            if (txtBoxSurname.Text != " " || txtBoxFnames.Text != " " || txtBoxContact.Text != " "|| txtBoxAge.Text != " ")
            { 
                    //assigning values from input fields to variables
                    surname = txtBoxSurname.Text.ToString();
                first_name = txtBoxFnames.Text.ToString();
                contact_number = txtBoxContact.Text.ToString();
                string date = dateTimePicker1.Text.ToString();
                eatOut = (cmbBoxEatOut.SelectedIndex + 1).ToString();
                movie = (cmbBoxMovies.SelectedIndex + 1).ToString();
                tv = (cmbBoxTv.SelectedIndex + 1).ToString();
                radio = (cmbBoxRadio.SelectedIndex + 1).ToString();

                int count = 1;
                //getting checked items
                do
                {
                    if (checkedListBox1.Items[0] == checkedListBox1.SelectedItem)
                    {
                        pizza = true;
                    }

                    else
                    {
                        pizza = false;
                    }

                    if (checkedListBox1.Items[1] == checkedListBox1.SelectedItem)
                    {
                        pasta = true;
                    }

                    else
                    {
                        pasta = false;
                    }

                    if (checkedListBox1.Items[2] == checkedListBox1.SelectedItem)
                    {
                        pap_and_wors = true;
                    }

                    else
                    {
                        pap_and_wors = false;
                    }
                    if (checkedListBox1.Items[3] == checkedListBox1.SelectedItem)
                    {
                        chicken_stir_fry = true;
                    }

                    else
                    {
                        chicken_stir_fry = false;
                    }

                    if (checkedListBox1.Items[4] == checkedListBox1.SelectedItem)
                    {
                        beef_stir_fry = true;
                    }

                    else
                    {
                        beef_stir_fry = false;
                    }
                    if (checkedListBox1.Items[5] == checkedListBox1.SelectedItem)
                    {
                        other = true;
                    }

                    else
                    {
                        other = false;
                    }
                    count++;
                } while (count < 7);

                age = txtBoxAge.Text.ToString();


                //database connection
                System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();
                con.ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = E:\survey\survey\db\survey.mdb";

                //inserting data to database 
                try
                {
                    //for user table
                    String my_querry = "INSERT INTO [user](surname,first_name,contact_number,age,dateCompleted) ";
                    my_querry += "VALUES(" + surname + ", " + first_name + "," + contact_number + "," + age + "," + date + ")";


                    OleDbCommand cmd = new OleDbCommand(my_querry, con);


                    cmd.Parameters.AddWithValue("@surname", txtBoxSurname.Text);
                    cmd.Parameters.AddWithValue("@first_name", txtBoxFnames.Text);
                    cmd.Parameters.AddWithValue("@contact_number", txtBoxContact.Text);
                    cmd.Parameters.AddWithValue("@age", txtBoxAge.Text);
                    cmd.Parameters.AddWithValue("@dateCompleted", dateTimePicker1.Text);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //for user_food table
                    my_querry = "INSERT INTO [user_food] (pizza,pasta,pap_and_wors,chicken_stir_fry,beef_stir_fry,other) VALUES" +
                        "(" + pizza + "," + pasta + "," + pap_and_wors + "," + chicken_stir_fry + "," + beef_stir_fry + "," + other + ")";
                    cmd.CommandText = my_querry;
                    cmd.Parameters.AddWithValue("@pizza", pizza);
                    cmd.Parameters.AddWithValue("@pap_and_wors", pap_and_wors);
                    cmd.Parameters.AddWithValue("@chicken_stir_fry", chicken_stir_fry);
                    cmd.Parameters.AddWithValue("@beef_stir_fry", beef_stir_fry);
                    cmd.Parameters.AddWithValue("@other", other);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    //for user_likes
                    my_querry = "INSERT INTO [user_likes](eatOut,movie,tv,radio) VALUES(" + eatOut + "," + movie + "," + tv + "," + radio + ")";
                    cmd.CommandText = my_querry;
                    cmd.Parameters.AddWithValue("@eatOut", eatOut);
                    cmd.Parameters.AddWithValue("@movie", movie);
                    cmd.Parameters.AddWithValue("@tv", tv);
                    cmd.Parameters.AddWithValue("@radio", radio);

                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();


                    MessageBox.Show("Data saved successfuly...!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to" + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields");
            }

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
           
        }

        private void txtBoxDate_Click(object sender, EventArgs e)
        {
            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //showing the first buttons and hiding the results panel
            pnlResults.Visible = false;
            btnFillSurvey.Visible = true;
            btnViewResults.Visible = true;

        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            
            btnViewResults.Visible = false;
            btnFillSurvey.Visible = false;
            pnlResults.Visible = true;
            //extracting dat from databse and populating results labels
            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection();
            con.ConnectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = E:\survey\survey\db\survey.mdb";

            string my_querry = "SELECT MAX(age) FROM [user]";
            string result="";
            OleDbCommand cmd = new OleDbCommand(my_querry, con);
            cmd.Connection = con; 
            

            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result = reader.GetValue(0).ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                
                
            }

            lblMaxAge.Text = result;

            my_querry = "SELECT MIN(age) FROM [user]";
            cmd.CommandText = my_querry;
            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result = reader.GetValue(0).ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();

            }

            lblMinAge.Text = result;

            my_querry = "SELECT COUNT(ID) FROM [user]";
            cmd.CommandText = my_querry;
            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result = reader.GetValue(0).ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();

            }
            lblTotSurv.Text = result;

            my_querry = "SELECT AVG(age) FROM [user]";
            cmd.CommandText = my_querry;
            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result = reader.GetValue(0).ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();

            }
            lblAvgAge.Text = result;


            my_querry = "SELECT COUNT(id) FROM [user_food] where pizza=true";
            cmd.CommandText = my_querry;
            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result = reader.GetValue(0).ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();

            }
            double perc;

            perc = Convert.ToInt32(result) /Convert.ToInt32(lblTotSurv.Text) *100 ;
            lblLikePizza.Text = result + "%";

            my_querry = "SELECT COUNT(id) FROM [user_food] where pasta=true";
            cmd.CommandText = my_querry;
            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result = reader.GetValue(0).ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();

            }
            

            perc = Convert.ToInt32(result) / Convert.ToInt32(lblTotSurv.Text) * 100;
            lblLikePasta.Text = result + "%";


            my_querry = "SELECT COUNT(id) FROM [user_food] where pap_and_wors=true";
            cmd.CommandText = my_querry;
            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result = reader.GetValue(0).ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();

            }
            

            perc = Convert.ToInt32(result) / Convert.ToInt32(lblTotSurv.Text) * 100;
            lblLikePap.Text = result + "%";


            my_querry = "SELECT AVG(eatOut) FROM [user_likes] ";
            cmd.CommandText = my_querry;
            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result = reader.GetValue(0).ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();

            }

            lblEatOut.Text = result;

            my_querry = "SELECT AVG(movie) FROM [user_likes] ";
            cmd.CommandText = my_querry;
            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result = reader.GetValue(0).ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();

            }

            lblMovies.Text = result;

            my_querry = "SELECT AVG(tv) FROM [user_likes] ";
            cmd.CommandText = my_querry;
            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result = reader.GetValue(0).ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();

            }
            lblTv.Text = result;

            my_querry = "SELECT AVG(radio) FROM [user_likes] ";
            cmd.CommandText = my_querry;
            try
            {
                con.Open();
                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    result = reader.GetValue(0).ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();

            }
            lblRadio.Text = result;

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
