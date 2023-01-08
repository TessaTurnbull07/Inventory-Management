' Programmer: Thessalonica (Tessa) Turnbull
' Date: October 4, 2022
' Title: Assignment 6 - Cash Register Assignment

Imports System.ComponentModel
Imports System.IO

Public Class frmCashRegister

    'object of inventory class
    Dim objInventory As Inventory

    'public variables to check for changes
    Public Shared changesUpdate As Boolean
    Public Shared changesAdd As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'loads Inventory.txt to collection
        readTextfile()
        'updates and displays collection on listbox
        TextFileToListbox()
    End Sub

    Private Sub frmCashRegister_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'check boolean to see if changes have been made
        'if changes have been made, save them to the file then exits
        If changesUpdate = True Or changesAdd = True Then
            SaveToFile()
            MsgBox("Updated contents have been saved to textfile.")
        End If
    End Sub

    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        'updates and displays collection on listbox
        TextFileToListbox()
    End Sub

    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        'creates an instance of the AddForm
        Dim frmAdd As New frmAdd

        'opens the form
        frmAdd.ShowDialog()

        'updates listbox
        TextFileToListbox()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'updates items typed in textboxes to listbox
        UpdateItemToListbox(objInventory)
        'boolean declared true to show updates have been made
        changesUpdate = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveToFile()
    End Sub

    Private Sub lbxInventory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxInventory.SelectedIndexChanged
        ' See if an item is selected.
        If lbxInventory.SelectedIndex <> -1 Then
            ' Retrieve the student's data from the collection.
            Try
                objInventory = CType(inventoryCollection.Item(
               lbxInventory.SelectedItem), Inventory)

                ' Display the student data.
                DisplayData(objInventory)
            Catch ex As Exception
                ' Error message
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Private Sub readTextfile()
        'this sub opens the Inventory.txt file

        'checks if file exists
        If Not File.Exists("Inventory.txt") Then
            Return
        End If

        'file exists so...
        Dim ItemFile As StreamReader = File.OpenText("Inventory.txt")
        Do
            Dim Inv As New Inventory
            With ItemFile
                Inv.InvNumber = .ReadLine()
                Inv.Description = .ReadLine()
                If Not Decimal.TryParse(.ReadLine(), Inv.Cost) Then
                    Exit Do
                End If

                If Not Decimal.TryParse(.ReadLine(), Inv.Retail) Then
                    Exit Do
                End If

                If Not Integer.TryParse(.ReadLine(), Inv.OnHand) Then
                    Exit Do
                End If

                inventoryCount += 1

                inventoryCollection.Add(Inv, Inv.InvNumber)
            End With

        Loop Until (ItemFile.Peek = -1)
        ItemFile.Close()
    End Sub

    Public Sub TextFileToListbox()
        'this sub displays current Inventory.txt file contents to listbox

        'clears the box
        lbxInventory.Items.Clear()

        'loads collection into listbox
        Dim Inv As New Inventory
        For Each Inv In inventoryCollection
            lbxInventory.Items.Add(Inv.InvNumber)
        Next

        'selects first item in the list
        If lbxInventory.Items.Count > 0 Then
            lbxInventory.SelectedIndex = 0
        Else
            ClearForm()
        End If
    End Sub

    Public Sub ClearForm()
        'this sub clears the textboxes used to add items
        frmAdd.txtDescription.Clear()
        frmAdd.txtCost.Clear()
        frmAdd.txtRetail.Clear()
        frmAdd.txtOnHand.Clear()
    End Sub

    Public Sub DisplayData(ByVal Inv As Inventory)
        'this sub displays values into the textboxes
        lblActualInvNumber.Text = Inv.InvNumber
        txtDescription.Text = Inv.Description
        txtCost.Text = CStr(Inv.Cost)
        txtRetail.Text = CStr(Inv.Retail)
        txtOnHand.Text = CStr(Inv.OnHand)
    End Sub

    Public Sub UpdateItemToListbox(ByVal Inv As Inventory)
        'this sub updates user info in textboxes into the listbox/collection
        Inv.InvNumber = lblActualInvNumber.Text
        Inv.Description = txtDescription.Text
        Inv.Cost = CDec(txtCost.Text)
        Inv.Retail = CDec(txtRetail.Text)
        Inv.OnHand = CInt(txtOnHand.Text)
    End Sub

    Public Sub SaveToFile()
        'saves collection to text file
        If inventoryCollection.Count = 0 Then Return
        Dim InventoryFile As StreamWriter = File.CreateText("Inventory.txt")
        For Each Inv As Inventory In inventoryCollection
            With InventoryFile
                .WriteLine(Inv.InvNumber)
                .WriteLine(Inv.Description)
                .WriteLine(Inv.Cost)
                .WriteLine(Inv.Retail)
                .WriteLine(Inv.OnHand)
            End With
        Next

        'closes file
        InventoryFile.Close()
    End Sub

End Class
