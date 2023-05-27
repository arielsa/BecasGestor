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
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.dataGridBecas = new System.Windows.Forms.DataGridView();
            this.btnEliminarBeca = new System.Windows.Forms.Button();
            this.btnCrearBeca = new System.Windows.Forms.Button();
            this.dataGridBecasDeAlumno = new System.Windows.Forms.DataGridView();
            this.dataGridViewCuotas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCargarCuota = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlumno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBecas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBecasDeAlumno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCuotas)).BeginInit();
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
            this.dataGridAlumno.Size = new System.Drawing.Size(681, 215);
            this.dataGridAlumno.TabIndex = 0;
            this.dataGridAlumno.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAlumno_CellContentClick);
            this.dataGridAlumno.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridAlumno_RowEnter);
            // 
            // btnAddAlumno
            // 
            this.btnAddAlumno.Location = new System.Drawing.Point(324, 233);
            this.btnAddAlumno.Name = "btnAddAlumno";
            this.btnAddAlumno.Size = new System.Drawing.Size(116, 37);
            this.btnAddAlumno.TabIndex = 1;
            this.btnAddAlumno.Text = "Agregar";
            this.btnAddAlumno.UseVisualStyleBackColor = true;
            this.btnAddAlumno.Click += new System.EventHandler(this.btnAddAlumno_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(577, 233);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(116, 37);
            this.btnBorrar.TabIndex = 2;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(446, 233);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(116, 37);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // dataGridBecas
            // 
            this.dataGridBecas.AllowUserToAddRows = false;
            this.dataGridBecas.AllowUserToDeleteRows = false;
            this.dataGridBecas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBecas.Location = new System.Drawing.Point(917, 12);
            this.dataGridBecas.Name = "dataGridBecas";
            this.dataGridBecas.ReadOnly = true;
            this.dataGridBecas.RowHeadersWidth = 62;
            this.dataGridBecas.RowTemplate.Height = 28;
            this.dataGridBecas.Size = new System.Drawing.Size(550, 215);
            this.dataGridBecas.TabIndex = 5;
            this.dataGridBecas.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBecas_RowEnter);
            // 
            // btnEliminarBeca
            // 
            this.btnEliminarBeca.Location = new System.Drawing.Point(1054, 233);
            this.btnEliminarBeca.Name = "btnEliminarBeca";
            this.btnEliminarBeca.Size = new System.Drawing.Size(116, 37);
            this.btnEliminarBeca.TabIndex = 7;
            this.btnEliminarBeca.Text = "Eliminar Beca";
            this.btnEliminarBeca.UseVisualStyleBackColor = true;
            this.btnEliminarBeca.Click += new System.EventHandler(this.btnEliminarBeca_Click);
            // 
            // btnCrearBeca
            // 
            this.btnCrearBeca.Location = new System.Drawing.Point(917, 233);
            this.btnCrearBeca.Name = "btnCrearBeca";
            this.btnCrearBeca.Size = new System.Drawing.Size(116, 37);
            this.btnCrearBeca.TabIndex = 8;
            this.btnCrearBeca.Text = "Crear beca";
            this.btnCrearBeca.UseVisualStyleBackColor = true;
            this.btnCrearBeca.Click += new System.EventHandler(this.btnCrearBeca_Click);
            // 
            // dataGridBecasDeAlumno
            // 
            this.dataGridBecasDeAlumno.AllowUserToAddRows = false;
            this.dataGridBecasDeAlumno.AllowUserToDeleteRows = false;
            this.dataGridBecasDeAlumno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBecasDeAlumno.Location = new System.Drawing.Point(12, 324);
            this.dataGridBecasDeAlumno.Name = "dataGridBecasDeAlumno";
            this.dataGridBecasDeAlumno.ReadOnly = true;
            this.dataGridBecasDeAlumno.RowHeadersWidth = 62;
            this.dataGridBecasDeAlumno.RowTemplate.Height = 28;
            this.dataGridBecasDeAlumno.Size = new System.Drawing.Size(550, 215);
            this.dataGridBecasDeAlumno.TabIndex = 9;
            // 
            // dataGridViewCuotas
            // 
            this.dataGridViewCuotas.AllowUserToAddRows = false;
            this.dataGridViewCuotas.AllowUserToDeleteRows = false;
            this.dataGridViewCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCuotas.Location = new System.Drawing.Point(639, 324);
            this.dataGridViewCuotas.Name = "dataGridViewCuotas";
            this.dataGridViewCuotas.ReadOnly = true;
            this.dataGridViewCuotas.RowHeadersWidth = 62;
            this.dataGridViewCuotas.RowTemplate.Height = 28;
            this.dataGridViewCuotas.Size = new System.Drawing.Size(818, 215);
            this.dataGridViewCuotas.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 542);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Becas del almuno seleccionado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Alumno seleccionado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1337, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Listado de becas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1319, 542);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Cuotas de alumno";
            // 
            // btnCargarCuota
            // 
            this.btnCargarCuota.Location = new System.Drawing.Point(639, 545);
            this.btnCargarCuota.Name = "btnCargarCuota";
            this.btnCargarCuota.Size = new System.Drawing.Size(116, 37);
            this.btnCargarCuota.TabIndex = 15;
            this.btnCargarCuota.Text = "Cargar Cuota";
            this.btnCargarCuota.UseVisualStyleBackColor = true;
            this.btnCargarCuota.Click += new System.EventHandler(this.btnCargarCuota_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1546, 627);
            this.Controls.Add(this.btnCargarCuota);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewCuotas);
            this.Controls.Add(this.dataGridBecasDeAlumno);
            this.Controls.Add(this.btnCrearBeca);
            this.Controls.Add(this.btnEliminarBeca);
            this.Controls.Add(this.dataGridBecas);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnAddAlumno);
            this.Controls.Add(this.dataGridAlumno);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAlumno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBecas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBecasDeAlumno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCuotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridAlumno;
        private System.Windows.Forms.Button btnAddAlumno;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DataGridView dataGridBecas;
        private System.Windows.Forms.Button btnEliminarBeca;
        private System.Windows.Forms.Button btnCrearBeca;
        private System.Windows.Forms.DataGridView dataGridBecasDeAlumno;
        private System.Windows.Forms.DataGridView dataGridViewCuotas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCargarCuota;
    }
}

