Public Class JankenResultJudge

    Private _list As New List(Of IBaseUnit)

    Public Property PlayerList As List(Of IBaseUnit)
        Get
            Return Me._list
        End Get
        Set(value As List(Of IBaseUnit))
            Me._list = value
        End Set
    End Property

    ''' <summary>
    ''' じゃんけんします。
    ''' </summary>
    ''' <return>勝ち残った人の数</return>
    Public Function Judge() As Integer

        Dim rcpList As New List(Of Integer)

        For Each p As BaseUnit In PlayerList
            p.Reset()
            If TypeOf p Is IJanken Then
                Dim outputJankenResult As IJanken = p
                If Not rcpList.Contains(outputJankenResult.OutputJanken) Then
                    rcpList.Add(outputJankenResult.OutputJanken)

                End If
                Console.WriteLine("参加者：" & p.Name & " " & GetRspName(outputJankenResult.OutputJanken) & "を出しました。")
            Else
                Console.WriteLine("じゃんけんできない人が混じっていますよ？")
                Throw New Exception("じゃんけん対象者以外が混じってるエラー")

            End If

        Next

        '勝利のパターン
        'グーとチョキのみ　グーの勝ち
        'チョキーとパーのみ　チョキの勝ち
        'パーとグーのみ　パーの勝ち

        'それ以外はスルー
        Dim winner As IJanken.result = IJanken.result.None
        If rcpList.Contains(IJanken.result.Rock) AndAlso
           rcpList.Contains(IJanken.result.Scissors) AndAlso
           Not rcpList.Contains(IJanken.result.Paper) Then

            winner = IJanken.result.Rock
        ElseIf Not rcpList.Contains(IJanken.result.Rock) AndAlso
                    rcpList.Contains(IJanken.result.Scissors) AndAlso
                    rcpList.Contains(IJanken.result.Paper) Then
            winner = IJanken.result.Scissors
        ElseIf rcpList.Contains(IJanken.result.Rock) AndAlso
            Not rcpList.Contains(IJanken.result.Scissors) AndAlso
                rcpList.Contains(IJanken.result.Paper) Then
            winner = IJanken.result.Paper
        End If

        If winner <> IJanken.result.None Then
            For i As Integer = PlayerList.Count - 1 To 0 Step -1
                Dim player As IJanken = DirectCast(PlayerList(i), IJanken)
                If Not player.OutputJanken = winner Then
                    PlayerList.Remove(PlayerList(i))
                End If

            Next

            If PlayerList.Count = 1 Then
                Dim player As IJanken = DirectCast(PlayerList(0), IJanken)
                player.winCount += 1
                Console.WriteLine(PlayerList(0).Name & "が勝ちました。")



            End If
        End If



        Return PlayerList.Count

    End Function


    Private Function GetRspName(ByVal result As IJanken.result) As String
        Select Case result
            Case IJanken.result.Rock
                Return "グー"
            Case IJanken.result.Scissors
                Return "チョキ"
            Case IJanken.result.Paper
                Return "パー"
            Case Else
                Return Nothing
        End Select
    End Function
End Class
