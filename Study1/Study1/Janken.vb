Module Janken


    Sub Main()

        Dim persons As String = String.Empty
        Dim tryCount As Integer = 0

        Console.WriteLine("参加者の名前をカンマ区切りで入力してください。")
        Console.WriteLine("試行するじゃんけんの回数を指定してください。")
        Console.WriteLine("4名のプレイヤーで10000回実行する場合")
        Console.WriteLine("例）前田,佐藤,鈴木,山田 10000")
        Dim input As String = Console.ReadLine()

        Dim inputArgs() As String = input.Split(" "c)

        Try
            persons = inputArgs(0)
            tryCount = CInt(inputArgs(1))
        Catch ex As Exception
            Console.WriteLine("入力値エラー。処理を終了します")
            Console.ReadKey()
            Exit Sub

        End Try

        'Singleton Initializing
        RNG.GetInstance()

        Dim playerList As New List(Of IBaseUnit)
        For Each s As String In persons.Split(","c)

            'ToDO　人ならざるものを増やす分岐
            Dim person As New BaseUnit
            person.Name = s
            playerList.Add(person)
        Next


        Dim winResult As Integer = 0


        For i As Integer = 0 To tryCount - 1
            Console.WriteLine("//" & i + 1 & "回目・・・")

            Dim JunkenJudge As New JankenResultJudge

            For Each player As IBaseUnit In playerList
                JunkenJudge.PlayerList.Add(player)
                Console.WriteLine("参加者：" & player.Name)
            Next
            Console.WriteLine("=勝負=")
            Dim reStartCount As Integer = 0
            While JunkenJudge.Judge() > 1
                reStartCount += 1
                Console.WriteLine("再勝負（" & reStartCount & "回目）")
            End While
            Console.WriteLine("- - - - - - - - - -")

        Next

        For Each player As IBaseUnit In playerList
            If TypeOf player Is IJanken Then
                Console.WriteLine(player.Name & "は" & tryCount & "回中、" & DirectCast(player, IJanken).winCount & "回、勝ちました。")
            End If

        Next
        Console.WriteLine("処理を終了しました。")
        Console.ReadKey()


    End Sub



End Module
