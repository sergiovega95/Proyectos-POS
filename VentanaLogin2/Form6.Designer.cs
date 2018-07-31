namespace VentanaLogin2
{
    partial class Vreporte
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dbPOSDataSet1 = new VentanaLogin2.dbPOSDataSet1();
            this.tabla_facturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabla_facturaTableAdapter = new VentanaLogin2.dbPOSDataSet1TableAdapters.tabla_facturaTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dbPOSDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_facturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dbPOSDataSet1
            // 
            this.dbPOSDataSet1.DataSetName = "dbPOSDataSet1";
            this.dbPOSDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabla_facturaBindingSource
            // 
            this.tabla_facturaBindingSource.DataMember = "tabla_factura";
            this.tabla_facturaBindingSource.DataSource = this.dbPOSDataSet1;
            // 
            // tabla_facturaTableAdapter
            // 
            this.tabla_facturaTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tabla_facturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VentanaLogin2.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(831, 334);
            this.reportViewer1.TabIndex = 0;
            // 
            // Vreporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 334);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Vreporte";
            this.Text = "Form6";
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbPOSDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_facturaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource tabla_facturaBindingSource;
        private dbPOSDataSet1 dbPOSDataSet1;
        private dbPOSDataSet1TableAdapters.tabla_facturaTableAdapter tabla_facturaTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}