Public Class frmAddEditExpenses

    Public isAddExpenses As Boolean

    Private Sub frmAddEditExpenses_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If isAddingData = True Then
            lblTitle.Text = "Adding Expenses"
            txtEmployee.Tag = ""
            txtEmployee.Text = ""
            txtDescription.Text = ""
            txtAmount.Text = ""
            dtpExpensesDate.Value = Date.Now
        Else
            lblTitle.Text = "Updating Expenses"
            GetExpensesInfo(frmListExpenses.ListView1.FocusedItem.Text)

        End If
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If isAddingData = True Then
            AddEditExpenses(True)
        Else
            AddEditExpenses(False)
        End If
        LoadExpensesList(frmListExpenses.strEmpLastname)
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        isAddExpenses = True
        frmLoadEmployee.ShowDialog()
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub
End Class