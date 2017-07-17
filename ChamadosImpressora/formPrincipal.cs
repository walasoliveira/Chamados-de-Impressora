using ChamadosImpressora.Context;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ChamadosImpressora
{
    public partial class formPrincipal : Form
    {
        public static int idChamado;
        public static int idSeccional;
        public static string seccional;
        public static int idDepartamento;
        public static string departamento;
        public static int idImpressora;
        public static string impressora;
        public static int idCategoria;
        public static string categoria;
        public static bool idStatus;
        public static string status;
        public static string descricaoChamado;
        public static string observacao;
        public static DateTime dataAberturaChamado;

        public formPrincipal()
        {
            InitializeComponent();
        }

        private void formPrincipal_Load(object sender, EventArgs e)
        {
            dgvChamados.DataSource = CarregaDgvChamados();
            dgvChamados.Columns[0].Visible = true;
            dgvChamados.Columns[1].Visible = false;
            dgvChamados.Columns[2].Visible = true;
            dgvChamados.Columns[3].Visible = false;
            dgvChamados.Columns[4].Visible = true;
            dgvChamados.Columns[5].Visible = false;
            dgvChamados.Columns[6].Visible = true;
            dgvChamados.Columns[7].Visible = false;
            dgvChamados.Columns[8].Visible = true;
            dgvChamados.Columns[9].Visible = false;
            dgvChamados.Columns[10].Visible = true;
            dgvChamados.Columns[11].Visible = true;
            dgvChamados.Columns[12].Visible = true;
            dgvChamados.Columns[13].Visible = true;
            SalvaRowDgvChamadosTemp();
            tscbOpcoes.Items.Insert(0, "Selecione");
            tscbOpcoes.Items.Insert(1, "Nome da seccional");
            tscbOpcoes.Items.Insert(2, "Número do chamado");
            tscbOpcoes.SelectedIndex = 0;
        }

        private void tsbIncluir_Click(object sender, EventArgs e)
        {
            formRegistrarChamado frc = new formRegistrarChamado();
            frc.ShowDialog();
            dgvChamados.DataSource = CarregaDgvChamados();
        }

        private void tsbFinalizar_Click(object sender, EventArgs e)
        {
            dbChamadosImpressoraEntities dbChamado = new dbChamadosImpressoraEntities();
            if (dbChamado.tblRegistroChamados.Any(ch => ch.ID_Chamado == idChamado && ch.ID_Status == true))
            {
                using (formFinalizarChamado ffc = new formFinalizarChamado())
                {
                    ffc.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Este chamado já foi finalizado", "Atenção");
            }
            dgvChamados.DataSource = CarregaDgvChamados();
        }

        private void dgvChamados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SalvaRowDgvChamadosTemp();
        }

        /// <summary>
        /// Retorna um DataTable para preencher DataGridView da interface do usuário
        /// </summary>
        /// <returns></returns>
        private DataTable CarregaDgvChamados()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Chamado");
            dt.Columns.Add("ID_Seccional");
            dt.Columns.Add("Seccional");
            dt.Columns.Add("ID_Departamento");
            dt.Columns.Add("Departamento");
            dt.Columns.Add("ID_Impressora");
            dt.Columns.Add("Impressora");
            dt.Columns.Add("ID_Categoria");
            dt.Columns.Add("Categoria");
            dt.Columns.Add("ID_Status");
            dt.Columns.Add("Status");
            dt.Columns.Add("Descrição do Chamado");
            dt.Columns.Add("Observação");
            dt.Columns.Add("Data de Abertura");
            using (dbChamadosImpressoraEntities dbChamado = new dbChamadosImpressoraEntities())
            {
                var listaChamados = dbChamado.spConsultaChamados().ToList();
                foreach (var chamado in listaChamados)
                {
                    dt.Rows.Add(chamado.ID_Chamado,
                        chamado.ID_Seccional,
                        chamado.Seccional,
                        chamado.ID_Departamento,
                        chamado.Departamento,
                        chamado.ID_Impressora,
                        chamado.Impressora,
                        chamado.ID_Categoria,
                        chamado.Categoria,
                        chamado.ID_Status,
                        chamado.Status,
                        chamado.Descricao,
                        chamado.Observacao,
                        chamado.DataAberturaChamado
                        );
                }
            }
            return dt;
        }

        /// <summary>
        /// Salva linha selecionada do DataGridView na memória 
        /// </summary>
        public void SalvaRowDgvChamadosTemp()
        {
            idChamado = Convert.ToInt32(dgvChamados.CurrentRow.Cells["ID_Chamado"].Value);
            idSeccional = Convert.ToInt32(dgvChamados.CurrentRow.Cells["ID_Seccional"].Value);
            seccional = Convert.ToString(dgvChamados.CurrentRow.Cells["Seccional"].Value);
            idDepartamento = Convert.ToInt32(dgvChamados.CurrentRow.Cells["ID_Departamento"].Value);
            departamento = Convert.ToString(dgvChamados.CurrentRow.Cells["Departamento"].Value);
            idImpressora = Convert.ToInt32(dgvChamados.CurrentRow.Cells["ID_Impressora"].Value);
            impressora = Convert.ToString(dgvChamados.CurrentRow.Cells["Impressora"].Value);
            idCategoria = Convert.ToInt32(dgvChamados.CurrentRow.Cells["ID_Categoria"].Value);
            categoria = Convert.ToString(dgvChamados.CurrentRow.Cells["Categoria"].Value);
            idStatus = Convert.ToBoolean(dgvChamados.CurrentRow.Cells["ID_Status"].Value);
            status = Convert.ToString(dgvChamados.CurrentRow.Cells["Status"].Value);
            descricaoChamado = Convert.ToString(dgvChamados.CurrentRow.Cells["Descrição do Chamado"].Value);
            observacao = Convert.ToString(dgvChamados.CurrentRow.Cells["Observação"].Value);
            dataAberturaChamado = Convert.ToDateTime(dgvChamados.CurrentRow.Cells["Data de Abertura"].Value);
        }

        private void tsbPesquisar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_Chamado");
            dt.Columns.Add("ID_Seccional");
            dt.Columns.Add("Seccional");
            dt.Columns.Add("ID_Departamento");
            dt.Columns.Add("Departamento");
            dt.Columns.Add("ID_Impressora");
            dt.Columns.Add("Impressora");
            dt.Columns.Add("ID_Categoria");
            dt.Columns.Add("Categoria");
            dt.Columns.Add("ID_Status");
            dt.Columns.Add("Status");
            dt.Columns.Add("Descrição do Chamado");
            dt.Columns.Add("Observação");
            dt.Columns.Add("Data de Abertura");
            int val;
            if (tscbOpcoes.SelectedIndex == 1)
            {
                if (!string.IsNullOrWhiteSpace(tstbPesquisar.Text) && !int.TryParse(tstbPesquisar.Text, out val))
                {
                    using (dbChamadosImpressoraEntities dbChamado = new dbChamadosImpressoraEntities())
                    {
                        var nomeSeccional = tstbPesquisar.Text;
                        var listaChamados = dbChamado.spConsultaChamadosPorNomeSeccional(nomeSeccional).ToList();
                        foreach (var chamado in listaChamados)
                        {
                            dt.Rows.Add(chamado.ID_Chamado,
                                chamado.ID_Seccional,
                                chamado.Seccional,
                                chamado.ID_Departamento,
                                chamado.Departamento,
                                chamado.ID_Impressora,
                                chamado.Impressora,
                                chamado.ID_Categoria,
                                chamado.Categoria,
                                chamado.ID_Status,
                                chamado.Status,
                                chamado.Descricao,
                                chamado.Observacao,
                                chamado.DataAberturaChamado
                                );
                        }
                        dgvChamados.DataSource = dt;
                        tscbOpcoes.SelectedIndex = 0;
                        SalvaRowDgvChamadosTemp();
                    }
                }
                else
                {
                    MessageBox.Show("Digite um valor válido.", "Atenção");
                    tscbOpcoes.SelectedIndex = 0;
                }
            }
            else if (tscbOpcoes.SelectedIndex == 2)
            {
                if (int.TryParse(tstbPesquisar.Text, out val))
                {
                    using (dbChamadosImpressoraEntities dbChamado = new dbChamadosImpressoraEntities())
                    {
                        var listaChamados = dbChamado.spConsultaChamadosPorId(val).ToList();
                        foreach (var chamado in listaChamados)
                        {
                            dt.Rows.Add(chamado.ID_Chamado,
                                chamado.ID_Seccional,
                                chamado.Seccional,
                                chamado.ID_Departamento,
                                chamado.Departamento,
                                chamado.ID_Impressora,
                                chamado.Impressora,
                                chamado.ID_Categoria,
                                chamado.Categoria,
                                chamado.ID_Status,
                                chamado.Status,
                                chamado.Descricao,
                                chamado.Observacao,
                                chamado.DataAberturaChamado
                                );
                        }
                    }
                    if (dt.Rows.Count != 0)
                    {
                        dgvChamados.DataSource = dt;
                        tscbOpcoes.SelectedIndex = 0;
                        SalvaRowDgvChamadosTemp();
                    }
                    else
                    {
                        MessageBox.Show("Não foi encontrado nenhum chamado");
                        tscbOpcoes.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Digite um valor válido", "Atenção");
                    tscbOpcoes.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Escolha uma opção para pesquisar", "Atenção");
            }
            tstbPesquisar.Clear();
        }
    }
}






