using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EntreMaos
{
    public partial class LoginFundo : Form
    {
        public MySqlConnection conector;
        public LoginFundo()
        {
            InitializeComponent();
            string data_source = "datasource=localhost;database=entremaos;username=root;password=Ec-fiox6;";
            conector = new MySqlConnection(data_source);
        }
        public static class UsuarioLogado
        {
            public static string Email { get; set; }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginFundo_Load(object sender, EventArgs e)
        {

        }

        private bool AutenticarUsuario(string email, string password)
        {
            try
            {
                conector.Open();
                string query = "SELECT COUNT(*) FROM AdministradorDoSite WHERE emailAdm = @email AND senhaAdm = @password";
                MySqlCommand command = new MySqlCommand(query, conector);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
                return false;
            }
            finally
            {
                conector.Close();
            }
        }

        private void botaoEntrarLogin_Click(object sender, EventArgs e)
        {
            string email = textBox_emailLogin.Text;
            string senha = textBox_senhaLogin.Text;

            if (AutenticarUsuario(email, senha))
            {
                UsuarioLogado.Email = email;
                MessageBox.Show("Login concluído com sucesso!");
                BuscarContemplados form2 = new BuscarContemplados();
                this.Hide();
                form2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos.");
            }
        }

        private void caixaLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
