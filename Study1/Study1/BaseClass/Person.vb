Imports System.Security.Cryptography
Imports Study1

''' <summary>
''' じゃんけんをする人間の基本クラス
''' </summary>
Public Class Person
    Implements IJanken
    Implements IPerson

#Region "変数"
    Private _rockProbaility As Short = 1
    Private _scissorsProbaility As Short = 1
    Private _PaperProbaility As Short = 1


#End Region


#Region "Property"

    ''' <summary>
    ''' グーを出す確率を割合で定義します
    ''' </summary>
    ''' <returns></returns>
    Public Property RockProbaility As Short Implements IJanken.RockProbaility
        Get
            Return _rockProbaility
        End Get
        Set(value As Short)
            _rockProbaility = value
        End Set
    End Property

    ''' <summary>
    ''' チョキを出す確率を割合で定義します
    ''' </summary>
    ''' <returns></returns>
    Public Property ScissorsProbaility As Short Implements IJanken.ScissorsProbaility
        Get
            Return _scissorsProbaility
        End Get
        Set(value As Short)
            _scissorsProbaility = value
        End Set
    End Property

    ''' <summary>
    ''' パーを出す確率を割合で定義します
    ''' </summary>
    ''' <returns></returns>
    Public Property PaperProbaility As Short Implements IJanken.PaperProbaility
        Get
            Return _PaperProbaility
        End Get
        Set(value As Short)
            _PaperProbaility = value
        End Set
    End Property

    Private _Name As String = "No Name"

    ''' <summary>
    ''' 名前を設定します。
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String Implements IPerson.Name
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property

    Private _winCount As Integer = 0

    ''' <summary>
    ''' 勝利回数
    ''' </summary>
    ''' <returns></returns>
    Public Property WinCount As Integer Implements IJanken.WinCount
        Get
            Return _winCount
        End Get
        Set(value As Integer)
            _winCount = value
        End Set
    End Property



#End Region

    Private _result As IJanken.result = IJanken.result.None
    ''' <summary>
    ''' じゃんけんの結果を出力します。
    ''' </summary>
    ''' <remarks>一度出したら変更不可</remarks>
    Private Function IJanken_OutputJanken() As IJanken.result Implements IJanken.OutputJanken

        If _result <> IJanken.result.None Then
            Return _result
        End If
        Dim total As Integer = Me.RockProbaility + Me.ScissorsProbaility + Me.PaperProbaility

        Dim bytes As Byte() = New Byte(4) {}


        Dim Gen As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()

        Gen.GetBytes(bytes)



        Dim rv As New System.Random(BitConverter.ToInt32(bytes, 0))
        Dim rnd As Integer = rv.Next(total)

        If rnd > 0 And rnd <= Me.RockProbaility Then
            _result = IJanken.result.Rock
        ElseIf rnd > Me.RockProbaility AndAlso rnd <= Me.RockProbaility + Me.ScissorsProbaility Then
            _result = IJanken.result.Scissors
        Else
            _result = IJanken.result.Paper
        End If



        Return _result


    End Function

    ''' <summary>
    ''' 出した結果をリットします
    ''' </summary>
    Public Sub Reset() Implements IJanken.Reset
        Me._result = IJanken.result.None
    End Sub

End Class
