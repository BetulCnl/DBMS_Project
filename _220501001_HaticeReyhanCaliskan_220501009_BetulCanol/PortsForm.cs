using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace tab_deneme
{
    public partial class PortsForm : Form
    {
        private SqlConnection connection;
        public PortsForm()
        {
            InitializeComponent();
            string connectionString = "Server=reyhan\\SQLEXPRESS;Database=Project_DB;Integrated Security=true";
            connection = new SqlConnection(connectionString);
        }

        //LOAD
        private void PortsForm_Load(object sender, EventArgs e)
        {
            this.portsTableAdapter.Fill(this.project_DBDataSet.Ports);
        }
        private void PortsForm_Load_1(object sender, EventArgs e)
        {
            connection.Open();
        }

//ADD BUTTON CLICK EVENT
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = "INSERT INTO Ports (Name, Country, Population, RequiresPassport, DockingFee) VALUES (@Name, @Country, @Population, @RequiresPassport, @DockingFee)";

                //To open the connection if its not already open
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", textBox10.Text); //nvarchar
                    command.Parameters.AddWithValue("@Country", textBox11.Text); //nvarchar
                    command.Parameters.AddWithValue("@Population", Convert.ToInt32(textBox12.Text)); //int
                    command.Parameters.AddWithValue("@RequiresPassport", radioButton1.Checked); //bit
                    command.Parameters.AddWithValue("@DockingFee", Convert.ToDecimal(textBox14.Text));
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
                string deleteQuery = "DELETE FROM Ports WHERE Name = @Name";

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", textBox10.Text);
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
                string updateQuery = "UPDATE Ports SET Country = @Country, Population = @Population, RequiresPassport = @RequiresPassport, DockingFee = @DockingFee WHERE Name = @Name";

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", textBox10.Text); //nvarchar
                    command.Parameters.AddWithValue("@Country", textBox11.Text); //nvarchar
                    command.Parameters.AddWithValue("@Population", Convert.ToInt32(textBox12.Text)); //int
                    command.Parameters.AddWithValue("@RequiresPassport", radioButton1.Checked); //bit
                    command.Parameters.AddWithValue("@DockingFee", Convert.ToDecimal(textBox14.Text));
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
                this.portsTableAdapter.Fill(this.project_DBDataSet.Ports);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while refreshing the DataGridView: " + ex.Message);
            }
        }
    }
}
