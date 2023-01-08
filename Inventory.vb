' Programmer: Thessalonica (Tessa) Turnbull
' Date: October 4, 2022
' Title: Assignment 6 - Cash Register Assignment

Imports System.IO

Public Class Inventory

    'variables
    Public InvNumber As String
    Public Description As String
    Public Cost As Decimal
    Public Retail As Decimal
    Public OnHand As Integer

    'all getters and setters
    Public Property InventNumber() As String
        Get
            Return InvNumber
        End Get
        Set(ByVal value As String)
            InvNumber = value
        End Set
    End Property

    Public Property Description_cost() As String
        Get
            Return Description
        End Get
        Set(ByVal value As String)
            Description = value
        End Set
    End Property

    Public Property ItemCost() As Decimal
        Get
            Return Cost
        End Get
        Set(ByVal value As Decimal)
            Cost = value
        End Set
    End Property

    Public Property RetailPrice() As Decimal
        Get
            Return Retail
        End Get
        Set(ByVal value As Decimal)
            Retail = value
        End Set
    End Property

    Public Property QtyOnHand() As Integer
        Get
            Return OnHand
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                MessageBox.Show("OnHand count cannot be less than 0.", "Error")
                OnHand = 0
            Else
                OnHand = value
            End If
        End Set
    End Property
End Class
