<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductSales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.PharmacyDBDataSet = New PMS.PharmacyDBDataSet()
        Me.ProductSalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProductSalesTableAdapter = New PMS.PharmacyDBDataSetTableAdapters.ProductSalesTableAdapter()
        CType(Me.PharmacyDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductSalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsSales"
        ReportDataSource1.Value = Me.ProductSalesBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "PMS.rptProductSales.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(474, 354)
        Me.ReportViewer1.TabIndex = 0
        '
        'PharmacyDBDataSet
        '
        Me.PharmacyDBDataSet.DataSetName = "PharmacyDBDataSet"
        Me.PharmacyDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ProductSalesBindingSource
        '
        Me.ProductSalesBindingSource.DataMember = "ProductSales"
        Me.ProductSalesBindingSource.DataSource = Me.PharmacyDBDataSet
        '
        'ProductSalesTableAdapter
        '
        Me.ProductSalesTableAdapter.ClearBeforeFill = True
        '
        'frmProductSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 354)
        Me.Controls.Add(Me.ReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmProductSales"
        Me.Text = "Sales Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PharmacyDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductSalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ProductSalesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PharmacyDBDataSet As PMS.PharmacyDBDataSet
    Friend WithEvents ProductSalesTableAdapter As PMS.PharmacyDBDataSetTableAdapters.ProductSalesTableAdapter
End Class
