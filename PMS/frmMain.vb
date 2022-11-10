Public Class frmMain


    Private Sub CloseChildForms()
        For Each frm As Form In Me.MdiChildren
            If frm.Name = "frmHome" Then
            Else
                frm.Close()
            End If
        Next
    End Sub

    Private Sub DatabaseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DatabaseToolStripMenuItem.Click
        frmDatabase.ShowDialog()
    End Sub

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        getData()
        frmHome.MdiParent = Me
        frmHome.Show()
        frmLogin.ShowDialog()
        LoadExpiredProduct()
    End Sub

    Private Sub CompanyToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CompanyToolStripMenuItem.Click
        CloseChildForms()
        frmListCompany.MdiParent = Me
        frmListCompany.Show()
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        CloseChildForms()
        frmListCompany.MdiParent = Me
        frmListCompany.Show()
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles btnEmployee.Click
        CloseChildForms()
        frmListEmployee.MdiParent = Me
        frmListEmployee.Show()
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        CloseChildForms()
        frmListProduct.MdiParent = Me
        frmListProduct.Show()
    End Sub

    Private Sub ToolStripButton6_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton6.Click
        CloseChildForms()
        frmListOrder.MdiParent = Me
        frmListOrder.Show()
    End Sub

    Private Sub ToolStripButton5_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton5.Click
        ' frmPOS.Show()
    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        CloseChildForms()
        frmListTransactions.MdiParent = Me
        frmListTransactions.Show()
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        CloseChildForms()
        frmListExpenses.MdiParent = Me
        frmListExpenses.Show()
    End Sub

    Private Sub ReportsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReportsToolStripMenuItem.Click
        frmSelectReport.ShowDialog()
    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EmployeeToolStripMenuItem.Click
        CloseChildForms()
        frmListEmployee.MdiParent = Me
        frmListEmployee.Show()
    End Sub

    Private Sub ProductToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProductToolStripMenuItem.Click
        CloseChildForms()
        frmListProduct.MdiParent = Me
        frmListProduct.Show()
    End Sub

    Private Sub ExpiredProductsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExpiredProductsToolStripMenuItem.Click
        frmListExpiredStocks.ShowDialog()
    End Sub

    Private Sub UsersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles btnUsers.Click
        frmUser.ShowDialog()
    End Sub

    Public Sub UserFunction(ByVal role As String)

        If role.ToUpper = "ADMIN" Then
            btnEmployee.Visible = True
            btnUsers.Visible = True
        Else
            btnEmployee.Visible = False
            btnUsers.Visible = False
        End If

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        frmLogin.txtUsername.Text = ""
        frmLogin.txtPassword.Text = ""
        frmLogin.ShowDialog()
    End Sub

    Private Sub OrderPaymentToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles OrderPaymentToolStripMenuItem.Click
        CloseChildForms()
        frmListOrderPayment.MdiParent = Me
        frmListOrderPayment.Show()
    End Sub

    Private Sub ListOfExpensesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListOfExpensesToolStripMenuItem.Click
        CloseChildForms()
        frmListExpenses.MdiParent = Me
        frmListExpenses.Show()
    End Sub

    Private Sub ExpensesByEmployeeToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExpensesByEmployeeToolStripMenuItem.Click
        CloseChildForms()
        frmListExpensesByEmployee.MdiParent = Me
        frmListExpensesByEmployee.Show()
    End Sub

    Private Sub DatabaseBackupRestoreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DatabaseBackupRestoreToolStripMenuItem.Click
        frmSQLServerBackupRestore.ShowDialog()
    End Sub

End Class
