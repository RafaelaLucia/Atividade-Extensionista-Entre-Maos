using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static EntreMaos.LoginFundo;

namespace EntreMaos
{
    public partial class BuscarContemplados : Form
    {

        private MySqlConnection conector;
        private MySqlCommand comando;
        private MySqlDataAdapter dataAdapter;
        private DataTable dataTable;
        string data_source = "datasource=localhost;database=entremaos;username=root;password=Ec-fiox6;";


        public BuscarContemplados()
        {
            InitializeComponent();
            buscarDados();
            //CarregarImagemPerfilAsync(); 
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


        private void buscarDados2()
        {
            conector = new MySqlConnection(data_source);
            try
            {
                conector.Open();
                string sql_select_contemplado = "SELECT nomeContemplado as 'Nome do Contemplado(a)', dataNascimento as 'Data de Nascimento', RG, CPF, " +
                "escolaridade, endereco as 'Endereço', naturalidade, telefone, bairro, ajudaGoverno as 'Possui Ajuda do Governo?'," +
                "gastoComMedicamento as 'Gastos com Medicamento?', dívida, rendaFamiliar as 'Renda Familiar', necessidadeDeLeite as 'Possui Necessidade de Leite?'," +
                "necessidadeDeFralda as 'Possui Necessidade de Fralda?', problemaComCigarroOuDrogas as 'Problema com Cigarro ou Drogas?', problemaComBebida as 'Problema com Bebida?',"+
                "deficiencia, responsavelFamilia as 'Responsável pela Família', tamanhoFamilia as 'Tamanho da Família', anotacoesGerais as 'Anotações Gerais', cadastro," +
                "desligamento, indicacao as 'Indicação', nomePosto as 'Nome Posto', aluguel, fotoContemplado as 'Foto Contemplado', estadoCivil as 'Estado Civil', nomeConvenio as 'Nome do Convênio', moraCom as 'Mora Com'," +
                "tipoResidencia as 'Tipo de Residência', fotoContemplado FROM contemplado " +
                "INNER JOIN estadocivil on contemplado.estadoCivil_id = estadocivil.estadoCivil_id " +
                "INNER JOIN convenio on contemplado.postoConvenio_id = convenio.postoConvenio_id " +
                "INNER JOIN moracom on contemplado.moraCom_id = moracom.moraCom_id " +
                "INNER JOIN residencia on contemplado.residencia_id = residencia.residencia_id; ";

                comando = new MySqlCommand(sql_select_contemplado, conector);
                dataAdapter = new MySqlDataAdapter(comando);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridContemplados.DataSource = dataTable;

                if (!dataGridContemplados.Columns.Contains("fotoContempladoColuna"))
                {
                    DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                    imageColumn.HeaderText = "Foto"; // Nome do cabeçalho
                    imageColumn.Name = "fotoContempladoColuna"; // Nome da coluna
                    imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Ajusta o layout da imagem
                    dataGridContemplados.Columns.Add(imageColumn);
                }   

                foreach (DataGridViewRow row in dataGridContemplados.Rows)
                {
                    if (row.Cells["fotoContemplado"].Value != null) 
                    {
                        string linkDaFoto = row.Cells["fotoContemplado"].Value.ToString();
                        if (System.IO.File.Exists(linkDaFoto))
                        { 
                            try
                            {
                                Bitmap img = new Bitmap(linkDaFoto); 
                                row.Cells["fotoContempladoColuna"].Value = img; 
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao carregar a imagem: {ex.Message}");

                            }
                        }
                        else
                        {
                            row.Cells["fotoContempladoColuna"].Value = null; 
                        }
                    }
                }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buscarDados()
        {
            conector = new MySqlConnection(data_source);
            try
            {
                conector.Open();
                string sql_select_contemplado = @"
                SELECT c.nomeContemplado AS 'Nome do Contemplado(a)', c.dataNascimento AS 'Data de Nascimento', 
                c.RG,c.CPF,c.escolaridade,c.endereco AS 'Endereço', c.naturalidade, c.telefone, 
                c.bairro, c.ajudaGoverno AS 'Possui Ajuda do Governo?', c.gastoComMedicamento AS 'Gastos com Medicamento?', 
                c.dívida, c.rendaFamiliar AS 'Renda Familiar', c.necessidadeDeLeite AS 'Possui Necessidade de Leite?', 
                c.necessidadeDeFralda AS 'Possui Necessidade de Fralda?', c.problemaComCigarroOuDrogas AS 'Problema com Cigarro ou Drogas?', 
                c.problemaComBebida AS 'Problema com Bebida?', c.deficiencia, c.responsavelFamilia AS 'Responsável pela Família', 
                c.tamanhoFamilia AS 'Tamanho da Família', c.anotacoesGerais AS 'Anotações Gerais', c.cadastro, c.desligamento, 
                c.indicacao AS 'Indicação', c.nomePosto AS 'Nome Posto', c.aluguel, c.fotoContemplado AS 'Foto Contemplado', 
                estadocivil.estadoCivil AS 'Estado Civil', convenio.nomeConvenio AS 'Nome do Convênio', 
                moracom.moraCom AS 'Mora Com', residencia.tipoResidencia AS 'Tipo de Residência', 
                GROUP_CONCAT(CONCAT(m.nomeFamiliar, ' (', m.parentesco, ', ', m.situacaoAtual, ', ', m.dataNascimento, ')') SEPARATOR '|| ') AS 'Familiares'
                FROM contemplado c
                INNER JOIN estadocivil ON c.estadoCivil_id = estadocivil.estadoCivil_id
                INNER JOIN convenio ON c.postoConvenio_id = convenio.postoConvenio_id
                INNER JOIN moracom ON c.moraCom_id = moracom.moraCom_id
                INNER JOIN residencia ON c.residencia_id = residencia.residencia_id
                LEFT JOIN ComposicaoFamiliar cf ON c.contemplado_id = cf.contemplado_id
                LEFT JOIN morador m ON cf.morador_id = m.morador_id
                GROUP BY c.contemplado_id;";

                comando = new MySqlCommand(sql_select_contemplado, conector);
                dataAdapter = new MySqlDataAdapter(comando);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridContemplados.DataSource = dataTable;
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxBuscarCont_TextChanged(object sender, EventArgs e)
        {
            string expressaoFiltro = $"'Nome do Contemplado(a)' LIKE '%{textBoxBuscarCont.Text}%'";
            (dataGridContemplados.DataSource as DataTable).DefaultView.RowFilter = expressaoFiltro;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            BuscarCestasBasicas cestas = new BuscarCestasBasicas();
            this.Hide();
            cestas.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            CadastrarContemplados contemplado = new CadastrarContemplados();
            this.Hide();
            contemplado.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            BuscarContemplados contemplado = new BuscarContemplados();
            this.Hide();
            contemplado.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            BuscaECadastroCestas cestaCadastro = new BuscaECadastroCestas();
            this.Hide();
            cestaCadastro.ShowDialog();
            this.Close();
        }

        private void ImagemPerfil_Click(object sender, EventArgs e)
        {
            PerfilUsuario perfil = new PerfilUsuario();
            this.Hide();
            perfil.ShowDialog();
            this.Close();
        }

        private void ImagemPerfil_Click_1(object sender, EventArgs e)
        {
            PerfilUsuario perfil = new PerfilUsuario();
            this.Hide();
            perfil.ShowDialog();
            this.Close();
        }

        private void label1Cont_Click(object sender, EventArgs e)
        {
            CadastrarContemplados cadastro = new CadastrarContemplados();
            this.Hide();
            cadastro.ShowDialog();
            this.Close();
        }

        private void label2Cont_Click(object sender, EventArgs e)
        {

        }

        private void label6Cont_Click(object sender, EventArgs e)
        {

        }

        private void label3Cont_Click(object sender, EventArgs e)
        {
            BuscaECadastroCestas cesta = new BuscaECadastroCestas();
            this.Hide();
            cesta.ShowDialog();
            this.Close();
        }

        private void label4Cont_Click(object sender, EventArgs e)
        {
            BuscarCestasBasicas cesta = new BuscarCestasBasicas();
            this.Hide();
            cesta.ShowDialog();
            this.Close();
        }

        private void BuscarContemplados_Load(object sender, EventArgs e)
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

        private void label1Fam_Click(object sender, EventArgs e)
        {
            CadastrarContemplados comt2 = new CadastrarContemplados();
            this.Hide();
            comt2.ShowDialog();
            this.Close();
        }

        private void label2Fam_Click(object sender, EventArgs e)
        {

        }

        private void label6Fam_Click(object sender, EventArgs e)
        {
            Familiares fam = new Familiares();
            this.Hide();
            fam.ShowDialog();
            this.Close();
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

        private void ImagemPerfil_Click_2(object sender, EventArgs e)
        {

        }

       
        private void FiltrarTamanho(decimal valorMinimo)
        {
            DataView dv = new DataView(dataTable);
            dv.RowFilter = $"[Tamanho da Família] = {valorMinimo}";
            dataGridContemplados.DataSource = dv;
        }

        private void btnAplicarFiltro_Click(object sender, EventArgs e)
        {
            decimal valorMinimo = numericUpDownTamanho.Value;
            FiltrarTamanho(valorMinimo);
        }


        private void comboBoxLeite_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = comboBoxLeite.SelectedItem.ToString();
            (dataGridContemplados.DataSource as DataTable).DefaultView.RowFilter = "";

            if (filtro == "Sim")
            {
                (dataGridContemplados.DataSource as DataTable).DefaultView.RowFilter = "[Possui Necessidade de Leite?] = true";
            }
            else if (filtro == "Não")
            {
                (dataGridContemplados.DataSource as DataTable).DefaultView.RowFilter = "[Possui Necessidade de Leite?] = false";
            }
        }

        private void comboBoxFralda_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = comboBoxFralda.SelectedItem.ToString();
            (dataGridContemplados.DataSource as DataTable).DefaultView.RowFilter = "";

            if (filtro == "Sim")
            {
                (dataGridContemplados.DataSource as DataTable).DefaultView.RowFilter = "[Possui Necessidade de Fralda?] = true";
            }
            else if (filtro == "Não")
            {
                (dataGridContemplados.DataSource as DataTable).DefaultView.RowFilter = "[Possui Necessidade de Fralda?] = false";
            }
        }




    }
}
