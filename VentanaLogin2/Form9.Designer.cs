namespace VentanaLogin2
{
    partial class Vlista_facturas
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
            this.dataGridView_facturas = new System.Windows.Forms.DataGridView();
            this.idfacturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.impuestoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalpagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablafacturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbPOSDataSet4 = new VentanaLogin2.dbPOSDataSet4();
            this.tabla_facturasTableAdapter = new VentanaLogin2.dbPOSDataSet4TableAdapters.tabla_facturasTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_facturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablafacturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPOSDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_facturas
            // 
            this.dataGridView_facturas.AllowUserToAddRows = false;
            this.dataGridView_facturas.AllowUserToDeleteRows = false;
            this.dataGridView_facturas.AutoGenerateColumns = false;
            this.dataGridView_facturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_facturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfacturaDataGridViewTextBoxColumn,
            this.subtotalDataGridViewTextBoxColumn,
            this.impuestoDataGridViewTextBoxColumn,
            this.descuentoDataGridViewTextBoxColumn,
            this.totalpagoDataGridViewTextBoxColumn});
            this.dataGridView_facturas.DataSource = this.tablafacturasBindingSource;
            this.dataGridView_facturas.Location = new System.Drawing.Point(12, 88);
            this.dataGridView_facturas.Name = "dataGridView_facturas";
            this.dataGridView_facturas.ReadOnly = true;
            this.dataGridView_facturas.Size = new System.Drawing.Size(543, 279);
            this.dataGridView_facturas.TabIndex = 0;
            // 
            // idfacturaDataGridViewTextBoxColumn
            // 
            this.idfacturaDataGridViewTextBoxColumn.DataPropertyName = "id_factura";
            this.idfacturaDataGridViewTextBoxColumn.HeaderText = "id_factura";
            this.idfacturaDataGridViewTextBoxColumn.Name = "idfacturaDataGridViewTextBoxColumn";
            this.idfacturaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // subtotalDataGridViewTextBoxColumn
            // 
            this.subtotalDataGridViewTextBoxColumn.DataPropertyName = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.HeaderText = "Subtotal";
            this.subtotalDataGridViewTextBoxColumn.Name = "subtotalDataGridViewTextBoxColumn";
            this.subtotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // impuestoDataGridViewTextBoxColumn
            // 
            this.impuestoDataGridViewTextBoxColumn.DataPropertyName = "Impuesto";
            this.impuestoDataGridViewTextBoxColumn.HeaderText = "Impuesto";
            this.impuestoDataGridViewTextBoxColumn.Name = "impuestoDataGridViewTextBoxColumn";
            this.impuestoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descuentoDataGridViewTextBoxColumn
            // 
            this.descuentoDataGridViewTextBoxColumn.DataPropertyName = "Descuento";
            this.descuentoDataGridViewTextBoxColumn.HeaderText = "Descuento";
            this.descuentoDataGridViewTextBoxColumn.Name = "descuentoDataGridViewTextBoxColumn";
            this.descuentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalpagoDataGridViewTextBoxColumn
            // 
            this.totalpagoDataGridViewTextBoxColumn.DataPropertyName = "Totalpago";
            this.totalpagoDataGridViewTextBoxColumn.HeaderText = "Totalpago";
            this.totalpagoDataGridViewTextBoxColumn.Name = "totalpagoDataGridViewTextBoxColumn";
            this.totalpagoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tablafacturasBindingSource
            // 
            this.tablafacturasBindingSource.DataMember = "tabla_facturas";
            this.tablafacturasBindingSource.DataSource = this.dbPOSDataSet4;
            // 
            // dbPOSDataSet4
            // 
            this.dbPOSDataSet4.DataSetName = "dbPOSDataSet4";
            this.dbPOSDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabla_facturasTableAdapter
            // 
            this.tabla_facturasTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(73, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(440, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Visualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(200, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "LISTA DE FACTURAS";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(144, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(411, 20);
            this.textBox1.TabIndex = 40;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 41;
            this.label1.Text = "ID FACTURA :";
            // 
            // Vlista_facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 427);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView_facturas);
            this.Name = "Vlista_facturas";
            this.Text = "Form9";
            this.Load += new System.EventHandler(this.Vlista_facturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_facturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablafacturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPOSDataSet4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_facturas;
        private dbPOSDataSet4 dbPOSDataSet4;
        private System.Windows.Forms.BindingSource tablafacturasBindingSource;
        private dbPOSDataSet4TableAdapters.tabla_facturasTableAdapter tabla_facturasTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idfacturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn impuestoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalpagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}