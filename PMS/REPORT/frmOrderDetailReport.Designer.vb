<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrderDetailReport
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
        Me.OrderDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrderDetailTableAdapter = New PMS.PharmacyDBDataSetTableAdapters.OrderDetailTableAdapter()
        CType(Me.PharmacyDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsOrderDetail"
        ReportDataSource1.Value = Me.OrderDetailBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "PMS.rptOrderDetail.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(626, 332)
        Me.ReportViewer1.TabIndex = 0
        '
        'PharmacyDBDataSet
        '
        Me.PharmacyDBDataSet.DataSetName = "PharmacyDBDataSet"
        Me.PharmacyDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OrderDetailBindingSource
        '
        Me.OrderDetailBindingSource.DataMember = "OrderDetail"
        Me.OrderDetailBindingSource.DataSource = Me.PharmacyDBDataSet
        '
        'OrderDetailTableAdapter
        '
        Me.OrderDetailTableAdapter.ClearBeforeFill = True
        '
        'frmOrderDetailReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 332)
        Me.Controls.Add(Me.ReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmOrderDetailReport"
        Me.Text = "Order Detail Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PharmacyDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents OrderDetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PharmacyDBDataSet As PMS.PharmacyDBDataSet
    Friend WithEvents OrderDetailTableAdapter As PMS.PharmacyDBDataSetTableAdapters.OrderDetailTableAdapter
End Class
