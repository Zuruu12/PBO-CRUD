using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace CRUD1
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection connection;
        private string constring = "Server=localhost;Port=5432;User Id=postgres;Password=QWERTY12;Database=crud;";
        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;

        public Form1()
        {
            InitializeComponent();
        }
        private void ShowData()
        {
            try
            {
                connection.Open();
                sql = @"SELECT * FROM coba";
                cmd = new NpgsqlCommand(sql, connection);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                connection.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error" + ex.Message);
            }
        }
        private void Createdata()
        {
            NpgsqlConnection connection = new NpgsqlConnection(constring);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO coba(NIM, Nama_Depan, Nama_Belakang, Birthday_Date, Jember_Address) " +
                "VALUES (@value1, @value2, @value3, @value4, @value5)", connection);
            command.Parameters.AddWithValue("value1", textBox1.Text);
            command.Parameters.AddWithValue("value2", textBox2.Text);
            command.Parameters.AddWithValue("value3", textBox3.Text);
            command.Parameters.AddWithValue("value4", textBox4.Text);
            command.Parameters.AddWithValue("value5", textBox5.Text);
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Success Insert data");
        }

        private void Editdata()
        {
            NpgsqlConnection connection = new NpgsqlConnection(constring);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("UPDATE coba SET Nama_Depan = @value2, Nama_Belakang = @value3, " +
                "Birthday_Date = @value4, Jember_Address = @value5 WHERE nim = @value1", connection);
            command.Parameters.AddWithValue("value2", textBox2.Text);
            command.Parameters.AddWithValue("value3", textBox3.Text);
            command.Parameters.AddWithValue("value4", textBox4.Text);
            command.Parameters.AddWithValue("value5", textBox5.Text);
            command.Parameters.AddWithValue("value1", textBox1.Text);
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Success Update data");
        }
        private void Deletedata()
        {
            NpgsqlConnection connection = new NpgsqlConnection(constring);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM coba WHERE nim=@value1", connection);
            command.Parameters.AddWithValue("value1", textBox1.Text);
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Success deleted data");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Createdata();
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Editdata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Deletedata();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(constring);
            
        }

    }
}