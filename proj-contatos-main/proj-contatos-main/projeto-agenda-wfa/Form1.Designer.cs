namespace projeto_agenda_wfa
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNome = new TextBox();
            btnAdcionar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtEmail = new TextBox();
            nupMes = new NumericUpDown();
            nupDia = new NumericUpDown();
            nupAno = new NumericUpDown();
            Dia = new Label();
            label5 = new Label();
            label6 = new Label();
            txtTelefone = new TextBox();
            btnAlterar = new Button();
            btnRemover = new Button();
            btnPesquisar = new Button();
            dgvContatos = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            nome = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            dataNasc = new DataGridViewTextBoxColumn();
            telefonePrincipal = new DataGridViewTextBoxColumn();
            label7 = new Label();
            nupIdAlterar = new NumericUpDown();
            nupIdRemover = new NumericUpDown();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)nupMes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nupDia).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nupAno).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvContatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nupIdAlterar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nupIdRemover).BeginInit();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(255, 37);
            txtNome.MaxLength = 150;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(395, 23);
            txtNome.TabIndex = 0;
            // 
            // btnAdcionar
            // 
            btnAdcionar.Location = new Point(575, 207);
            btnAdcionar.Name = "btnAdcionar";
            btnAdcionar.Size = new Size(75, 23);
            btnAdcionar.TabIndex = 1;
            btnAdcionar.Text = "Salvar";
            btnAdcionar.UseVisualStyleBackColor = true;
            btnAdcionar.Click += btnAdcionar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(206, 40);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 2;
            label1.Text = "Nome:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(206, 81);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 3;
            label2.Text = "Email:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(206, 120);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 4;
            label3.Text = "Data nascimento:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(206, 166);
            label4.Name = "label4";
            label4.Size = new Size(104, 15);
            label4.TabIndex = 5;
            label4.Text = "Telefone principal:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(255, 78);
            txtEmail.MaxLength = 150;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(395, 23);
            txtEmail.TabIndex = 6;
            // 
            // nupMes
            // 
            nupMes.Location = new Point(445, 118);
            nupMes.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nupMes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nupMes.Name = "nupMes";
            nupMes.Size = new Size(34, 23);
            nupMes.TabIndex = 7;
            nupMes.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nupDia
            // 
            nupDia.Location = new Point(347, 118);
            nupDia.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            nupDia.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nupDia.Name = "nupDia";
            nupDia.Size = new Size(34, 23);
            nupDia.TabIndex = 8;
            nupDia.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nupAno
            // 
            nupAno.Location = new Point(542, 118);
            nupAno.Maximum = new decimal(new int[] { 2026, 0, 0, 0 });
            nupAno.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            nupAno.Name = "nupAno";
            nupAno.Size = new Size(77, 23);
            nupAno.TabIndex = 9;
            nupAno.Value = new decimal(new int[] { 2000, 0, 0, 0 });
            // 
            // Dia
            // 
            Dia.AutoSize = true;
            Dia.Location = new Point(317, 120);
            Dia.Name = "Dia";
            Dia.Size = new Size(24, 15);
            Dia.TabIndex = 10;
            Dia.Text = "Dia";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(410, 120);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 11;
            label5.Text = "Mês";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(507, 120);
            label6.Name = "label6";
            label6.Size = new Size(29, 15);
            label6.TabIndex = 12;
            label6.Text = "Ano";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(317, 163);
            txtTelefone.MaxLength = 11;
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(333, 23);
            txtTelefone.TabIndex = 13;
            // 
            // btnAlterar
            // 
            btnAlterar.Location = new Point(461, 207);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(75, 23);
            btnAlterar.TabIndex = 15;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += btnAlterar_Click;
            btnAlterar.MouseMove += btnAlterar_MouseMove;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(329, 207);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(75, 23);
            btnRemover.TabIndex = 16;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(206, 207);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 23);
            btnPesquisar.TabIndex = 17;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // dgvContatos
            // 
            dgvContatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContatos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvContatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContatos.Columns.AddRange(new DataGridViewColumn[] { id, nome, email, dataNasc, telefonePrincipal });
            dgvContatos.Location = new Point(12, 285);
            dgvContatos.Name = "dgvContatos";
            dgvContatos.Size = new Size(804, 253);
            dgvContatos.TabIndex = 18;
            dgvContatos.CellContentClick += dgvContatos_CellContentClick;
            // 
            // id
            // 
            id.FillWeight = 28.2101727F;
            id.HeaderText = "Id";
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // nome
            // 
            nome.FillWeight = 131.882553F;
            nome.HeaderText = "Nome";
            nome.Name = "nome";
            nome.ReadOnly = true;
            // 
            // email
            // 
            email.FillWeight = 131.882553F;
            email.HeaderText = "Email";
            email.Name = "email";
            email.ReadOnly = true;
            // 
            // dataNasc
            // 
            dataNasc.FillWeight = 76.1421356F;
            dataNasc.HeaderText = "Nascimento";
            dataNasc.Name = "dataNasc";
            dataNasc.ReadOnly = true;
            // 
            // telefonePrincipal
            // 
            telefonePrincipal.FillWeight = 131.882553F;
            telefonePrincipal.HeaderText = "Telefone";
            telefonePrincipal.Name = "telefonePrincipal";
            telefonePrincipal.ReadOnly = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(461, 238);
            label7.Name = "label7";
            label7.Size = new Size(20, 15);
            label7.TabIndex = 19;
            label7.Text = "Id:";
            // 
            // nupIdAlterar
            // 
            nupIdAlterar.Location = new Point(501, 236);
            nupIdAlterar.Name = "nupIdAlterar";
            nupIdAlterar.Size = new Size(35, 23);
            nupIdAlterar.TabIndex = 20;
            // 
            // nupIdRemover
            // 
            nupIdRemover.Location = new Point(369, 238);
            nupIdRemover.Name = "nupIdRemover";
            nupIdRemover.Size = new Size(35, 23);
            nupIdRemover.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(329, 240);
            label8.Name = "label8";
            label8.Size = new Size(20, 15);
            label8.TabIndex = 21;
            label8.Text = "Id:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 550);
            Controls.Add(nupIdRemover);
            Controls.Add(label8);
            Controls.Add(nupIdAlterar);
            Controls.Add(label7);
            Controls.Add(dgvContatos);
            Controls.Add(btnPesquisar);
            Controls.Add(btnRemover);
            Controls.Add(btnAlterar);
            Controls.Add(txtTelefone);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(Dia);
            Controls.Add(nupAno);
            Controls.Add(nupDia);
            Controls.Add(nupMes);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAdcionar);
            Controls.Add(txtNome);
            Name = "Form1";
            Text = "Contatos";
            ((System.ComponentModel.ISupportInitialize)nupMes).EndInit();
            ((System.ComponentModel.ISupportInitialize)nupDia).EndInit();
            ((System.ComponentModel.ISupportInitialize)nupAno).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvContatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nupIdAlterar).EndInit();
            ((System.ComponentModel.ISupportInitialize)nupIdRemover).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private Button btnAdcionar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtEmail;
        private NumericUpDown nupMes;
        private NumericUpDown nupDia;
        private NumericUpDown nupAno;
        private Label Dia;
        private Label label5;
        private Label label6;
        private TextBox txtTelefone;
        private Button btnAlterar;
        private Button btnRemover;
        private Button btnPesquisar;
        private DataGridView dgvContatos;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn nome;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn dataNasc;
        private DataGridViewTextBoxColumn telefonePrincipal;
        private Label label7;
        private NumericUpDown nupIdAlterar;
        private NumericUpDown nupIdRemover;
        private Label label8;
    }
}
