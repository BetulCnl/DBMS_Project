using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace tab_deneme
{ 
    public partial class CaptainsForm : Form
    {
        private SqlConnection connection;

        public CaptainsForm()
        {
            InitializeComponent();
            string connectionString = "Server=reyhan\\SQLEXPRESS;Database=Project_DB;Integrated Security=true";
            connection = new SqlConnection(connectionString);
        }

//LOAD
        private void CaptainsForm_Load(object sender, EventArgs e)
        {
            connection.Open();
        }

        private void CaptainsForm_Load_1(object sender, EventArgs e)
        {
            this.captainsTableAdapter2.Fill(this.project_DBDataSet2.Captains);
        }

//ADD BUTTON CLICK EVENT
        private void button4_Click(object sender, EventArgs e) 
        {
            try
            {
                string insertQuery = "INSERT INTO Captains (ID, FirstName, LastName, Address, Nationality, DateOfBirth, HireDate, Licenses) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7, @Value8)";

                //To open the connection if its not already open
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Value1", Convert.ToInt32(textBox10.Text)); //int
                    command.Parameters.AddWithValue("@Value2", textBox11.Text); //nvarchar
                    command.Parameters.AddWithValue("@Value3", textBox12.Text); //nvahrchar
                    command.Parameters.AddWithValue("@Value4", textBox13.Text); //nvarchar
                    command.Parameters.AddWithValue("@Value5", textBox14.Text); //nvarchar
                    command.Parameters.AddWithValue("@Value6", dateTimePicker1.Value.ToShortDateString()); //date
                    command.Parameters.AddWithValue("@Value7", dateTimePicker2.Value.ToShortDateString()); //date
                    command.Parameters.AddWithValue("@Value8", textBox17.Text); ///nvarchar
                    command.ExecuteNonQuery();
                    RefreshDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

//DELETE BUTTON CLICK EVENT
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "DELETE FROM Captains WHERE ID = @Value";

                //To open the connection if its not already open
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Value", Convert.ToInt32(textBox10.Text)); //int
                    command.ExecuteNonQuery();
                    RefreshDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


//UPDATE BUTTON CLICK EVENT
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE Captains SET FirstName = @FirstName, LastName = @LastName, Address = @Address, Nationality = @Nationality, DateOfBirth = @DateOfBirth, HireDate = @HireDate, Licenses = @Licenses WHERE ID = @ID";
                
                //To open the connection if its not already open
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox10.Text));
                    command.Parameters.AddWithValue("@FirstName", textBox11.Text); 
                    command.Parameters.AddWithValue("@LastName", textBox12.Text); 
                    command.Parameters.AddWithValue("@Address", textBox13.Text); 
                    command.Parameters.AddWithValue("@Nationality", textBox14.Text); 
                    command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value.ToShortDateString());
                    command.Parameters.AddWithValue("@HireDate", dateTimePicker2.Value.ToShortDateString());
                    command.Parameters.AddWithValue("@Licenses", textBox17.Text);
                    command.ExecuteNonQuery();
                    RefreshDataGridView(); 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
//REFRESH DATA GRID VIEW
        private void RefreshDataGridView()
        {
            try
            {
                this.captainsTableAdapter2.Fill(this.project_DBDataSet2.Captains);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing the DataGridView: " + ex.Message);
            }
        }

    }
}

