using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace tab_deneme
{
    public partial class VoyagesForm : Form
    {
        private SqlConnection connection;
        public VoyagesForm()
        {
            InitializeComponent();
            string connectionString = "Server=reyhan\\SQLEXPRESS;Database=Project_DB;Integrated Security=true";
            connection = new SqlConnection(connectionString);
        }

//LOAD
        private void VoyagesForm_Load(object sender, EventArgs e)
        {
            this.voyagesTableAdapter.Fill(this.project_DBDataSet.Voyages);
        }
        private void VoyagesForm_Load1(object sender, EventArgs e)
        {
            connection.Open();
        }

//ADD BUTTON CLICK EVENT
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO Voyages (ID, ShipSerialNumber, CaptainID, CrewID, DepartureDate, ReturnDate, DeparturePort) VALUES (@ID, @ShipSerialNumber, @CaptainID, @CrewID, @DepartureDate, @ReturnDate, @DeparturePort)";

                //To open the connection if its not already open
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox10.Text));
                    command.Parameters.AddWithValue("@ShipSerialNumber", Convert.ToInt32(textBox11.Text));
                    command.Parameters.AddWithValue("@CaptainID", Convert.ToInt32(textBox12.Text));
                    command.Parameters.AddWithValue("@CrewID", Convert.ToInt32(textBox13.Text));
                    command.Parameters.AddWithValue("@DepartureDate", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@ReturnDate", dateTimePicker2.Value);
                    command.Parameters.AddWithValue("@DeparturePort", textBox16.Text);
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
                string deleteQuery = "DELETE FROM Voyages WHERE ID = @ID";

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox10.Text));
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
                string updateQuery = "UPDATE Voyages SET ShipSerialNumber = @ShipSerialNumber, CaptainID = @CaptainID, CrewID = @CrewID, DepartureDate = @DepartureDate, ReturnDate = @ReturnDate, DeparturePort = @DeparturePort WHERE ID = @ID";

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", Convert.ToInt32(textBox10.Text));
                    command.Parameters.AddWithValue("@ShipSerialNumber", Convert.ToInt32(textBox11.Text));
                    command.Parameters.AddWithValue("@CaptainID", Convert.ToInt32(textBox12.Text));
                    command.Parameters.AddWithValue("@CrewID", Convert.ToInt32(textBox13.Text));
                    command.Parameters.AddWithValue("@DepartureDate", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@ReturnDate", dateTimePicker2.Value);
                    command.Parameters.AddWithValue("@DeparturePort", textBox16.Text);
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
                this.voyagesTableAdapter.Fill(this.project_DBDataSet.Voyages);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing the DataGridView: " + ex.Message);
            }
        }
    }
}