' Programmer: Thessalonica (Tessa) Turnbull
' Date: October 4, 2022
' Title: Assignment 6 - Cash Register Assignment

Module collectionModule

    'creates new collection
    Public inventoryCollection As New Collection

    Public Sub AddItem(ByVal Inv As Inventory)
        Try
            inventoryCollection.Add(Inv, Inv.InvNumber)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public inventoryCount As Integer = 0

End Module
