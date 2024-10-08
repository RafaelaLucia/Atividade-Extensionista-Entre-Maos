using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using static EntreMaos.LoginFundo;
using System.Net;

namespace EntreMaos
{
    public partial class BuscaECadastroCestas : Form
    {

        private MySqlConnection conector;
        private MySqlCommand comando;
        private MySqlDataAdapter dataAdapter;
        private DataTable dataTable;
        string data_source = "datasource=localhost;database=entremaos;username=root;password=Ec-fiox6;";


        public BuscaECadastroCestas()
        {
            InitializeComponent();
            buscarDados();
            this.Load += Form1_Load;
        }

        private void buscarDados()
        {
            conector = new MySqlConnection(data_source);
            try
            {
                conector.Open();
                string query = @"SELECT dataRetirada as 'Data de Retirada', recebidoPor as 'Recebido por', recebido as 'Recebido?', descricaoItens as 'Descrição dos itens' FROM CestaBasica_Contemplado
                INNER JOIN contemplado on CestaBasica_Contemplado.contemplado_id = contemplado.contemplado_id
                INNER JOIN cestabasica on CestaBasica_Contemplado.cestaBasica_id = cestabasica.cestaBasica_id;";

                comando = new MySqlCommand(query, conector);
                dataAdapter = new MySqlDataAdapter(comando);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridCestasList.DataSource = dataTable;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
            }
            finally
            {
                if (conector.State == ConnectionState.Open)
                    conector.Close();
            }
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void BotaoCadastrar_Click(object sender, EventArgs e)
        {
            DateTime dataSelecionada = monthCalendar1.SelectionStart;
            string textoPreenchido = textBox1Anotar.Text;
            CadastrarInformacoes(dataSelecionada, textoPreenchido);
        }

        private void CadastrarInformacoes(DateTime dataSelecionada, string textoPreenchido)
        {
            string query = "INSERT INTO CestaBasica (dataRetirada, descricaoItens) VALUES (@dataRetirada, @descricaoItens)";

            using (MySqlCommand cmd = new MySqlCommand(query, conector))
            {

                cmd.Parameters.AddWithValue("@dataRetirada", dataSelecionada.ToString("yyyy-MM-dd")); // Formata a data como YYYY-MM-DD para o MySQL
                cmd.Parameters.AddWithValue("@descricaoItens", textoPreenchido); // Texto capturado no TextBox
               
                try
                {
                    conector.Open(); // Abre a conexão com o banco
                    cmd.ExecuteNonQuery(); // Executa a inserção
                    MessageBox.Show("Cadastro realizado com sucesso!"); // Feedback para o usuário
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar: " + ex.Message); // Mostra erro, caso ocorra
                }
                finally
                {
                    conector.Close(); // Garante que a conexão será fechada
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            CadastrarContemplados cont = new CadastrarContemplados();
            this.Hide();
            cont.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            BuscarContemplados cont2 = new BuscarContemplados();
            this.Hide();
            cont2.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            BuscarCestasBasicas cesta = new BuscarCestasBasicas();
            this.Hide();
            cesta.ShowDialog();
            this.Close();
        }

        private void BuscaECadastroCestas_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxSair_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Você realmente deseja sair do sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1cesta_Click(object sender, EventArgs e)
        {
            CadastrarContemplados cesta2 = new CadastrarContemplados();
            this.Hide();
            cesta2.ShowDialog();
            this.Close();
        }

        private void label2cesta_Click(object sender, EventArgs e)
        {
            BuscarContemplados cont = new BuscarContemplados();
            this.Hide();
            cont.ShowDialog();
            this.Close();
        }

        private void label6cesta_Click(object sender, EventArgs e)
        {
            Familiares fam = new Familiares();
            this.Hide();
            fam.ShowDialog();
            this.Close();
        }

        private void label3cesta_Click(object sender, EventArgs e)
        {

        }

        private void label4cesta_Click(object sender, EventArgs e)
        {
            BuscarCestasBasicas cesta = new BuscarCestasBasicas();
            this.Hide();
            cesta.ShowDialog();
            this.Close();
        }

  

        private void ImagemPerfil_Click(object sender, EventArgs e)
        {

        }
    }
}
