using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static EntreMaos.LoginFundo;

namespace EntreMaos
{
    public partial class BuscarCestasBasicas : Form
    {
        string data_source = "datasource=localhost;database=entremaos;username=root;password=Ec-fiox6;";

        public BuscarCestasBasicas()
        {
            InitializeComponent();
            PreencherComboBox(comboBoxContemplado, "SELECT contemplado_id, nomeContemplado FROM Contemplado", "nomeContemplado", "contemplado_id");
            PreencherComboBox(comboBoxCesta, "SELECT cestaBasica_id, dataRetirada FROM CestaBasica", "dataRetirada", "cestaBasica_id");
            buttonConcluir.Click += BotaoCadastrar_Click;
            this.Load += Form1_Load;
        }

        private void PreencherComboBox(ComboBox comboBox, string query, string displayMember, string valueMember)
        {
            string connectionString = "datasource=localhost;database=entremaos;username=root;password=Ec-fiox6;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    comboBox.DisplayMember = displayMember;
                    comboBox.ValueMember = valueMember;     
                    comboBox.DataSource = dt;              
                }
            }
        }

        private void BotaoCadastrar_Click(object sender, EventArgs e)
        {
            int contemplado_id = Convert.ToInt32(comboBoxContemplado.SelectedValue);
            int cestaBasica_id = Convert.ToInt32(comboBoxCesta.SelectedValue);
            string nomePreenchido = textBoxRecebido.Text;
            bool status = radioButtonSim.Checked;
            CadastrarInformacoes(contemplado_id, cestaBasica_id, nomePreenchido, status);
        }

        private void CadastrarInformacoes(int contemplado_id, int cestaBasica_id, string nome, bool status)
        {
            string connectionString = "datasource=localhost;database=entremaos;username=root;password=Ec-fiox6;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO CestaBasica_Contemplado (contemplado_id, cestaBasica_id, recebidoPor, recebido) VALUES(@contemplado_id, @cestaBasica_id, @nome, @status)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@contemplado_id", contemplado_id);
                    cmd.Parameters.AddWithValue("@cestaBasica_id", cestaBasica_id);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            BuscarContemplados cestas = new BuscarContemplados();
            this.Hide();
            cestas.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            CadastrarContemplados contempladoCadastro = new CadastrarContemplados();
            this.Hide();
            contempladoCadastro.ShowDialog();
            this.Close();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            BuscarContemplados cont = new BuscarContemplados();
            this.Hide();
            cont.ShowDialog();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panelGrande_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BuscarCestasBasicas_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            BuscaECadastroCestas cesta = new BuscaECadastroCestas();
            this.Hide();
            cesta.ShowDialog();
            this.Close();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label1cadastra_Click(object sender, EventArgs e)
        {
            CadastrarContemplados cast = new CadastrarContemplados();
            this.Hide();
            cast.ShowDialog();
            this.Close();
        }

        private void label2cadastra_Click(object sender, EventArgs e)
        {
            BuscarContemplados cont = new BuscarContemplados();
            this.Hide();
            cont.ShowDialog();
            this.Close();
        }

        private void label6cadastra_Click(object sender, EventArgs e)
        {
            Familiares fam = new Familiares();
            this.Hide();
            fam.ShowDialog();
            this.Close();
        }

        private void label3cadastra_Click(object sender, EventArgs e)
        {
            BuscaECadastroCestas cest2 = new BuscaECadastroCestas();
            this.Hide();
            cest2.ShowDialog();
            this.Close();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CarregarImagemPerfilAsync();
        }


        private async Task CarregarImagemPerfilAsync()
        {
            string query = "SELECT fotoAdm FROM administradordosite WHERE emailAdm = @EmailAdm";
            string imagemUrl = "";
            string emailLogado = UsuarioLogado.Email;

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EmailAdm", emailLogado);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        imagemUrl = result.ToString();
                    }
                }
            }
            if (!string.IsNullOrEmpty(imagemUrl))
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] imageBytes = await webClient.DownloadDataTaskAsync(imagemUrl);
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            ImagemPerfil.Image = System.Drawing.Image.FromStream(ms);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nenhuma imagem encontrada.");
            }
        }

        private void pictureBoxSair_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Você realmente deseja sair do sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void perfil(object sender, PaintEventArgs e)
        {
            
        }

        private void radioButtonNão_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonSim_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ImagemPerfil_Click(object sender, EventArgs e)
        {
            PerfilUsuario perf = new PerfilUsuario();
            this.Hide();
            perf.ShowDialog();
            this.Close();
        }
    }
}
