<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpensesReport
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
        Me.ExpensesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ExpensesTableAdapter = New PMS.PharmacyDBDataSetTableAdapters.ExpensesTableAdapter()
        CType(Me.PharmacyDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExpensesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsExpenses"
        ReportDataSource1.Value = Me.ExpensesBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "PMS.rptExpenses.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(568, 366)
        Me.ReportViewer1.TabIndex = 0
        '
        'PharmacyDBDataSet
        '
        Me.PharmacyDBDataSet.DataSetName = "PharmacyDBDataSet"
        Me.PharmacyDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ExpensesBindingSource
        '
        Me.ExpensesBindingSource.DataMember = "Expenses"
        Me.ExpensesBindingSource.DataSource = Me.PharmacyDBDataSet
        '
        'ExpensesTableAdapter
        '
        Me.ExpensesTableAdapter.ClearBeforeFill = True
        '
        'frmExpensesReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 366)
        Me.Controls.Add(Me.ReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmExpensesReport"
        Me.Text = "Expenses Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PharmacyDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExpensesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ExpensesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PharmacyDBDataSet As PMS.PharmacyDBDataSet
    Friend WithEvents ExpensesTableAdapter As PMS.PharmacyDBDataSetTableAdapters.ExpensesTableAdapter
End Class
