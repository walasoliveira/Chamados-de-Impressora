using ChamadosImpressora.Context;
using System;
using System.Windows.Forms;

namespace ChamadosImpressora
{
    public partial class formFinalizarChamado : Form
    {
        public formFinalizarChamado()
        {
            InitializeComponent();
        }

        private void formFinalizarChamado_Load(object sender, EventArgs e)
        {
            this.txtSeccional.Text = formPrincipal.seccional;
            this.txtDepartamento.Text = formPrincipal.departamento;
            this.txtImpressora.Text = formPrincipal.impressora;
            this.txtCategoria.Text = formPrincipal.categoria;
            this.txtDescricaoChamado.Text = formPrincipal.descricaoChamado;
            this.txtDataAbertura.Text = formPrincipal.dataAberturaChamado.ToShortDateString();
        }

        private void tsbFinalizar_Click(object sender, EventArgs e)
        {
            var observacao = txtObservacao.Text;
            if (!string.IsNullOrWhiteSpace(observacao))
            {
                var idChamado = formPrincipal.idChamado;
                if (MessageBox.Show(
                    "Deseja finalizar chamado?",
                    "Atenção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    using (dbChamadosImpressoraEntities dbChamados = new dbChamadosImpressoraEntities())
                    {
                        dbChamados.spFinalizaChamado(idChamado, observacao);
                        MessageBox.Show("Chamado finalizado com sucesso!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Obrigatório inserir uma observação", "Atenção");
            }
            Close();
            Dispose();
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
