using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace tab_deneme
{
    public partial class ShipsForm : Form
    {
        private SqlConnection connection;

        public ShipsForm()
        {
            InitializeComponent();
            string connectionString = "Server=reyhan\\SQLEXPRESS;Database=Project_DB;Integrated Security=true";
            connection = new SqlConnection(connectionString);
        }

        // LOAD
        private void ShipsForm_Load(object sender, EventArgs e)
        {
            this.shipsTableAdapter.Fill(this.project_DBDataSet.Ships);
        }

// ADD BUTTON CLICK EVENT
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string shipType = ""; // Variable to store the selected ship type

                // Check which radio button is checked to determine the ship type
                if (radioButton1.Checked)
                {
                    shipType = "Passenger";
                    if (string.IsNullOrEmpty(textBox15.Text))
                    {
                        MessageBox.Show("Please enter Passenger Capacity for Passenger type ship.");
                        return;
                    }
                }
                else if (radioButton2.Checked)
                {
                    shipType = "Petrol";
                    if (string.IsNullOrEmpty(textBox16.Text))
                    {
                        MessageBox.Show("Please enter Petrol Capacity for Petrol type ship.");
                        return;
                    }
                }
                else if (radioButton3.Checked)
                {
                    shipType = "Container";
                    if (string.IsNullOrEmpty(textBox17.Text) || string.IsNullOrEmpty(textBox1.Text))
                    {
                        MessageBox.Show("Please enter Container Capacity and Maximum Weight for Containers for Container type ship.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Ship Type.");
                    return;
                }

                string insertQuery = "INSERT INTO Ships (SerialNumber, Name, Weight, YearOfConstruction, ShipType, PassengerCapacity, PetrolCapacityInLiters, ContainerCapacity, MaximumWeightForContainers) VALUES (@SerialNumber, @Name, @Weight, @YearOfConstruction, @ShipType, @PassengerCapacity, @PetrolCapacityInLiters, @ContainerCapacity, @MaximumWeightForContainers)";

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@SerialNumber", Convert.ToInt32(textBox10.Text));
                    command.Parameters.AddWithValue("@Name", textBox11.Text);
                    command.Parameters.AddWithValue("@Weight", Convert.ToDouble(textBox12.Text));
                    command.Parameters.AddWithValue("@YearOfConstruction", Convert.ToInt32(textBox13.Text));
                    command.Parameters.AddWithValue("@ShipType", shipType); // Use the selected ship type
                    command.Parameters.AddWithValue("@PassengerCapacity", shipType == "Passenger" ? Convert.ToInt32(textBox15.Text) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PetrolCapacityInLiters", shipType == "Petrol" ? Convert.ToDouble(textBox16.Text) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ContainerCapacity", shipType == "Container" ? Convert.ToInt32(textBox17.Text) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@MaximumWeightForContainers", shipType == "Container" ? Convert.ToDouble(textBox1.Text) : (object)DBNull.Value);
                    command.ExecuteNonQuery();
                    RefreshDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        // DELETE BUTTON CLICK EVENT
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteQuery = "DELETE FROM Ships WHERE SerialNumber = @SerialNumber";

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@SerialNumber", Convert.ToInt32(textBox10.Text));
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
                string shipType = ""; // Variable to store the selected ship type

                // Check which radio button is checked to determine the ship type
                if (radioButton1.Checked)
                {
                    shipType = "Passenger";
                    if (string.IsNullOrEmpty(textBox15.Text))
                    {
                        MessageBox.Show("Please enter Passenger Capacity for Passenger type ship.");
                        return;
                    }
                }
                else if (radioButton2.Checked)
                {
                    shipType = "Petrol";
                    if (string.IsNullOrEmpty(textBox16.Text))
                    {
                        MessageBox.Show("Please enter Petrol Capacity for Petrol type ship.");
                        return;
                    }
                }
                else if (radioButton3.Checked)
                {
                    shipType = "Container";
                    if (string.IsNullOrEmpty(textBox17.Text) || string.IsNullOrEmpty(textBox1.Text))
                    {
                        MessageBox.Show("Please enter Container Capacity and Maximum Weight for Containers for Container type ship.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Ship Type.");
                    return;
                }

                string updateQuery = "UPDATE Ships SET Name = @Name, Weight = @Weight, YearOfConstruction = @YearOfConstruction, ShipType = @ShipType, PassengerCapacity = @PassengerCapacity, PetrolCapacityInLiters = @PetrolCapacityInLiters, ContainerCapacity = @ContainerCapacity, MaximumWeightForContainers = @MaximumWeightForContainers WHERE SerialNumber = @SerialNumber";

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@SerialNumber", Convert.ToInt32(textBox10.Text));
                    command.Parameters.AddWithValue("@Name", textBox11.Text);
                    command.Parameters.AddWithValue("@Weight", Convert.ToDouble(textBox12.Text));
                    command.Parameters.AddWithValue("@YearOfConstruction", Convert.ToInt32(textBox13.Text));
                    command.Parameters.AddWithValue("@ShipType", shipType); // Use the selected ship type
                    command.Parameters.AddWithValue("@PassengerCapacity", shipType == "Passenger" ? Convert.ToInt32(textBox15.Text) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PetrolCapacityInLiters", shipType == "Petrol" ? Convert.ToDouble(textBox16.Text) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ContainerCapacity", shipType == "Container" ? Convert.ToInt32(textBox17.Text) : (object)DBNull.Value);
                    command.Parameters.AddWithValue("@MaximumWeightForContainers", shipType == "Container" ? Convert.ToDouble(textBox1.Text) : (object)DBNull.Value);
                    command.ExecuteNonQuery();
                    RefreshDataGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // REFRESH DATA GRID VIEW
        private void RefreshDataGridView()
        {
            try
            {
                this.shipsTableAdapter.Fill(this.project_DBDataSet.Ships);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing the DataGridView: " + ex.Message);
            }
        }
    }
}