using ChamadosImpressora.Context;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ChamadosImpressora
{
    public partial class formRegistrarChamado : Form
    {
        private int idSeccional;
        private int idDepartamento;

        public formRegistrarChamado()
        {
            InitializeComponent();
        }

        private void formRegistrarChamado_Load(object sender, EventArgs e)
        {
            cbSeccional.SelectedIndexChanged -= new EventHandler(cbSeccional_SelectedIndexChanged);
            //Preencher cbSeccional
            cbSeccional.DataSource = PreencheCbSeccional();
            cbSeccional.ValueMember = "ID_Seccional";
            cbSeccional.DisplayMember = "Nome";
            cbSeccional.SelectedIndex = 0;

            //Preencher cbCategoria
            cbCategoriaChamado.DataSource = PreencheCbCategoria();
            cbCategoriaChamado.ValueMember = "ID_Categoria";
            cbCategoriaChamado.DisplayMember = "Descricao";
            cbCategoriaChamado.SelectedIndex = 0;
            cbSeccional.SelectedIndexChanged += new EventHandler(cbSeccional_SelectedIndexChanged);
        }

        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            using (dbChamadosImpressoraEntities dbChamado = new dbChamadosImpressoraEntities())
            {

                int numeroChamado;
                var result = int.TryParse(txtNumeroChamado.Text, out numeroChamado);
                if (result)
                {
                    var idSeccional = Convert.ToInt32(cbSeccional.SelectedValue);
                    var idDepartamento = Convert.ToInt32(cbDepartamento.SelectedValue);
                    var idImpressora = Convert.ToInt32(cbImpressora.SelectedValue);
                    var idCategoria = Convert.ToInt32(cbCategoriaChamado.SelectedValue);
                    var descricao = txtDescricaoChamado.Text;
                    if (!Equals(numeroChamado, 0) &&
                        !Equals(idSeccional, 0) &&
                        !Equals(idDepartamento, 0) &&
                        !Equals(idImpressora, 0) &&
                        !Equals(idCategoria, 0) &&
                        !string.IsNullOrEmpty(descricao))
                    {
                        dbChamado.spRegistraChamado(numeroChamado, idSeccional, idDepartamento, idImpressora, idCategoria, descricao);
                    }
                    else
                    {
                        MessageBox.Show("Todos os campos são de preenchimento obrigatório!", "Atenção");
                    }
                }
                else
                {
                    MessageBox.Show("O campo Nº de chamado aceita somente números", "Atenção");
                }
                dbChamado.SaveChanges();
            }
            Dispose();
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbSeccional_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDepartamento.SelectedIndexChanged -= new EventHandler(cbDepartamento_SelectedIndexChanged);

            cbDepartamento.DataSource = PreencheCbDepartamento();
            cbDepartamento.ValueMember = "ID_Departamento";
            cbDepartamento.DisplayMember = "Departamento";
            cbDepartamento.SelectedIndex = 0;
            if (cbImpressora.DataSource != null)
            {
                cbImpressora.DataSource = null;
            }
            cbDepartamento.SelectedIndexChanged += new EventHandler(cbDepartamento_SelectedIndexChanged);
        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

            cbImpressora.DataSource = PreencheCbImpressoras();
            cbImpressora.ValueMember = "ID_Impressora";
            cbImpressora.DisplayMember = "Modelo";
            cbImpressora.SelectedIndex = 0;
        }

        /// <summary>
        /// Retorna um DataTable que preenche o ComboBox cbSeccional da interface do usuário
        /// </summary>
        /// <returns></returns>
        private DataTable PreencheCbSeccional()
        {
            DataTable dt = new DataTable();
            using (dbChamadosImpressoraEntities dbChamado = new dbChamadosImpressoraEntities())
            {
                dt.Columns.Add("ID_Seccional");
                dt.Columns.Add("Nome");
                dt.Rows.Add(0, "Selecione");
                var listaSeccionais = dbChamado.spBuscaSeccionais().ToList();
                foreach (var seccional in listaSeccionais)
                {
                    dt.Rows.Add(seccional.ID_Seccional, seccional.Nome);
                }
            }
            return dt;
        }

        /// <summary>
        /// Retorna um DataTable que preenche o ComboBox cbDepartamento da interface do usuário
        /// </summary>
        /// <returns></returns>
        private DataTable PreencheCbDepartamento()
        {
            DataTable dt = new DataTable();
            using (dbChamadosImpressoraEntities dbChamado = new dbChamadosImpressoraEntities())
            {
                idSeccional = Convert.ToInt32(cbSeccional.SelectedValue);
                dt.Columns.Add("ID_Departamento");
                dt.Columns.Add("Departamento");
                dt.Rows.Add(0, "Selecione");
                var listaDepartamentos = dbChamado.spBuscaDepartamentosPorSeccional(idSeccional).ToList();
                foreach (var departamento in listaDepartamentos)
                {
                    dt.Rows.Add(departamento.ID_Departamento, departamento.Departamento);
                }
            }
            return dt;
        }

        /// <summary>
        /// Retorna um DataTable que preenche o ComboBox cbImpressoras da interface do usuário
        /// </summary>
        /// <returns></returns>
        private DataTable PreencheCbImpressoras()
        {
            idSeccional = Convert.ToInt32(cbSeccional.SelectedValue);
            idDepartamento = Convert.ToInt32(cbDepartamento.SelectedValue);
            DataTable dt = new DataTable();
            using (dbChamadosImpressoraEntities dbChamado = new dbChamadosImpressoraEntities())
            {
                dt.Columns.Add("ID_Impressora");
                dt.Columns.Add("Modelo");
                dt.Rows.Add(0, "Selecione");
                var listaImpressoras = dbChamado.spBuscaImpressorasPorDepartamento(idSeccional, idDepartamento).ToList();
                foreach (var impressora in listaImpressoras)
                {
                    dt.Rows.Add(impressora.ID_Impressora, impressora.Impressora);
                }
            }
            return dt;
        }

        /// <summary>
        /// Retorna um DataTable que preenche o ComboBox cbCategoria da interface do usuário
        /// </summary>
        /// <returns></returns>
        private DataTable PreencheCbCategoria()
        {
            DataTable dt = new DataTable();
            using (dbChamadosImpressoraEntities dbChamado = new dbChamadosImpressoraEntities())
            {
                dt.Columns.Add("ID_Categoria");
                dt.Columns.Add("Descricao");
                dt.Rows.Add(0, "Selecione");
                var listaCategorias = dbChamado.spBuscaCategoriaChamado().ToList();
                foreach (var categoria in listaCategorias)
                {
                    dt.Rows.Add(categoria.ID_Categoria, categoria.Descricao);
                }
            }
            return dt;
        }
    }
}