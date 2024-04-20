using Task3.Helpers;
using Task3.Table;
using Task3.Security;

namespace Task3.Game;

public class GameProcedure
{
    private readonly Moves _moves;
    private readonly GameRules _rules;
    private readonly int _computerMoveIndex;
    private int _userMoveIndex;
    private readonly HMAC_2 _hmac;

    public GameProcedure(Moves moves)
    {
        _moves = moves;
        _rules = new(_moves);
        _computerMoveIndex = new Random().Next(0, _moves.Count);
        _hmac = new(_moves[_computerMoveIndex]);
    }

    public void PlayTheGame()
    {
        bool shouldContinue = StartTheGame();
        if (shouldContinue)
        {
            FinishTheGame();
        }
    }

    public bool StartTheGame()
    {
        _hmac.PrintHashedMessage();

        while (true)
        {
            DisplayMenu();
            string userMoveInput = TakeUserInput();

            switch (userMoveInput)
            {
                case "?":
                    DisplayHelpTable();
                    return false;
                case "0":
                    ExitTheGame();
                    return false;
                default:
                    if (!_rules.CheckUserInputValid(userMoveInput))
                        continue;

                    _userMoveIndex = int.Parse(userMoveInput) - 1;
                    return true;
            }
        }
    }

    public void FinishTheGame()
    {
        Console.WriteLine(
            $"Your move: {_moves[_userMoveIndex]} \nComputer move: {_moves[_computerMoveIndex]}"
        );
        Console.WriteLine(_rules.DecideGameOutcome(_userMoveIndex, _computerMoveIndex));

        _hmac.PrintTheKey();
    }

    private void DisplayHelpTable()
    {
        HelpTable.ConfigureTable(_moves);
        HelpTable.DisplayTable();
    }

    private static void ExitTheGame()
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Exiting the game...");
    }

    private void DisplayMenu()
    {
        Console.WriteLine("Available moves: ");
        for (int i = 0; i < _moves.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {_moves[i]}");
        }
        Console.WriteLine("0 - exit \n? - help");
    }

    private static string TakeUserInput()
    {
        Console.Write("Enter your move: ");
        return Console.ReadLine() ?? "";
    }
}
