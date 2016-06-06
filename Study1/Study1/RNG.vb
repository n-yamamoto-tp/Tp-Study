Imports System.Security.Cryptography
''' <summary>
''' Random Number Generator
''' </summary>
''' <remarks>Singleton</remarks>
Public Class RNG

    Public Shared RandomNumberGen As RNG

    Private Sub New()

    End Sub

    Public Shared Function GetInstance() As RNG
        If RandomNumberGen Is Nothing Then
            RandomNumberGen = New RNG
        End If

        Return RandomNumberGen

    End Function


    Public Shared Function GetRNG(ByVal range As Integer) As Integer

        Dim bytes As Byte() = New Byte(4) {}


        Dim Gen As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()

        Gen.GetBytes(bytes)



        Dim rv As New System.Random(BitConverter.ToInt32(bytes, 0))
        Return rv.Next(range)

    End Function

End Class
