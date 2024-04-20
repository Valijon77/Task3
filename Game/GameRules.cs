using Task3.Helpers;

namespace Task3.Game;

public class GameRules
{
    private readonly Moves _moves;

    public GameRules(Moves moves)
    {
        _moves = moves;
    }

    public static bool CheckBeforeGameStart(Moves moves)
    {
        if (moves.Count < 3)
        {
            RedMessage("Please provide at least 3 moves for the game to play.");
            return false;
        }
        else if (moves.Count % 2 != 1)
        {
            RedMessage("Please provide odd number of moves only.");
            return false;
        }
        else if (moves.Count != moves.Distinct().Count())
        {
            RedMessage("Please don't specify duplicate moves.");
            return false;
        }

        return true;
    }

    public bool CheckUserInputValid(string userInput)
    {
        bool isNumeric = int.TryParse(userInput, out int _userMoveOption);

        if (!isNumeric || _userMoveOption < 0 || _userMoveOption > _moves.Count)
        {
            RedMessage(
                $"Provided input move is not valid in the current context.\nPlease select from available moves range: 1...{_moves.Count}"
            );
            return false;
        }

        return true;
    }

    public string DecideGameOutcome(int userMoveIndex, int computerMoveIndex)
    {
        if (userMoveIndex == computerMoveIndex)
            return "Draw!";
        else
        {
            var winnerIndexes = _moves.GetWinnerIndexes(userMoveIndex);
            return winnerIndexes.Any(x => x == computerMoveIndex) ? "You win!" : "You lost :(";
        }
    }

    private static void RedMessage(string msg)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.BackgroundColor = ConsoleColor.Black;
    }
}
