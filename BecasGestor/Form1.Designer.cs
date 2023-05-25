namespace BecasGestor
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridAlumno = new System.Windows.Forms.DataGridView();
            this.btnAddAlumno = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlumno)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridAlumno
            // 
            this.dataGridAlumno.AllowUserToAddRows = false;
            this.dataGridAlumno.AllowUserToDeleteRows = false;
            this.dataGridAlumno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAlumno.Location = new System.Drawing.Point(12, 12);
            this.dataGridAlumno.Name = "dataGridAlumno";
            this.dataGridAlumno.ReadOnly = true;
            this.dataGridAlumno.RowHeadersWidth = 62;
            this.dataGridAlumno.RowTemplate.Height = 28;
            this.dataGridAlumno.Size = new System.Drawing.Size(551, 215);
            this.dataGridAlumno.TabIndex = 0;
            // 
            // btnAddAlumno
            // 
            this.btnAddAlumno.Location = new System.Drawing.Point(12, 233);
            this.btnAddAlumno.Name = "btnAddAlumno";
            this.btnAddAlumno.Size = new System.Drawing.Size(116, 37);
            this.btnAddAlumno.TabIndex = 1;
            this.btnAddAlumno.Text = "Agregar";
            this.btnAddAlumno.UseVisualStyleBackColor = true;
            this.btnAddAlumno.Click += new System.EventHandler(this.btnAddAlumno_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 574);
            this.Controls.Add(this.btnAddAlumno);
            this.Controls.Add(this.dataGridAlumno);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlumno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridAlumno;
        private System.Windows.Forms.Button btnAddAlumno;
    }
}

