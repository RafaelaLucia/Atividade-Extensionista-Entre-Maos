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
    public partial class CadastrarContemplados : Form
    {
        string data_source = "datasource=localhost;database=entremaos;username=root;password=Ec-fiox6;";

        public CadastrarContemplados()
        {
            InitializeComponent();
            buttonCadastro.Click += new EventHandler(BotaoCadastrar_Clique);
            this.Load += new EventHandler(FormularioCadastro_Load);
            this.Load += Form1_Load;
        }

        private void FormularioCadastro_Load(object sender, EventArgs e)
        {
            CarregarComboBoxEstadoCivil();
            CarregarComboBoxPostoConvenio();
            CarregarComboBoxMoraCom();
            CarregarComboBoxResidencia();
        }

        private void CarregarComboBoxEstadoCivil()
        {
            string query = "SELECT estadoCivil_id, estadoCivil FROM EstadoCivil";
            DataTable dataTable = ObterDados(query);

            comboBoxEstadoC.DataSource = dataTable;
            comboBoxEstadoC.DisplayMember = "estadoCivil"; 
            comboBoxEstadoC.ValueMember = "estadoCivil_id"; 
        }

        private void CarregarComboBoxPostoConvenio()
        {
            string query = "SELECT postoConvenio_id, nomeConvenio FROM Convenio";
            DataTable dataTable = ObterDados(query);

            comboBoxConvenio.DataSource = dataTable;
            comboBoxConvenio.DisplayMember = "nomeConvenio";
            comboBoxConvenio.ValueMember = "postoConvenio_id";
        }

        private void CarregarComboBoxMoraCom()
        {
            string query = "SELECT moraCom_id, moraCom FROM MoraCom";
            DataTable dataTable = ObterDados(query);

            comboBoxMoraCom.DataSource = dataTable;
            comboBoxMoraCom.DisplayMember = "moraCom";
            comboBoxMoraCom.ValueMember = "moraCom_id";
        }

        private void CarregarComboBoxResidencia()
        {
            string query = "SELECT residencia_id, tipoResidencia FROM Residencia";
            DataTable dataTable = ObterDados(query);

            comboBoxResidencia.DataSource = dataTable;
            comboBoxResidencia.DisplayMember = "tipoResidencia";
            comboBoxResidencia.ValueMember = "residencia_id";
        }

        private DataTable ObterDados(string query)
        {
            DataTable dataTable = new DataTable();
            string connectionString = "datasource=localhost;database=entremaos;username=root;password=Ec-fiox6;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dataTable);
                }
            }

            return dataTable;
        }

        private void CadastrarInformacoes(string caminhoImagem, string[] camposTexto, bool? status, DateTime dataSelecionada, int idCombo1, int idCombo2, int idCombo3, int idCombo4)
        {
            string connectionString = "datasource=localhost;database=entremaos;username=root;password=Ec-fiox6;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO TabelaCadastro 
                             (nomeContemplado, dataNascimento, RG, CPF, escolaridade, endereco, naturalidade, telefone, bairro, ajudaGoverno, 
                              gastoComMedicamento, dívida, rendaFamiliar, problemaComCigarroOuDrogas, problemaComBebida, deficiencia, responsavelFamilia, tamanhoFamilia, anotacoesGerais, status, dataSelecionada, idCombo1, idCombo2, idCombo3, idCombo4, fotoContemplado)
                             VALUES (@campo1, @campo2, @campo3, @campo4, @campo5, @campo6, @campo7, @campo8, @campo9, @campo10,
                                     @campo11, @campo12, @campo13, @campo14, @campo15, @status, @dataSelecionada, @idCombo1, @idCombo2, @idCombo3, @idCombo4, @caminhoImagem)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                  
                    for (int i = 0; i < 15; i++)
                    {
                        cmd.Parameters.AddWithValue($"@campo{i + 1}", camposTexto[i]);
                    }
                    cmd.Parameters.AddWithValue("@status", status.HasValue ? (object)status.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@dataSelecionada", dataSelecionada);
                    cmd.Parameters.AddWithValue("@idCombo1", idCombo1);
                    cmd.Parameters.AddWithValue("@idCombo2", idCombo2);
                    cmd.Parameters.AddWithValue("@idCombo3", idCombo3);
                    cmd.Parameters.AddWithValue("@idCombo4", idCombo4);
                    cmd.Parameters.AddWithValue("@caminhoImagem", caminhoImagem);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cadastro realizado com sucesso!");
        }



        private void label5_Click(object sender, EventArgs e)
        {

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

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void BotaoEscolherImagem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Imagens (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|Todos os arquivos (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string caminhoArquivo = openFileDialog.FileName;
                    textBoxlink.Text = caminhoArquivo;
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CadastrarContemplados_Load(object sender, EventArgs e)
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

        private void BotaoCadastrar_Clique(object sender, EventArgs e)
        {
            try {

                buttonCadastro.Enabled = false;


            string nomeContemplado = textBoxnome.Text;

                DateTime dataNascimento;
                bool dataValida = DateTime.TryParse(textBoxdataNascimento.Text, out dataNascimento); 

                if (!dataValida)
                {
                    MessageBox.Show("A data de nascimento está em um formato incorreto. Utilize o formato DD/MM/AAAA.");
                    return;
                } 

                string RG = textBoxrg.Text;
            string CPF = textBoxcpf.Text;
            string escolaridade = textBoxescolaridade.Text;
            string endereco = textBoxendereco.Text;
            string naturalidade = textBoxnaturalidade.Text;
            string telefone = textBoxtelefone.Text;
            string bairro = textBoxbairro.Text;
            string ajudaGoverno = textBoxGoverno.Text;
            string gastoComMedicamento = textBoxMedicamento.Text;
            string divida = textBoxDivida.Text;
            string rendaFamiliar = textBoxRenda.Text;
            string problemaComCigarroOuDrogas = textBoxDroga.Text;
            string problemaComBebida = textBoxBebida.Text;
            string deficiencia = textBoxDeficiencia.Text;
            string responsavelFamilia = textBoxResponsavel.Text;
            int tamanhoFamilia = int.Parse(textBoxTamanho.Text);
            string anotacoesGerais = textBoxAnotacoes.Text;
            string indicacao = textBoxIndicacao.Text;
            string nomePosto = textBoxPosto.Text;
            string aluguel = textBoxAluguel.Text;
            string fotoContemplado = textBoxlink.Text; 
            int estadoCivil_id = Convert.ToInt32(comboBoxEstadoC.SelectedValue);
            int postoConvenio_id = Convert.ToInt32(comboBoxConvenio.SelectedValue);
            int moraCom_id = Convert.ToInt32(comboBoxMoraCom.SelectedValue);
            int residencia_id = Convert.ToInt32(comboBoxResidencia.SelectedValue);

            bool temVeiculo = radioButtonVeiculoSim.Checked;
            bool necessidadeDeLeite = radioButtonLeiteSim.Checked;
            bool necessidadeDeFralda = radioButtonFraldaSim.Checked;

            DateTime dataCadastro = monthCalendarCadastro.SelectionStart;
            bool desligamento = checkBoxDesligado.Checked;

            CadastrarInformacoes(
                estadoCivil_id, postoConvenio_id, moraCom_id, residencia_id,
                nomeContemplado, dataNascimento, RG, CPF, escolaridade, endereco, naturalidade,
                telefone, bairro, ajudaGoverno, gastoComMedicamento, divida, rendaFamiliar,
                temVeiculo, necessidadeDeLeite, necessidadeDeFralda, problemaComCigarroOuDrogas,
                problemaComBebida, deficiencia, responsavelFamilia, tamanhoFamilia, anotacoesGerais,
                dataCadastro, desligamento, indicacao, nomePosto, aluguel, fotoContemplado
            );

            MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
         catch (Exception ex)
        {
        MessageBox.Show("Erro ao realizar o cadastro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
            finally
            {
                buttonCadastro.Enabled = true;
            }

        }

        private void CadastrarInformacoes(
    int estadoCivil_id, int postoConvenio_id, int moraCom_id, int residencia_id,
    string nomeContemplado, DateTime dataNascimento, string RG, string CPF, string escolaridade,
    string endereco, string naturalidade, string telefone, string bairro, string ajudaGoverno,
    string gastoComMedicamento, string divida, string rendaFamiliar, bool temVeiculo,
    bool necessidadeDeLeite, bool necessidadeDeFralda, string problemaComCigarroOuDrogas,
    string problemaComBebida, string deficiencia, string responsavelFamilia, int tamanhoFamilia,
    string anotacoesGerais, DateTime dataCadastro, bool desligamento, string indicacao,
    string nomePosto, string aluguel, string fotoContemplado)
        {
            string connectionString = "datasource=localhost;database=entremaos;username=root;password=Ec-fiox6;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Contemplado (estadoCivil_id, postoConvenio_id, moraCom_id, residencia_id, " +
                               "nomeContemplado, dataNascimento, RG, CPF, escolaridade, endereco, naturalidade, telefone, bairro, " +
                               "ajudaGoverno, gastoComMedicamento, dívida, rendaFamiliar, temVeiculo, necessidadeDeLeite, necessidadeDeFralda, " +
                               "problemaComCigarroOuDrogas, problemaComBebida, deficiencia, responsavelFamilia, tamanhoFamilia, " +
                               "anotacoesGerais, cadastro, desligamento, indicacao, nomePosto, aluguel, fotoContemplado) " +
                               "VALUES (@estadoCivil_id, @postoConvenio_id, @moraCom_id, @residencia_id, @nomeContemplado, @dataNascimento, " +
                               "@RG, @CPF, @escolaridade, @endereco, @naturalidade, @telefone, @bairro, @ajudaGoverno, @gastoComMedicamento, " +
                               "@divida, @rendaFamiliar, @temVeiculo, @necessidadeDeLeite, @necessidadeDeFralda, @problemaComCigarroOuDrogas, " +
                               "@problemaComBebida, @deficiencia, @responsavelFamilia, @tamanhoFamilia, @anotacoesGerais, @cadastro, @desligamento, " +
                               "@indicacao, @nomePosto, @aluguel, @fotoContemplado)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@estadoCivil_id", estadoCivil_id);
                    cmd.Parameters.AddWithValue("@postoConvenio_id", postoConvenio_id);
                    cmd.Parameters.AddWithValue("@moraCom_id", moraCom_id);
                    cmd.Parameters.AddWithValue("@residencia_id", residencia_id);
                    cmd.Parameters.AddWithValue("@nomeContemplado", nomeContemplado);
                    cmd.Parameters.AddWithValue("@dataNascimento", dataNascimento);
                    cmd.Parameters.AddWithValue("@RG", RG);
                    cmd.Parameters.AddWithValue("@CPF", CPF);
                    cmd.Parameters.AddWithValue("@escolaridade", escolaridade);
                    cmd.Parameters.AddWithValue("@endereco", endereco);
                    cmd.Parameters.AddWithValue("@naturalidade", naturalidade);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@bairro", bairro);
                    cmd.Parameters.AddWithValue("@ajudaGoverno", ajudaGoverno);
                    cmd.Parameters.AddWithValue("@gastoComMedicamento", gastoComMedicamento);
                    cmd.Parameters.AddWithValue("@divida", divida);
                    cmd.Parameters.AddWithValue("@rendaFamiliar", rendaFamiliar);
                    cmd.Parameters.AddWithValue("@temVeiculo", temVeiculo);
                    cmd.Parameters.AddWithValue("@necessidadeDeLeite", necessidadeDeLeite);
                    cmd.Parameters.AddWithValue("@necessidadeDeFralda", necessidadeDeFralda);
                    cmd.Parameters.AddWithValue("@problemaComCigarroOuDrogas", problemaComCigarroOuDrogas);
                    cmd.Parameters.AddWithValue("@problemaComBebida", problemaComBebida);
                    cmd.Parameters.AddWithValue("@deficiencia", deficiencia);
                    cmd.Parameters.AddWithValue("@responsavelFamilia", responsavelFamilia);
                    cmd.Parameters.AddWithValue("@tamanhoFamilia", tamanhoFamilia);
                    cmd.Parameters.AddWithValue("@anotacoesGerais", anotacoesGerais);
                    cmd.Parameters.AddWithValue("@cadastro", dataCadastro);
                    cmd.Parameters.AddWithValue("@desligamento", desligamento);
                    cmd.Parameters.AddWithValue("@indicacao", indicacao);
                    cmd.Parameters.AddWithValue("@nomePosto", nomePosto);
                    cmd.Parameters.AddWithValue("@aluguel", aluguel);
                    cmd.Parameters.AddWithValue("@fotoContemplado", fotoContemplado);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void label1cadastra_Click(object sender, EventArgs e)
        {

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
            BuscaECadastroCestas cest = new BuscaECadastroCestas();
            this.Hide();
            cest.ShowDialog();
            this.Close();
        }

        private void label4cadastra_Click(object sender, EventArgs e)
        {
            BuscarCestasBasicas cest2 = new BuscarCestasBasicas();
            this.Hide();
            cest2.ShowDialog();
            this.Close();
        }
    }
}
