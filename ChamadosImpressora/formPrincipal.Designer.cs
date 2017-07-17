namespace ChamadosImpressora
{
    partial class formPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPrincipal));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbIncluir = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstbPesquisar = new System.Windows.Forms.ToolStripTextBox();
            this.tscbOpcoes = new System.Windows.Forms.ToolStripComboBox();
            this.tsbPesquisar = new System.Windows.Forms.ToolStripButton();
            this.dgvChamados = new System.Windows.Forms.DataGridView();
            this.spConsultaChamadosResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spConsultaChamadosResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(35, 37);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbIncluir,
            this.tsbEditar,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.tscbOpcoes,
            this.tstbPesquisar,
            this.tsbPesquisar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(701, 44);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbIncluir
            // 
            this.tsbIncluir.Image = ((System.Drawing.Image)(resources.GetObject("tsbIncluir.Image")));
            this.tsbIncluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIncluir.Name = "tsbIncluir";
            this.tsbIncluir.Size = new System.Drawing.Size(79, 41);
            this.tsbIncluir.Text = "Incluir";
            this.tsbIncluir.Click += new System.EventHandler(this.tsbIncluir_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(89, 41);
            this.tsbEditar.Text = "Finalizar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbFinalizar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 44);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(0, 41);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(81, 41);
            this.toolStripLabel1.Text = "Pesquisar por:";
            // 
            // tstbPesquisar
            // 
            this.tstbPesquisar.Name = "tstbPesquisar";
            this.tstbPesquisar.Size = new System.Drawing.Size(100, 44);
            // 
            // tscbOpcoes
            // 
            this.tscbOpcoes.AutoSize = false;
            this.tscbOpcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbOpcoes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tscbOpcoes.Name = "tscbOpcoes";
            this.tscbOpcoes.Size = new System.Drawing.Size(121, 23);
            // 
            // tsbPesquisar
            // 
            this.tsbPesquisar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPesquisar.Image = ((System.Drawing.Image)(resources.GetObject("tsbPesquisar.Image")));
            this.tsbPesquisar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPesquisar.Name = "tsbPesquisar";
            this.tsbPesquisar.Size = new System.Drawing.Size(39, 41);
            this.tsbPesquisar.Text = "Pesquisar";
            this.tsbPesquisar.Click += new System.EventHandler(this.tsbPesquisar_Click);
            // 
            // dgvChamados
            // 
            this.dgvChamados.AllowUserToAddRows = false;
            this.dgvChamados.AllowUserToDeleteRows = false;
            this.dgvChamados.AllowUserToResizeRows = false;
            this.dgvChamados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvChamados.Location = new System.Drawing.Point(12, 47);
            this.dgvChamados.Name = "dgvChamados";
            this.dgvChamados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChamados.Size = new System.Drawing.Size(677, 318);
            this.dgvChamados.TabIndex = 1;
            this.dgvChamados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChamados_CellClick);
            // 
            // spConsultaChamadosResultBindingSource
            // 
            this.spConsultaChamadosResultBindingSource.DataSource = typeof(ChamadosImpressora.Context.spConsultaChamados_Result);
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 379);
            this.Controls.Add(this.dgvChamados);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formPrincipal";
            this.Text = "Registro de chamados";
            this.Load += new System.EventHandler(this.formPrincipal_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spConsultaChamadosResultBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbIncluir;
        private System.Windows.Forms.DataGridView dgvChamados;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.BindingSource spConsultaChamadosResultBindingSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripTextBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tstbPesquisar;
        private System.Windows.Forms.ToolStripComboBox tscbOpcoes;
        private System.Windows.Forms.ToolStripButton tsbPesquisar;
    }
}