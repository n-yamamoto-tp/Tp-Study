Public Interface IJanken
    Enum result
        None = 0
        Rock = 1
        Scissors = 2
        Paper = 5
    End Enum
    Property RockProbaility As Short
    Property ScissorsProbaility As Short
    Property PaperProbaility As Short
    Property WinCount As Integer

    Function OutputJanken() As result
    Sub Reset()


End Interface
