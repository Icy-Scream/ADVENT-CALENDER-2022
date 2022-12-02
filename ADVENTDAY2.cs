using System.Text;
int _totalScore = 0;
string _changeWinStateString;

Console.WriteLine("PART 1 SCORE: FALSE, PART 2 SCORE: TRUE - Input: ");
_changeWinStateString = Console.ReadLine();
bool _changeWinState = _changeWinStateString == "TRUE";

string[] lines = File.ReadAllLines(@"C:\Users\17168\Desktop\RPSCheat.txt");

(string, string)[] letters = new (string, string)[lines.Length];

SplitLetters();
startGame();
Console.WriteLine("TOTAL SCORE: " + _totalScore); // GAME IS OVER FINAL OUTCOME OF BOTH PARTS

void SplitLetters()
{
    for (int i = 0; i < lines.Length; i++)
    {
        letters[i] = (lines[i].Split(" ")[0], lines[i].Split(" ")[1]);
    }
}

void startGame()
{
    for (int rounds = 0; rounds < lines.Length; rounds++)
    {
        ConvertInputToRSP(letters, rounds,_changeWinState);
    }
}



void ConvertInputToRSP((string, string)[] inputs, int round, bool codeWin)
{
    RPS playerInput = RPS.Rock;
    RPS elfInput = RPS.Rock;
    WinLoseTie winlosetie = WinLoseTie.Lose;
    if (!codeWin) 
    {
        if (inputs[round].Item1 == "A") elfInput = RPS.Rock;
        if (inputs[round].Item1 == "B") elfInput = RPS.Paper;
        if (inputs[round].Item1 == "C") elfInput = RPS.Scissor;

        if (inputs[round].Item2 == "X") playerInput = RPS.Rock;
        if (inputs[round].Item2 == "Y") playerInput = RPS.Paper;
        if (inputs[round].Item2 == "Z") playerInput = RPS.Scissor;
        CalculateScore(playerInput.ToString());
        DetermineWinRSP(playerInput.ToString(), elfInput.ToString());
    }
    else if (codeWin) 
    {

        if (inputs[round].Item1 == "A") elfInput = RPS.Rock; 
        if (inputs[round].Item1 == "B") elfInput = RPS.Paper;
        if (inputs[round].Item1 == "C") elfInput = RPS.Scissor;

        if (inputs[round].Item2 == "X") winlosetie = WinLoseTie.Lose;
        if (inputs[round].Item2 == "Y") winlosetie = WinLoseTie.Tie;
        if (inputs[round].Item2 == "Z") winlosetie = WinLoseTie.Win;
        CalculateScore(winlosetie.ToString());
        DetermineWinLoseStart(elfInput.ToString(),winlosetie.ToString());
    }
}


void DetermineWinLoseStart(string elf, string wtl) 
{
    RPS playerInput = RPS.Rock;
    if((elf == "Paper" && wtl == "Lose") || (elf == "Rock" && wtl == "Tie") || (elf == "Scissor" && wtl == "Win")) { playerInput = RPS.Rock; }
    if ((elf == "Rock" && wtl == "Win") || (elf == "Paper" && wtl == "Tie") || (elf == "Scissor"&& wtl == "Lose")) { playerInput = RPS.Paper; }
    if ((elf == "Paper" && wtl == "Win") || (elf == "Scissor" && wtl == "Tie") || (elf == "Rock" && wtl == "Lose")) { playerInput = RPS.Scissor; }
    CalculateScore(playerInput.ToString());

}
    


void DetermineWinRSP(string user, string elf)
{
    WinLoseTie result = WinLoseTie.Lose;
   
        if (user == "Rock" && elf == "Rock") { result = WinLoseTie.Tie; Console.WriteLine("TIE"); }
        if (user == "Paper" && elf == "Paper") { result = WinLoseTie.Tie; Console.WriteLine("TIE"); }
        if (user == "Scissor" && elf == "Scissor") { result = WinLoseTie.Tie; Console.WriteLine("TIE"); }
        if (user == "Rock" && elf == "Paper") { result = WinLoseTie.Lose; Console.WriteLine("LOSE BY PAPER"); }
        if (user == "Paper" && elf == "Scissor") { result = WinLoseTie.Lose; Console.WriteLine("LOSE BY SCISSOR"); }
        if (user == "Scissor" && elf == "Rock") { result = WinLoseTie.Lose; Console.WriteLine("LOSE BY ROCK"); }
        if (user == "Rock" && elf == "Scissor") { result = WinLoseTie.Win; Console.WriteLine("WIN BY ROCK"); }
        if (user == "Paper" && elf == "Rock") { result = WinLoseTie.Win; Console.WriteLine("WIN BY paper"); }
        if (user == "Scissor" && elf == "Paper") { result = WinLoseTie.Win; Console.WriteLine("WIN BY scissor"); }
        CalculateScore(result.ToString()); 
}


void CalculateScore(string score)
{

    if (score == "Rock") _totalScore += 1;
    if (score == "Paper") _totalScore += 2;
    if (score == "Scissor") _totalScore += 3;
    if (score == "Win") _totalScore += 6;
    if (score == "Lose") _totalScore += 0;
    if (score == "Tie") _totalScore += 3;
}



enum RPS { Rock, Paper, Scissor }
enum WinLoseTie { Win, Lose, Tie }
