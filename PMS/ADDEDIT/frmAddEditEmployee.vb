Public Class frmAddEditEmployee

    Private Sub frmAddEditEmployee_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If isAddingData = True Then
            lblTitle.Text = "Adding Employee"
            txtLastname.Tag = ""
            txtFirstName.Text = ""
            txtMiddleName.Text = ""
            cmbGender.SelectedIndex = -1
            txtAge.Text = ""
            txtMobileNo.Text = ""
            txtEmailAddress.Text = ""
            txtSalary.Text = ""
            txtHireDate.Text = ""
            txtContactPerson.Text = ""
            txtLastname.Text = ""
        Else
            lblTitle.Text = "Updating Employee"
            GetEmployeeInfo(frmListEmployee.ListView1.FocusedItem.Text)
            txtLastname.Focus()
        End If
    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        If isAddingData = True Then
            AddEditEmployee(True)
        Else
            AddEditEmployee(False)
        End If

        LoadEmployeeList(frmListEmployee.strEmpLastname)
        Me.Close()
    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        isAddingData = False
        Me.Close()
    End Sub
End Class