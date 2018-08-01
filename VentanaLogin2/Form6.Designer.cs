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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tabla_facturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbPOSDataSet1 = new VentanaLogin2.dbPOSDataSet1();
            this.tabla_totalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbPOSDataSet2 = new VentanaLogin2.dbPOSDataSet2();
            this.tabla_facturaTableAdapter = new VentanaLogin2.dbPOSDataSet1TableAdapters.tabla_facturaTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabla_totalesTableAdapter = new VentanaLogin2.dbPOSDataSet2TableAdapters.tabla_totalesTableAdapter();
            this.tablafacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_facturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPOSDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_totalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPOSDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablafacturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabla_facturaBindingSource
            // 
            this.tabla_facturaBindingSource.DataMember = "tabla_factura";
            this.tabla_facturaBindingSource.DataSource = this.dbPOSDataSet1;
            // 
            // dbPOSDataSet1
            // 
            this.dbPOSDataSet1.DataSetName = "dbPOSDataSet1";
            this.dbPOSDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabla_totalesBindingSource
            // 
            this.tabla_totalesBindingSource.DataMember = "tabla_totales";
            this.tabla_totalesBindingSource.DataSource = this.dbPOSDataSet2;
            // 
            // dbPOSDataSet2
            // 
            this.dbPOSDataSet2.DataSetName = "dbPOSDataSet2";
            this.dbPOSDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabla_facturaTableAdapter
            // 
            this.tabla_facturaTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.tabla_facturaBindingSource;
            reportDataSource5.Name = "DataSet2";
            reportDataSource5.Value = this.tabla_totalesBindingSource;
            reportDataSource6.Name = "DataSet3";
            reportDataSource6.Value = this.tabla_facturaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "VentanaLogin2.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(432, 361);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomPercent = 75;
            // 
            // tabla_totalesTableAdapter
            // 
            this.tabla_totalesTableAdapter.ClearBeforeFill = true;
            // 
            // tablafacturaBindingSource
            // 
            this.tablafacturaBindingSource.DataMember = "tabla_factura";
            this.tablafacturaBindingSource.DataSource = this.dbPOSDataSet1;
            // 
            // Vreporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 361);
            this.Controls.Add(this.reportViewer1);
            this.MaximumSize = new System.Drawing.Size(644, 500);
            this.Name = "Vreporte";
            this.Text = "Form6";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Vreporte_FormClosed);
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabla_facturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPOSDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_totalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbPOSDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablafacturaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource tabla_facturaBindingSource;
        private dbPOSDataSet1 dbPOSDataSet1;
        private dbPOSDataSet1TableAdapters.tabla_facturaTableAdapter tabla_facturaTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dbPOSDataSet2 dbPOSDataSet2;
        private dbPOSDataSet2TableAdapters.tabla_totalesTableAdapter tabla_totalesTableAdapter;
        private System.Windows.Forms.BindingSource tabla_totalesBindingSource;
        private System.Windows.Forms.BindingSource tablafacturaBindingSource;
    }
}