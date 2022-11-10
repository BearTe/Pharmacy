Public Class frmAddEditCompany

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If isAddingData = True Then
            AddEditCompany(True)
        Else
            AddEditCompany(False)
        End If
        LoadCompanyList(frmListCompany.strCompanyName)
        Me.Close()
    End Sub

    Private Sub frmAddEditCompany_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If isAddingData = True Then
            lblTitle.Text = "Adding Company"
            txtCompanyName.Tag = ""
            txtCompanyName.Text = ""
            txtContactNo.Text = ""
            txtContactPerson.Text = ""
            txtPhoneNo.Text = ""
        Else
            lblTitle.Text = "Updating Company"
            GetCompanyInfo(frmListCompany.ListView1.FocusedItem.Text)
            txtCompanyName.Focus()
        End If
    End Sub
End Class