using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace _2_33
{
    public partial class Form1 : Form
    {
        static string SS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ookp\2_33\2_33\Database1.mdf;Integrated Security=True";

        public Form1()
        {
            string login;
            string password;

            InitializeComponent();
            login = textBox1.Text;
            password = textBox2.Text;

            AutoCompleteStringCollection source = new AutoCompleteStringCollection()
        {
            "Кузнецов",
            "Иванов",
            "Петров",
            "Кустов"
        };
            textBox1.AutoCompleteCustomSource = source;
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(SS);

            string query = "Select * from Users Where login = '" + textBox1.Text.Trim() + "' and pass = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                Form2 objFrmMain = new Form2();

                this.Hide();
                objFrmMain.Show();
                sqlcon.Close();

            }
            else
            {
                MessageBox.Show("Check your username and password");

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
