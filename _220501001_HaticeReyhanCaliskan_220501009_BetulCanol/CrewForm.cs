using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace tab_deneme
{
    public partial class CrewForm : Form
    {
        private SqlConnection connection;
        public CrewForm()
        {
            InitializeComponent();
            string connectionString = "Server=reyhan\\SQLEXPRESS;Database=Project_DB;Integrated Security=true";
            connection = new SqlConnection(connectionString);
        }

//LOAD
        private void CrewForm_Load_1(object sender, EventArgs e)
        {
            connection.Open();
        }

        private void CrewForm_Load(object sender, EventArgs e)
        {
            this.crewTableAdapter.Fill(this.project_DBDataSet.Crew);
        }

        //ADD BUTTON CLICK EVENT
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO Crew (ID, FirstName, LastName, Address, Nationality, DateOfBirth, HireDate, Position) VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7, @Value8)";

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Value1", Convert.ToInt32(textBox1.Text)); //int
                    command.Parameters.AddWithValue("@Value2", textBox2.Text); //nvarchar
                    command.Parameters.AddWithValue("@Value3", textBox3.Text); //nvarchar
                    command.Parameters.AddWithValue("@Value4", textBox4.Text); //nvarchar
                    command.Parameters.AddWithValue("@Value5", textBox5.Text); //nvarchar
                    command.Parameters.AddWithValue("@Value6", dateTimePicker1.Value.ToShortDateString()); //date
                    command.Parameters.AddWithValue("@Value7", dateTimePicker2.Value.ToShortDateString()); //date
                    command.Parameters.AddWithValue("@Value8", textBox8.Text); //nvarchar
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
                string deleteQuery = "DELETE FROM Crew WHERE ID = @Value";

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Value", Convert.ToInt32(textBox1.Text)); // int
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
                string updateQuery = "UPDATE Crew SET FirstName = @FirstName, LastName = @LastName, Address = @Address, Nationality = @Nationality, DateOfBirth = @DateOfBirth, HireDate = @HireDate, Position = @Position WHERE ID = @ID";

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox1.Text)); // int
                    command.Parameters.AddWithValue("@FirstName", textBox2.Text);
                    command.Parameters.AddWithValue("@LastName", textBox3.Text);
                    command.Parameters.AddWithValue("@Address", textBox4.Text);
                    command.Parameters.AddWithValue("@Nationality", textBox5.Text);
                    command.Parameters.AddWithValue("@DateOfBirth", dateTimePicker1.Value.ToShortDateString());
                    command.Parameters.AddWithValue("@HireDate", dateTimePicker2.Value.ToShortDateString());
                    command.Parameters.AddWithValue("@Position", textBox8.Text);
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
                this.crewTableAdapter.Fill(this.project_DBDataSet.Crew);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing the DataGridView: " + ex.Message);
            }
        }

    }
    
}
