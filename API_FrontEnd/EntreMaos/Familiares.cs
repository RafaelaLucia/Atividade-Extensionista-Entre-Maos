using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Familiares : Form
    {

        private MySqlConnection conector;
        private MySqlCommand comando;
        private MySqlDataAdapter dataAdapter;
        private DataTable dataTable;
        string data_source = "datasource=localhost;database=entremaos;username=root;password=Ec-fiox6;";


        public Familiares()
        {
            InitializeComponent();
            this.Load += Form1_Load;
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

        private void label1Fam_Click(object sender, EventArgs e)
        {
            CadastrarContemplados contemplado = new CadastrarContemplados();
            this.Hide();
            contemplado.ShowDialog();
            this.Close();
        }

        private void label2Fam_Click(object sender, EventArgs e)
        {
            BuscarContemplados contemplado2 = new BuscarContemplados();
            this.Hide();
            contemplado2.ShowDialog();
            this.Close();
        }

        private void label6Fam_Click(object sender, EventArgs e)
        {

        }

        private void label3Fam_Click(object sender, EventArgs e)
        {
            BuscaECadastroCestas cesta = new BuscaECadastroCestas();
            this.Hide();
            cesta.ShowDialog();
            this.Close();
        }

        private void label4Fam_Click(object sender, EventArgs e)
        {
            BuscarCestasBasicas cesta2 = new BuscarCestasBasicas();
            this.Hide();
            cesta2.ShowDialog();
            this.Close();
        }

        private void Familiares_Load(object sender, EventArgs e)
        {
            PreencherComboBoxes();
        }

        private void PreencherComboBoxes()
        {
            string queryContemplados = "SELECT contemplado_id, nomeContemplado FROM contemplado";
            string queryMoradores = "SELECT morador_id, nomeFamiliar FROM morador";

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(queryContemplados, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxContemplado.Items.Add(new { Id = reader["contemplado_id"], Nome = reader["nomeContemplado"] });
                        }
                    }
                }
                using (MySqlCommand cmd = new MySqlCommand(queryMoradores, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxMorador.Items.Add(new { Id = reader["morador_id"], Nome = reader["nomeFamiliar"] });
                        }
                    }
                }
            }
            comboBoxContemplado.DisplayMember = "Nome";
            comboBoxMorador.DisplayMember = "Nome";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            var contempladoSelecionado = (dynamic)comboBoxContemplado.SelectedItem;
            var moradorSelecionado = (dynamic)comboBoxMorador.SelectedItem;

            if (contempladoSelecionado == null || moradorSelecionado == null)
            {
                MessageBox.Show("Selecione um Contemplado e um Morador antes de cadastrar.");
                return;
            }

            string queryInsert = "INSERT INTO ComposicaoFamiliar (contemplado_id, morador_id) VALUES (@ContempladoId, @MoradorId)";

            using (MySqlConnection conn = new MySqlConnection(data_source))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(queryInsert, conn))
                {
                    cmd.Parameters.AddWithValue("@ContempladoId", contempladoSelecionado.Id);
                    cmd.Parameters.AddWithValue("@MoradorId", moradorSelecionado.Id);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cadastro realizado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao cadastrar: " + ex.Message);
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Você realmente deseja sair do sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit(); 
            }
        }

        private void btnCadastrarMorador_Click(object sender, EventArgs e)
        {
            string nomeFamiliar = textBoxnome.Text;
            string parentesco = textBoxparentesco.Text;
            string situacaoAtual = textBoxsituacao.Text;
            DateTime dataNascimento = monthCalendarFamilia.SelectionStart; 
            if (string.IsNullOrEmpty(nomeFamiliar) || string.IsNullOrEmpty(parentesco) || string.IsNullOrEmpty(situacaoAtual))
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
                return;
            }
            string connectionString = "datasource=localhost;database=entremaos;username=root;password=Ec-fiox6;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO morador (nomeFamiliar, parentesco, situacaoAtual, dataNascimento) VALUES (@nomeFamiliar, @parentesco, @situacaoAtual, @dataNascimento)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nomeFamiliar", nomeFamiliar);
                        cmd.Parameters.AddWithValue("@parentesco", parentesco);
                        cmd.Parameters.AddWithValue("@situacaoAtual", situacaoAtual);
                        cmd.Parameters.AddWithValue("@dataNascimento", dataNascimento);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Morador cadastrado com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Erro ao cadastrar o morador.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }

    }
}
