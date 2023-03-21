using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Reflection.Emit;

namespace avtorization
{
    public partial class Form1 : Form
    {
        Class1 class1 = new Class1();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }        
        private void button1_Click(object sender, EventArgs e)
        {
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user from register where login_user ='{loginUser}' and password_user = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, class1.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                Form2 frm2 = new Form2(textBox1.Text);
                this.Hide();
                frm2.ShowDialog();
                this.Show();
                Close();             
            }
            else
                MessageBox.Show("Аккаунта не существует, либо были введены неверные данные", "Аккаунта не существует", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }        
    }    
}
