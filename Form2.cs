using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace _2_33
{
    public partial class Form2 : Form
    {


        // do something


        static string SS = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\ookp\2_33\2_33\Database1.mdf;Integrated Security=True";
        int g = 10000;
        double sum = 40;
        public Form2()
        {
            InitializeComponent();
        }
        int b = 1714;
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lab777.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter1.Fill(this.lab777.Table);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lb77.Table". При необходимости она может быть перемещена или удалена.
            this.tableTableAdapter.Fill(this.lb77.Table);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataset1.Grade". При необходимости она может быть перемещена или удалена.
            this.gradeTableAdapter.Fill(this.dataset1.Grade);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sub.Subjects". При необходимости она может быть перемещена или удалена.
            this.subjectsTableAdapter1.Fill(this.sub.Subjects);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataset1.Subjects". При необходимости она может быть перемещена или удалена.
            this.subjectsTableAdapter.Fill(this.dataset1.Subjects);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataset1.Teachers". При необходимости она может быть перемещена или удалена.
            this.teachersTableAdapter.Fill(this.dataset1.Teachers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataset1.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.dataset1.Users);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var select = "SELECT * FROM Users";
            var c = new SqlConnection(SS);
            c.Open();
            var dataAdapter = new SqlDataAdapter(select, c);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            c.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            // {

            string name = textBox4.Text;
            string role = textBox1.Text;
            string pass = textBox2.Text;
            string Id = textBox5.Text;
            string login = textBox3.Text;


            using (SqlConnection con = new SqlConnection(SS))
            {
                string insert = "INSERT INTO Users(Id,name,role,pass,login) VALUES (@Id,@name,@role,@pass,@login)";
                con.Open();
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.AddWithValue("@Id", Id.ToString());
                cmd.Parameters.AddWithValue("@name", name.ToString());
                cmd.Parameters.AddWithValue("@role", role.ToString());
                cmd.Parameters.AddWithValue("@pass", pass.ToString());
                cmd.Parameters.AddWithValue("@login", pass.ToString());
                cmd.ExecuteNonQuery();
                con.Close();
            }
            //}
            // catch (System.Data.SqlClient.SqlException)
            //{
            //     MessageBox.Show("This Id already taken");
            // }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            {
                using (SqlConnection con = new SqlConnection(SS))
                {
                    string insert = "DELETE FROM Users WHERE Id=" + toolStripTextBox1.Text;
                    con.Open();
                    SqlCommand cmd = new SqlCommand(insert, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            using (SqlConnection con = new SqlConnection(SS))
            {
                string insert = "INSERT INTO [Table](number,name) VALUES (@number,@name)";
                stopWatch.Start();


                int a;
                a = 99;
                for (int i = 0; i < g; i++)
                {
                    SqlCommand cmd = new SqlCommand(insert, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@number", a);
                    cmd.Parameters.AddWithValue("@name", "asd");

                    cmd.ExecuteNonQuery();
                    con.Close();

                }

                stopWatch.Stop();
                textBox9.Text = stopWatch.ElapsedMilliseconds.ToString();
                Console.WriteLine("Time elapsed: {0} milliseconds", stopWatch.ElapsedMilliseconds);

            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox6.Text;
            var select = "SELECT * FROM Subjects WHERE [Id]=" + textBox6.Text;
            var c = new SqlConnection(SS);
            c.Open();
            var dataAdapter = new SqlDataAdapter(select, c);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView4.ReadOnly = true;
            dataGridView4.DataSource = ds.Tables[0];
            c.Close();



        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox7.Text;
            var select = "SELECT Sub FROM Subjects WHERE [aud]=" + textBox7.Text;
            var c = new SqlConnection(SS);
            c.Open();
            var dataAdapter = new SqlDataAdapter(select, c);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView5.ReadOnly = true;
            dataGridView5.DataSource = ds.Tables[0];
            c.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox8.Text = "null";
            string name = textBox8.Text;
            var select = "SELECT AVG(Mark) FROM Grade";
            var c = new SqlConnection(SS);
            c.Open();
            var dataAdapter = new SqlDataAdapter(select, c);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView5.ReadOnly = true;
            dataGridView5.DataSource = ds.Tables[0];
            c.Close();
            sum = sum / 3;
            textBox8.Text = sum.ToString();
        }
        private int doit(int x)
        {
            int[] numbers = new int[] { 1 };
            var factorials = from n in numbers.AsParallel()
                             where n > 0
                             select doit(n);
            return x;
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            using (SqlConnection con = new SqlConnection(SS))
            {
                string insert = "INSERT INTO [Table](number,name) VALUES (@number,@name)";
                con.Open();
                SqlCommand cmd = new SqlCommand(insert, con);
                int a;
                a = 1;
                var result = Parallel.For(1, 1000, (i, state) =>
                {
                    cmd.Parameters.AddWithValue("@number", 77);
                    cmd.Parameters.AddWithValue("@name", "asd");
                    a++;
                    cmd.ExecuteNonQuery();


                });
                con.Close();
            }
            stopWatch.Stop();
            textBox9.Text = stopWatch.ElapsedMilliseconds.ToString();
            Console.WriteLine("Time elapsed: {0} milliseconds", stopWatch.ElapsedMilliseconds);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var select = "SELECT * FROM [Table]";
            var c = new SqlConnection(SS);
            c.Open();
            var dataAdapter = new SqlDataAdapter(select, c);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView7.ReadOnly = true;
            dataGridView7.DataSource = ds.Tables[0];
            c.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(SS))
            {
                string insert = "TRUNCATE TABLE [Table]";
                con.Open();
                SqlCommand cmd = new SqlCommand(insert, con);


                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            using (SqlConnection con = new SqlConnection(SS))
            {
                string insert = "INSERT INTO [Table](number,name) VALUES (@number,@name)";
                stopWatch.Start();


                int a;
                a = 99;
                for (int i = 0; i < b; i++)
                {
                    SqlCommand cmd = new SqlCommand(insert, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@number", a);
                    cmd.Parameters.AddWithValue("@name", "asd");

                    cmd.ExecuteNonQuery();
                    con.Close();

                }

                stopWatch.Stop();
                textBox9.Text = stopWatch.ElapsedMilliseconds.ToString();
                Console.WriteLine("Time elapsed: {0} milliseconds", stopWatch.ElapsedMilliseconds);

            }
        }
    }
}
