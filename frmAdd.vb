' Programmer: Thessalonica (Tessa) Turnbull
' Date: October 4, 2022
' Title: Assignment 6 - Cash Register Assignment

Imports System.IO

Public Class frmAdd

    Public Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'create new instance of inventory class
        Dim objInventory As New Inventory

        'validates textbox inputs then adds it to the Collection and displays in listbox
        If txtDescription.Text = "" Then
            txtDescription.Clear()
            MsgBox("Please type a description of the item.")
        ElseIf txtCost.Text = "" Then
            txtCost.Clear()
            MsgBox("Please make sure the Cost is in decimal format.")
        ElseIf txtRetail.Text = "" Then
            txtRetail.Clear()
            MsgBox("Please make sure the Retail is in decimal format.")
        ElseIf Not IsNumeric(txtOnHand.Text) Or txtOnHand.Text = "" Then
            txtOnHand.Clear()
            MsgBox("Please make sure the On Hand Quantity is in integer format.")
        Else

            'get data from form
            GetData(objInventory)

            'adds the item
            AddItem(objInventory)

            'message to let user know item was added
            MsgBox("Item has been added.")

            'clears form
            ClearForm()

            'lets boolean know changes were made
            frmCashRegister.changesAdd = True

            'closes frmAdd
            Me.Close()
        End If
    End Sub

    Public Sub GetData(ByRef Inv As Inventory)
        inventoryCount += 1

        'gets the user input from form
        Inv.InvNumber = inventoryCount.ToString()
        Inv.Description = txtDescription.Text
        Inv.Cost = CDec(txtCost.Text)
        Inv.Retail = CDec(txtRetail.Text)
        Inv.OnHand = CInt(txtOnHand.Text)
    End Sub

    Public Sub ClearForm()
        'this sub clears the textboxes used to add items
        txtDescription.Clear()
        txtCost.Clear()
        txtRetail.Clear()
        txtOnHand.Clear()
    End Sub
End Class
