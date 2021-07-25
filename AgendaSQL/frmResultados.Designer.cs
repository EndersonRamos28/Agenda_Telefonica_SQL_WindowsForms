namespace AgendaSQL
{
    partial class frmResultados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResultados));
            this.btnFechar = new System.Windows.Forms.Button();
            this.GradeResultados = new System.Windows.Forms.DataGridView();
            this.lblResultados = new System.Windows.Forms.Label();
            this.btnApagar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnVerTudo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GradeResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(308, 232);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(66, 26);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // GradeResultados
            // 
            this.GradeResultados.AllowUserToAddRows = false;
            this.GradeResultados.AllowUserToDeleteRows = false;
            this.GradeResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GradeResultados.Location = new System.Drawing.Point(12, 12);
            this.GradeResultados.MultiSelect = false;
            this.GradeResultados.Name = "GradeResultados";
            this.GradeResultados.ReadOnly = true;
            this.GradeResultados.RowHeadersVisible = false;
            this.GradeResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GradeResultados.Size = new System.Drawing.Size(376, 212);
            this.GradeResultados.TabIndex = 1;
            this.GradeResultados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GradeResultados_CellClick);
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Location = new System.Drawing.Point(12, 237);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(35, 13);
            this.lblResultados.TabIndex = 2;
            this.lblResultados.Text = "label1";
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(240, 232);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(62, 26);
            this.btnApagar.TabIndex = 3;
            this.btnApagar.Text = "Apagar";
            this.btnApagar.UseVisualStyleBackColor = true;
            this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(177, 232);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(57, 26);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnVerTudo
            // 
            this.btnVerTudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerTudo.Location = new System.Drawing.Point(107, 232);
            this.btnVerTudo.Name = "btnVerTudo";
            this.btnVerTudo.Size = new System.Drawing.Size(64, 26);
            this.btnVerTudo.TabIndex = 5;
            this.btnVerTudo.Text = "Ver Tudo";
            this.btnVerTudo.UseVisualStyleBackColor = true;
            this.btnVerTudo.Click += new System.EventHandler(this.btnVerTudo_Click);
            // 
            // frmResultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 270);
            this.ControlBox = false;
            this.Controls.Add(this.btnVerTudo);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnApagar);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.GradeResultados);
            this.Controls.Add(this.btnFechar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmResultados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmResultados";
            this.Load += new System.EventHandler(this.frmResultados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GradeResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DataGridView GradeResultados;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.Button btnApagar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnVerTudo;
    }
}