Public Class frmSelectReport

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click

        '        List of Orders
        'Stocks In
        '        Sales()
        If ComboBox1.Text = "List of Orders" Then
            frmOrderListReport.ShowDialog()
        ElseIf ComboBox1.Text = "Stocks In" Then
            frmStocksIn.ShowDialog()
        ElseIf ComboBox1.Text = "Sales" Then
            frmProductSales.ShowDialog()
        ElseIf ComboBox1.Text = "Expenses" Then
            frmExpensesReport.ShowDialog()
        End If

    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox1.KeyPress
        e.Handled = True
    End Sub

    
End Class