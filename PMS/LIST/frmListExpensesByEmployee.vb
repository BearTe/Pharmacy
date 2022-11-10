Public Class frmListExpensesByEmployee

    Private Sub frmListExpensesByEmployee_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetListEmployee()
    End Sub

    Private Sub cmbEmployee_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbEmployee.SelectedIndexChanged
        GetExpensesByEmployee(cmbEmployee.Text)
    End Sub
End Class