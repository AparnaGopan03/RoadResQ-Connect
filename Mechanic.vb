Public Class Mechanic
    Public Property ProviderId As Integer
    Public Property Latitude As Double
    Public Property Longitude As Double
    Public Property AssistanceType As String
    Public Property Email As String
    Public Property Name As String
    Public Property Availability As Boolean

    Public Sub New()
        ' Default constructor
    End Sub

    Public Sub New(providerId As Integer, latitude As Double, longitude As Double, availability As Boolean)
        Me.ProviderId = providerId
        Me.Latitude = latitude
        Me.Longitude = longitude
        Me.Availability = availability
    End Sub

End Class
